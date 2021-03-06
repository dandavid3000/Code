/**********************************************************************************
Copyright Institut Telecom
Contributors: Renaud Pacalet (renaud.pacalet@telecom-paristech.fr)

This software is a computer program whose purpose is to experiment timing and
power attacks against crypto-processors.

This software is governed by the CeCILL license under French law and
abiding by the rules of distribution of free software.  You can  use,
modify and/ or redistribute the software under the terms of the CeCILL
license as circulated by CEA, CNRS and INRIA at the following URL
"http://www.cecill.info".

As a counterpart to the access to the source code and  rights to copy,
modify and redistribute granted by the license, users are provided only
with a limited warranty  and the software's author,  the holder of the
economic rights,  and the successive licensors  have only  limited
liability.

In this respect, the user's attention is drawn to the risks associated
with loading,  using,  modifying and/or developing or reproducing the
software by the user in light of its specific status of free software,
that may mean  that it is complicated to manipulate,  and  that  also
therefore means  that it is reserved for developers  and  experienced
professionals having in-depth computer knowledge. Users are therefore
encouraged to load and test the software's suitability as regards their
requirements in conditions enabling the security of their systems and/or
data to be ensured and,  more generally, to use and operate it in the
same conditions as regards security.

The fact that you are presently reading this means that you have had
knowledge of the CeCILL license and that you accept its terms. For more
information see the LICENCE-fr.txt or LICENSE-en.txt files.
**********************************************************************************/

#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <inttypes.h>

#include <utils.h>
#include <des.h>
#include <km.h>
#include <pcc.h>

uint64_t pt;    /* Plain text. */
uint64_t *ct;   /* Array of cipher texts. */
double *t;      /* Array of timing measurements. */

/* Allocate arrays <ct> and <t> to store <n> cipher texts and timing
 * measurements. Open datafile <name> and store its content in global variables
 * <pt>, <ct> and <t>. */
void read_datafile (char *name, int n);

/* Brute-force attack with a plain text - cipher text pair (<pt>, <ct>) and
 * partial knowledge of secret key (<km>). Print the found secret key (16 hex
 * digits) and return 1 if success, else return 0 and print nothing. */
int brute_force (des_key_manager km, uint64_t pt, uint64_t ct);

