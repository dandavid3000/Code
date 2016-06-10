using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Apriori
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a numeric argument.");

            }

            else
            {
                 Apriori.Data_practice dt_p = new Apriori.Data_practice();
                 dt_p.ReadFile(args[0]);
                 dt_p.Chuan_hoa_Ve_0_1();
                 Double minsup = Convert.ToDouble((Convert.ToDouble(args[1]) * dt_p.row_num) / 100);//doi ve tang suat
                 Double maxsup = Convert.ToDouble((Convert.ToDouble(args[2]) * dt_p.row_num) / 100);//doi ve tang suat
                string name_result = args[3];
                ArrayList C = new ArrayList();
                C.Add("");

                ArrayList[] L = new ArrayList[10];
               
               
                dt_p.Tim_phobien_1_hangmuc(minsup);
                //L.Add(dt_p.Phobien_1_hangmuc);
                //L.Add("");
                L[1] = dt_p.Phobien_1_hangmuc;
                //int k=1

                //foreach (ArrayList Arr in L)
                for (int k = 1; L[k] != null; k++)
                {

                    ArrayList temp = new ArrayList();
                    C = dt_p.apriori_gen(L[k]);
                    C = dt_p.Loai_bo_trung(C);
                    C = dt_p.Loai_bo_trung(C);
                    foreach (string st in C)
                    {
                        if (dt_p.Tim_minsupp(st) >= minsup && dt_p.Tim_minsupp(st)<=maxsup)
                            temp.Add(st);

                    }
                    // L.Add(temp);
                    if (temp.Count != 0)
                    {


                        L[k + 1] = temp;


                    }

                }

                dt_p.sort(ref L);
                dt_p.LoaiKetQuaTrung(ref L);
                // dt_p.LoaiKetQuaTrung(ref L);
                dt_p.GhiFile(L, name_result);
                Console.WriteLine("///////// Thuc Thi Thanh cong//////////");
            }
        }


    }
       
      


 
}
