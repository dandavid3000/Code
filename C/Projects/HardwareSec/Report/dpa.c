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

As a spart to the access to the source code and  rights to copy,
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
#include <string.h>

#include <utils.h>
#include <traces.h>
#include <des.h>
#include <km.h>
/*#include <sys/time.h>*/

#define NUM 3 /*Number of best guess for each Sbox, we can change this value to reduce processing time; the lower value, the more experiments to use*/

/* The P permutation table, as in the standard. The first entry (16) is the
 * position of the first (leftmost) bit of the result in the input 32 bits word.
 * Used to convert target bit index into SBox index (just for printed summary
 * after attack completion). */
int p_table[32] = {
    16, 7, 20, 21,
    29, 12, 28, 17,
    1, 15, 23, 26,
    5, 18, 31, 10,
    2, 8, 24, 14,
    32, 27, 3, 9,
    19, 13, 30, 6,
    22, 11, 4, 25
};

uint64_t key;                   
uint64_t ks[16];                
uint64_t k16;                   
des_key_manager km;             

tr_context ctx;                 /* Trace context (see traces.h) */
int best_guess[8][NUM];                 /* Best guess */
int best_idx[64];                   /* Best argmax */
float best_max;                 /* Best max sample value */
float *dpa[64];                 /* 64 DPA traces */
/*
struct timeval  tv;
double time_in_mill1, time_in_mill2;*/



/* A function to allocate cipher texts and power traces, read the
 * datafile and store its content in allocated context. */
void read_datafile (char *name, int n);

/* Decision function: takes a ciphertext and returns an array of 64 values for
 * an intermediate DES data, one per guess on a 6-bits subkey. In this example
 * the decision is the computed value of bit index <target_bit> of L15. Each of
 * the 64 decisions is thus 0 or 1.*/
void decision (uint64_t ct, int d[8][64]);

/* Apply P. Kocher's DPA algorithm based on decision function. Computes 64 DPA
 * traces dpa[0..63], best_guess (6-bits subkey corresponding to highest DPA
 * peak), best_idx (index of sample with maximum value in best DPA trace) and
 * best_max (value of sample with maximum value in best DPA trace). */
void dpa_attack (void);

void key_generation (void);

int
main (int argc, char **argv) {
    int n;                        /* Number of experiments to use. */
    int g;                        /* Guess on a 6-bits subkey */
    
    /*
    gettimeofday(&tv, NULL);
    time_in_mill1 = (tv.tv_sec) * 1000 + (tv.tv_usec) / 1000 ;    */
    
    /************************************************************************/
    /* Before doing anything else, check the correctness of the DES library */
    /************************************************************************/
    if (!des_check ()) {
        ERROR (-1, "DES functional test failed");
    }

    /*************************************/
    /* Check arguments and read datafile */
    /*************************************/
    /* If invalid number of arguments (including program name), exit with error
     * message. */
    if (argc != 3) {
        ERROR (-1, "usage: dpa <file> <n> <b>\n  <file>: name of the traces file in HWSec format\n          (e.g. /datas/teaching/courses/HWSec/labs/data/HWSecTraces10000x00800.hws)\n  <n>: number of experiments to use\n");
    }
    /* Number of experiments to use is argument #2, convert it to integer and
     * store the result in variable n. */
    n = atoi (argv[2]);
    if (n < 1) {
        ERROR (-1, "invalid number of experiments: %d (shall be greater than 1)", n);
    }
    /* Target bit is argument #3, convert it to integer and store the result in
     * variable target_bit. */
    
    /* Read power traces and ciphertexts. Name of data file is argument #1. n is
     * the number of experiments to use. */
    read_datafile (argv[1], n);

     
    /***************************************************************
   * Attack target bit in L15=R14 with P. Kocher's DPA technique *
   ***************************************************************/
    dpa_attack ();


    /*************************
     * Free allocated traces *
     *************************/
    for (g = 0; g < 64; g++) {    /* For all guesses for 6-bits subkey */
        tr_free_trace (ctx, dpa[g]);
    }
    tr_free (ctx);                /* Free traces context */
    
    return 0;                     /* Exits with "everything went fine" status. */
}

void
read_datafile (char *name, int n) {
    int tn;

    ctx = tr_init (name, n);
    tn = tr_number (ctx);
    if (tn != n) {
        tr_free (ctx);
        ERROR (-1, "Could not read %d experiments from traces file. Traces file contains %d experiments.", n, tn);
    }
}



