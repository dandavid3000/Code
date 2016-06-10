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


uint64_t pt;      /* Plain text. */
uint64_t *ct;      /* Array of cipher texts. */
double *t;      /* Array of timing measurements. */

/* A function to allocate cipher texts and timings arrays ct and t, read the
 * datafile and store its content in global variables pt, ct and t. */
void read_datafile (char *name, int n);

/* A function to brute-force attack with partial knowledge plus a pair of
 * plain text - cipher text as an oracle. Return 0 on failure, 1 on success. */
int brute_force (des_key_manager km, uint64_t pt, uint64_t ct);

int
main (int argc, char **argv)
{
  int n;      /* Required number of experiments. */
  int i;      /* Loop index. */
  des_key_manager km;    /* Key manager. */

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

  int s, g;
  int best_guess[8][2]; /* Array contains 2 best guess for each SBox*/
  double max, second_max;
  int best_guess1 = -1; 
  int best_guess2 = -1;
  double score[64] = {0.0};
  pcc_context ctx;

  uint64_t k16 = 0;

  for (s=1; s<=8; s++){

      ctx = pcc_init(64); 

      for (i = 0; i < n; i++) {

          pcc_insert_x(ctx, t[i]);

          for(g=0; g < 64; g++){
              uint64_t right = (uint64_t) des_right_half(des_ip(ct[i]));
              uint64_t e_right = (uint64_t) des_e(right);
              uint64_t sb_input = (uint64_t) g ^ (uint64_t)((e_right >> (8-s)*6)&0x3f);
              int hw = hamming_weight (des_sbox(s, sb_input));
              pcc_insert_y(ctx, g, hw);
          }
      }

      pcc_consolidate(ctx);
      
      max = pcc_get_pcc(ctx, 0);
      best_guess1 = 0;

      for (g = 1; g < 64; g++){

          score[g] = pcc_get_pcc(ctx, g);

          if(max < score[g]){
              max = score[g];
              best_guess1 = g;
          }
      }

      second_max = pcc_get_pcc(ctx, 63 - best_guess1);

      for (g=1; g < 64; g++){
          if(second_max < score[g] && best_guess1 != g){
              second_max = score[g];
              best_guess2 = g;
          }
      }
      
      best_guess[s-1][0] = best_guess1;
      best_guess[s-1][1] = best_guess2;

      pcc_free(ctx);
      /*
      printf("S = %d\n", s);
      for (j = 0; j < 2; j++){
          printf("Best guess %d,%d: %d\n", s, j, best_guess[s-1][j]);
      }*/
  }

  int k1, k2, k3, k4, k5, k6, k7, k8;

  for (k1 = 0; k1 < 2; k1++)
    for (k2 = 0; k2 < 2; k2++)
      for (k3 = 0; k3 < 2; k3++)
        for (k4 = 0; k4 < 2; k4++)
          for (k5 = 0; k5 < 2; k5++)
            for (k6 = 0; k6 < 2; k6++)
              for (k7 = 0; k7 < 2; k7++)
                for (k8 = 0; k8 < 2; k8++)
                {
                    k16 = 0;
                    k16 = (uint64_t) k16
                              |(uint64_t)best_guess[0][k1]<<((8-1)*6)
                              |(uint64_t)best_guess[1][k2]<<((8-2)*6)
                              |(uint64_t)best_guess[2][k3]<<((8-3)*6)
                              |(uint64_t)best_guess[3][k4]<<((8-4)*6)
                              |(uint64_t)best_guess[4][k5]<<((8-5)*6)
                              |(uint64_t)best_guess[5][k6]<<((8-6)*6)
                              |(uint64_t)best_guess[6][k7]<<((8-7)*6)
                              |(uint64_t)best_guess[7][k8]<<((8-8)*6);

                    km = des_km_init ();
                    des_km_set_rk (km, 16, 1, UINT64_C (0xffffffffffff), k16);

                    if (brute_force (km, pt, ct[0])){                        
                        free (ct);      /* Deallocate cipher texts */
                        free (t);      /* Deallocate timings */
                        des_km_free (km);    /* Deallocate the key manager */
                        return 0;      /* Exits with "everything went fine" status. */
                    }
                }

  printf ("We all live in a yellow submarine, yellow submarine, ...\n");

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
  do        /* Iterate over the 256 possible keys */
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