int
main (int argc, char **argv)
{
  int n;              /* Required number of experiments. */
  uint64_t r16l16;    /* Output of last round, before final permutation. */
  uint64_t l16;       /* Right half of r16l16. */

  uint64_t sbo;       /* Output of SBoxes during last round. */
  double sum;         /* Sum of timing measurements. */
  int i;              /* Loop index. */
  des_key_manager km; /* Key manager. */

  /************************************************************************/
  /* Before doing anything else, check the correctness of the DES library */
  /************************************************************************/
  if (!des_check ())
    {
      ERROR (-1, "DES functional test failed");
    }

  /*************************************/
  /* Check arguments and read datafile */
  /*************************************/
  /* If invalid number of arguments (including program name), exit with error
   * message. */
  if (argc != 3)
    {
      ERROR (-1, "usage: ta <datafile> <nexp>\n");
    }
  /* Number of experiments to use is argument #2, convert it to integer and
   * store the result in variable n. */
  n = atoi (argv[2]);
  if (n < 1)      /* If invalid number of experiments. */
    {
      ERROR (-1,
       "number of experiments to use (<nexp>) shall be greater than 1 (%d)",
       n);
    }
  read_datafile (argv[1],  /* Name of data file is argument #1. */
     n    /* Number of experiments to use. */
    );

  /*****************************************************************************
   * Compute the Hamming weight of output of first (leftmost) SBox during last *
   * round, under the assumption that the last round key is all zeros.         *
   *****************************************************************************/
  /* Undoes the final permutation on cipher text of n-th experiment. */
  r16l16 = des_ip (ct[n - 1]);
  /* Extract right half (strange naming as in the DES standard). */
  l16 = des_right_half (r16l16);
  /*--------------------We have l16=r15 --------------------------*/
  
  int sbox,guess;
  uint64_t k16=0;
  int best_guess[8]; /*8 best guesses for 8 sboxes */
  int bg = -1;
  double max;
  double score[64] = {0.0};
  pcc_context ctx;
  
  for (sbox=1; sbox<=8 ; sbox++)
  {
	ctx = pcc_init(64);
	for (i=0; i<n; i++)
	{
		pcc_insert_x(ctx, t[i]);
		for (guess=0; guess<64; guess++)
		{
	              uint64_t right = (uint64_t) des_right_half(des_ip(ct[i]));
	              uint64_t e_right = (uint64_t) des_e(right);
	              uint64_t sb_input = (uint64_t) guess ^ (uint64_t)((e_right >> (8-sbox)*6)&0x3f);
	              int hw = hamming_weight (des_sbox(sbox, sb_input));
	              pcc_insert_y(ctx, guess, hw);
		}
		
	}

	pcc_consolidate(ctx);

	max = pcc_get_pcc(ctx,0);
	bg = 0;

	for ( guess=1; guess<64; guess++)
	{
		score[guess]= pcc_get_pcc(ctx,guess);
		
		if(max < score[guess])
		{
			max = score[guess];
			bg = guess;
		}
	}

        
	best_guess[sbox-1] = bg;
	pcc_free(ctx);

  }
  	k16 = 0;
	/*Merge all the key together*/
 	k16 = (uint64_t) k16
	      |(uint64_t)best_guess[0]<<((8-1)*6)
	      |(uint64_t)best_guess[1]<<((8-2)*6)
	      |(uint64_t)best_guess[2]<<((8-3)*6)
	      |(uint64_t)best_guess[3]<<((8-4)*6)
	      |(uint64_t)best_guess[4]<<((8-5)*6)
	      |(uint64_t)best_guess[5]<<((8-6)*6)
	      |(uint64_t)best_guess[6]<<((8-7)*6)
	      |(uint64_t)best_guess[7]<<((8-8)*6);
	
  /* Compute output of SBoxes during last round of first experiment, assuming
   * the last round key is all zeros. */
  sbo = des_sboxes (des_e (l16) ^ UINT64_C (0));  /* R15 = L16, K16 = 0 */
  /* Compute and print Hamming weight of output of first SBox (mask the others). */
  printf ("Hamming weight: %d\n",
    hamming_weight (sbo & UINT64_C (0xf0000000)));

  /************************************
   * Compute and print average timing *
   ************************************/
  sum = 0.0;      /* Initializes the accumulator for the sum of timing measurements. */
  for (i = 0; i < n; i++)  /* For all n experiments. */
    {
      sum = sum + t[i];    /* Accumulate timing measurements. */
    }
  /* Compute and print average timing measurements. */
  printf ("Average timing: %f\n", sum / (double) (n));

  /*******************************************************************************
   * Try all the 256 secret keys under the assumption that the last round key is *
   * all zeros.                                                                  *
   *******************************************************************************/
  /* If we are lucky, the secret key is one of the 256 possible with a all zeros
   * last round key. Let's try them all, using the known plain text - cipher text
   * pair as an oracle. */
  km = des_km_init ();    /* Initialize the key manager with no knowledge. */
  /* Tell the key manager that we 'know' the last round key (#16) is all zeros. */
  des_km_set_rk (km,    /* Key manager */
     16,    /* Round key number */
     1,    /* Force (we do not care about conflicts with pre-existing knowledge) */
     UINT64_C (0xffffffffffff),  /* We 'know' all the 48 bits of the round key */
     k16  /* The all zeros value for the round key */
    );
  /* Brute force attack with the knowledge we have and a known
   * plain text - cipher text pair as an oracle. */
  if (!brute_force (km, pt, ct[0]))
    {
      printf ("Too bad, we lose: the last round key is not all zeros.\n");
    }
  free (ct);      /* Deallocate cipher texts */
  free (t);      /* Deallocate timings */
  des_km_free (km);    /* Deallocate the key manager */
  return 0;      /* Exits with "everything went fine" status. */
}

void
read_datafile (char *name, int n)
{
  FILE *fp;      /* File descriptor for the data file. */
  int i;      /* Loop index */

  /* Open data file for reading, store file descriptor in variable fp. */
  fp = XFOPEN (name, "r");

  /* Read the first line and stores the value (plain text) in variable pt. If
   * read fails, exit with error message. */
  if (fscanf (fp, "%" PRIx64, &pt) != 1)
    {
      ERROR (-1, "cannot read plain text");
    }

  /* Allocates memory to store the cipher texts and timing measurements. Exit
   * with error message if memory allocation fails. */
  ct = XCALLOC (n, sizeof (uint64_t));
  t = XCALLOC (n, sizeof (double));

  /* Read the n experiments (cipher text and timing measurement). Store them in
   * the ct and t arrays. Exit with error message if read fails. */
  for (i = 0; i < n; i++)
    {
      if (fscanf (fp, "%" PRIx64 " %lf", &(ct[i]), &(t[i])) != 2)
        {
          ERROR (-1, "cannot read cipher text and/or timing measurement");
        }
    }
}

int
brute_force (des_key_manager km, uint64_t pt, uint64_t ct)
{
  uint64_t dummy, key, ks[16];

  des_km_init_for_unknown (km);  /* Initialize the iterator over unknown bits */
  do        /* Iterate over the possible keys */
    {
      key = des_km_get_key (km, &dummy);  /* Get current key, ignore the mask */
      des_ks (ks, key);    /* Compute key schedule with current key */
      if (des_enc (ks, pt) == ct)  /* If we are lucky... cheers. */
        {
          printf ("%016" PRIx64 "\n", key);
          return 1;    /* Stop iterating and return success indicator. */
        }
    }
  while (des_km_for_unknown (km));  /* Continue until we tried them all */
  return 0;      /* Return failure indicator. */
}