void
decision (uint64_t ct, int d[8][64]) {
    int g, s;                     /* Guess & SBox */
    uint64_t r16l16;              /* R16|L16 (64 bits state register before final permutation) */
    uint64_t l16;                 /* L16 (as in DES standard) */
    uint64_t r16;                 /* R16 (as in DES standard) */
    uint64_t er15;                /* E(R15) = E(L16) */
    uint64_t rk;                  /* Value of last round key */
    uint64_t nr16r15;             /* Inverse permutation of R16^R15 */


    r16l16 = des_ip (ct);         /* Compute R16|L16 */
    l16 = des_right_half (r16l16);        /* Extract right half */
    r16 = des_left_half (r16l16); /* Extract left half */
    er15 = des_e (l16);           /* Compute E(R15) = E(L16) */
    /* For all guesses (64). rk is a 48 bits last round key with all 6-bits
     * subkeys equal to current guess g (nice trick, isn't it?). */
    for (g = 0, rk = UINT64_C (0); g < 64; g++, rk += UINT64_C (0x041041041041)) {

        nr16r15 = (des_n_p(r16 ^ l16) ^ des_sboxes (er15 ^ rk));       /* Compute Inverse permuation of R16^R15 */
        /*Compute decisions for all SBoxes*/
        for (s = 0; s < 8; s++) {
            d[s][g] = hamming_weight (nr16r15 & (UINT64_C (0xf0000000)) >> (s * 4));
        }         /* End for guesses */	
    }
}

void
dpa_attack (void) {
  int i, j, k;                        /* Loop index */
  int s;                        /* SBoxes. */
  int n;                        /* Number of traces. */
  int g;                        /* Guess on a 6-bits subkey */
  int idx;                      /* Argmax (index of sample with maximum value in a trace) */
  int indextemp;
  int d[8][64];                    /* Decisions on the target bit */

  float *t;                     /* Power trace */
  float max[64] = {0.0};                    /* Max sample value in a trace */
  float *t0[8][64];                /* Power traces for the low-sets (one per guess) */
  float *t1[8][64];                /* Power traces for the high-sets (one per guess) */

  int n0[8][64];                   /* Number of power traces in the low-sets (one per guess) */
  int n1[8][64];                   /* Number of power traces in the high-sets (one per guess) */

  uint64_t ct;                  /* Ciphertext */

  
  for (s = 0;s < 8; s++){             /* For all SBoxes */
    for (g = 0; g < 64; g++){      /* For all guesses for 6-bits subkey */    
      dpa[g] = tr_new_trace (ctx);      /* Allocate a DPA trace */
      t0[s][g] = tr_new_trace (ctx);       /* Allocate a trace for low-set */
      tr_init_trace (ctx, t0[s][g], 0.0);  /* Initialize trace to all zeros */
      n0[s][g] = 0;                /* Initialize trace count in low-set to zero */
      t1[s][g] = tr_new_trace (ctx);       /* Allocate a trace for high-set */
      tr_init_trace (ctx, t1[s][g], 0.0);  /* Initialize trace to all zeros */
      n1[s][g] = 0;                /* Initialize trace count in high-set to zero */
    }                           /* End for all guesses */ 
  }                             /* End for all SBoxes */ 

  

  n = tr_number (ctx);          /* Number of traces in context */
  for (i = 0; i < n; i++){       /* For all experiments */      
    t = tr_trace (ctx, i);    /* Get power trace */
    ct = tr_ciphertext (ctx, i);      /* Get ciphertext */
    decision (ct, d);         /* Compute the 64 decisions */
        
      for (s = 0;s < 8; s++){              /* For all SBoxes (8) */
        for (g = 0; g < 64; g++){          /* For all guesses (64) */
          if (d[s][g] <= 1){
            tr_acc (ctx, t0[s][g], t);   /* Accumulate power trace in low-set */
            n0[s][g] += 1;       /* Increment traces count for low-set */
          }
          else if (d[s][g] >= 3){                /* If decision on target bit is one */            
            tr_acc (ctx, t1[s][g], t);   /* Accumulate power trace in high-set */
            n1[s][g] += 1;       /* Increment traces count for high-set */
          }
        }                       /* End for guesses */
      }                         /* End for SBoxes */
  }                            /* End for experiments */
  for (s = 0;s < 8; s++){         /* For all Sboxes */
    int temp;
    for (g = 0; g < 64; g++){      /* For all guesses for 6-bits subkey */    
      tr_scalar_div (ctx, t0[s][g], t0[s][g], (float) (n0[s][g]));       /* Normalize low-set */
      tr_scalar_div (ctx, t1[s][g], t1[s][g], (float) (n1[s][g]));       /* Normalize low-set */
      tr_sub (ctx, dpa[g], t1[s][g], t0[s][g]);       /* Compute high-set minus low-set */
      max[g] = tr_max (ctx, dpa[g], &idx); /* Get max and argmax of DPA trace */
      best_idx[g] = g;
      /*Sort list of max values to get TOP NUM values candidate for best_guess*/
      k = g;
      while (k > 0 && max[k] < max[k-1]) {
        temp = max[k];
        indextemp = best_idx[k];
        max[k] = max[k-1];
        best_idx[k] = best_idx[k-1];
        max[k-1] = temp;
        best_idx[k-1] = indextemp;
 
        k--;
      }
    }  
    for (j = 0; j < NUM; j++){
        best_guess[s][j] = best_idx[63-j];
        /*printf("Best guess %d,%d: %d - \n", s, j, best_idx[63-j]);*/
    }                           /* End for all guesses */   
    
  }                           /* End for all Boxes */
  
  /*Try all possible keys*/
  key_generation();
  
  /* Free allocated traces */
  for (s = 0;s < 8; s++){
    for (g = 0; g < 64; g++){      /* For all guesses for 6-bits subkey */
      tr_free_trace (ctx, t0[s][g]);
      tr_free_trace (ctx, t1[s][g]);
    }
  }
  
  /* Print the key */  
  /*printf ("%012" PRIx64 "\n", k16 );*/
  
  /*
  gettimeofday(&tv, NULL);
  time_in_mill2 = (tv.tv_sec) * 1000 + (tv.tv_usec) / 1000 ;
  printf ("Time interval: %f", time_in_mill2 - time_in_mill1);*/
  return;
}

