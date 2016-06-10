using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace Apriori
{
    class Data_practice
    {
        public int NumAT;//so thuoc tinh
        public int row_num;//so dong thuoc tinh(or) so lan giao dich
        public string[,] A;//chua du lieu
        public ArrayList Phobien_1_hangmuc = new ArrayList();//tap pho bien mot hang muc
        //public string[] Phobien_1_hangmuc;

        public void ReadFile(string filePath)
        {

            row_num = count_row(filePath);//doc file dem so dong giao dich
            FileStream theFile = File.Open(filePath, FileMode.OpenOrCreate,
           FileAccess.Read);
            StreamReader reader = new StreamReader(theFile);
            string AllAt = reader.ReadLine();//tac ca thuoc tinh
            NumAT = countAt(AllAt);//dem so thuoc tinh


            A = new string[row_num, NumAT];
            string[]tempAT= AllAt.Split(',');
            for (int j = 0; j < NumAT; j++)
                A[0, j] = tempAT[j];
                

            //while ( (str=reader.ReadLine())!= null)
            int k = 1;
            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                string[] tam = str.Split(',');
               
                for (int j = 0; j < NumAT; j++)
                    A[k,j] = tam[j];
                k++;
               
            }
            reader.Close();

        }

        public int countAt(string att)//ham dem so thuoc tinh
        {
            int count = 0;
            string[] temp = att.Split(',');

            count = temp.Length;
            return count;


        }

        //dem so dong du lieu
        public int count_row(string duongdan)//ham dem so thuoc tinh
        {
            FileStream theFile = File.Open(duongdan, FileMode.OpenOrCreate,
           FileAccess.Read);
            StreamReader reader = new StreamReader(theFile);
            int dem = 0;
            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                dem++;
            }
            reader.Close();
            return dem;
        }
        public void Tim_phobien_1_hangmuc(Double minsup)
        {
           
            for(int i=0;i<NumAT;i++)
            {
                int dem=0;
                for (int j = 1; j < row_num; j++)
                    if (A[j, i] == "1")
                        dem++;
                if (dem >= minsup)
                    Phobien_1_hangmuc.Add(A[0,i]);
            }
        }
        public ArrayList apriori_gen(ArrayList LK)
        {

            
            ArrayList kq = new ArrayList();
            for (int i = 0; i < LK.Count; i++)
                for (int j = i + 1; j < LK.Count; j++)

                    if (DieuKien_Gep(Convert.ToString(LK[i]), Convert.ToString(LK[j])))
                    {
                        kq.Add(gep(Convert.ToString(LK[i]), Convert.ToString(LK[j])));
                        
                    }
                        return kq;
        }
        public bool DieuKien_Gep(string a, string b)
        {
            int dem = 0;
           
            string[] temp1 = a.Split(',');
            int k = temp1.Length;
            string[] temp2 = b.Split(',');
            for (int i = 0; i < temp1.Length; i++)
                for (int j = 0; j < temp2.Length; j++)
                    if (temp1[i] == temp2[j])
                        dem++;
            if (dem == k - 1)
                return true;
            return false;


        }
        public string gep(string a, string b)
        {

            //tim ki tu cua b ko phai cua 
            //int dem = 0;
            //int k = a.Length;
            string[] temp1 = a.Split(',');
            string[] temp2 = b.Split(',');
            //string[] temp = new string[temp1.Length + 1];
            string temp=null;
            temp = b;
            for (int i = 0; i < temp1.Length; i++)
            {
             //   for (int j = 0; j < temp2.Length; j++)
                if(! kiemtra_tontai(temp1[i],temp2))
                    
                    {
                        /*   //temp=new string[temp1.Length+1];
                           for (int k = 0; k < temp.Length - 1; k++)
                               temp[k] = temp2[k];
                           temp[temp1.Length] = temp1[i];*/
                        temp = temp + "," + Convert.ToString(temp1[i]);
                        break;
                    }
            }

            return temp;
        }
        public int Tim_minsupp(string a)
        {
            //danh sach cot ung voi moi thuoc tinh

            int dem = 0;
            string[] temp = a.Split(',');
            int [] dscot=new int[temp.Length];
            int k=0;
            //tim thu tu cua cot chua thuoc tinh nay
            for(int i=0;i<temp.Length;i++)
                for(int cot=0;cot<NumAT;cot++)
                    if(temp[i]==A[0,cot])
                         dscot[k++]=cot;

             //tien hanh dem so lan suat hien cua thuoc tinh
             //dung mot mang tam de chua tac ca cac dong cot cua nhung thuoc tinh dang set
             string[,] temp2 = new string[row_num, temp.Length];
             for (int i = 0; i < dscot.Length; i++)
                 for (int j = 1; j < row_num; j++)
              
                     temp2[j,i] = A[j,Convert.ToInt16(dscot[i]) ];
             //string[,] temp3 = new string[row_num, 1];
             for (int i = 1; i < row_num; i++)
             {
                 int plustemp = 0;//bien de cong cac cot
                 for (int j = 0; j < dscot.Length; j++)
                 {
                     plustemp += Convert.ToInt16(temp2[i, j]);

                 }
                 if (plustemp == temp.Length)
                     dem++;
             }
             return dem;;
        }
        public bool kiemtra_tontai(string a,string []b)
        {
            for (int i = 0; i < b.Length;i++ )
                if(b[i]==a)
                return true;
        return false;
        }
        public ArrayList Loai_bo_trung(ArrayList A)
        {
            for (int m = 0; m < A.Count;m++ )
            {
                for (int n = 0; n < A.Count;n++)
                {
                    string st=null;
                    string st2=null;
                    if (m != n && m<A.Count)//m != A.Count)
                    {
                        st = Convert.ToString(A[m]);
                        st2 = Convert.ToString(A[n]);

                        string[] temp1 = st.Split(',');
                        string[] temp2 = st2.Split(',');
                        int dem = 0;
                        for (int i = 0; i < temp1.Length; i++)
                            for (int j = 0; j < temp2.Length; j++)
                                if (temp1[i] == temp2[j])
                                    dem++;
                        if (dem == temp1.Length )
                            A.Remove(st);
                    }
                }
            }
            return A;

        }

        public void GhiFile(ArrayList[] L,string filePath)
        {
            FileStream theFile = File.Open(filePath, FileMode.Create,
          FileAccess.Write);
            StreamWriter writer = new StreamWriter(theFile);          
            
            for(int i=1;i<L.Length;i++)
            {
                if (L[i] != null)
                {
                    writer.WriteLine("L(" + i.ToString()+"}: "+Convert.ToString(L[i].Count));
                    foreach (string st in L[i])
                    {
                        writer.Write(st + ": "+Convert.ToString(Tim_minsupp(st)) );
                        writer.WriteLine();
                    }
                    writer.WriteLine("");
                }
            }
            writer.Close();
            theFile.Close();
        }

        public string sort_att( string a)
        {
            string[] temp = a.Split(',');
            for (int i = 0; i < temp.Length; i++) 
                for(int j=i+1;j<temp.Length;j++)
                {
                    if(string.Compare(temp[i],temp[j])>0)
                    {
                        string temp2 = temp[i];
                        temp[i] = temp[j];
                        temp[j] = temp2;
                    }
                }
            string temp3=null;
            for (int i = 0; i < temp.Length; i++)
            {
                //temp3+=temp[i];
                if(i==0||i==temp.Length)
                temp3 = temp3 + temp[i];
                else
                temp3 = temp3 + "," + temp[i];
                
                    
            }
            a = temp3;
            return a;

        }
        public void sort(ref ArrayList[] A)
        {
           
            for (int i =0 ; i < A.Length; i++)
            {
                if(A[i]!=null)
                for (int j = 0; j < A[i].Count; j++)
                    A[i][j]=sort_att(Convert.ToString(A[i][j]));
            }
        }
        public void LoaiKetQuaTrung(ref ArrayList[] A)
        {

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != null)
                A[i] = Loai_bo_trung(A[i]);
            }
        }
        public void Chuan_hoa_Ve_0_1()
        {
            for (int i = 1; i < row_num; i++)//dong dau la thuoc tinh ko xet
                for (int j = 0; j < NumAT; j++)
                    if (Convert.ToInt16(A[i,j]) != 0)
                        A[i,j] = "1";

        }

    }
}