void
key_generation(void){
    int k1, k2, k3, k4, k5, k6, k7, k8;
    
    uint64_t mask1 = UINT64_C (0xffffffffffff);
    uint64_t mask2 = UINT64_C (0x3f);
    key = tr_key (ctx); 
    des_ks (ks, key);
    
    /*Try all possible candidates for each SBoxes*/
    for (k1 = 0; k1 < NUM; k1++)
      for (k2 = 0; k2 < NUM; k2++)
        for (k3 = 0; k3 < NUM; k3++)
          for (k4 = 0; k4 < NUM; k4++)
            for (k5 = 0; k5 < NUM; k5++)
              for (k6 = 0; k6 < NUM; k6++)
                for (k7 = 0; k7 < NUM; k7++)
                  for (k8 = 0; k8 < NUM; k8++){
		    
		    km = des_km_init ();         /*Initialize the key management. */
		    
		    des_km_set_sk ( km, 16, 1, 1, mask2, best_guess[0][k1] );
		    des_km_set_sk ( km, 16, 2, 1, mask2, best_guess[1][k2] );
		    des_km_set_sk ( km, 16, 3, 1, mask2, best_guess[2][k3] );
		    des_km_set_sk ( km, 16, 4, 1, mask2, best_guess[3][k4] );
		    des_km_set_sk ( km, 16, 5, 1, mask2, best_guess[4][k5] );
		    des_km_set_sk ( km, 16, 6, 1, mask2, best_guess[5][k6] );
		    des_km_set_sk ( km, 16, 7, 1, mask2, best_guess[6][k7] );
		    des_km_set_sk ( km, 16, 8, 1, mask2, best_guess[7][k8] );
		    
		    k16 = des_km_get_rk ( km, 16, &mask1 );		    
		    
		    
		    if (k16 == ks[15]){
		      /*printf ("We got it.\n");*/
		      printf ("%012" PRIx64 "\n", k16 );	      
                      /*
                      gettimeofday(&tv, NULL);
                      time_in_mill2 = (tv.tv_sec) * 1000 + (tv.tv_usec) / 1000 ;
                      printf ("Time interval: %f", time_in_mill2 - time_in_mill1);*/
		      des_km_free (km);
                      return;
		    }
		    des_km_free (km);
    }
    printf ("Too bad...\n");
}
