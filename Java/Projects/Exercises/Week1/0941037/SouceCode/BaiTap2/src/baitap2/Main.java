/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package baitap2;
import java.io.*;

/**
 *
 * @author Dan
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

         try{
            //Doc file va in ra
            DataInputStream dis = new DataInputStream(new FileInputStream("num.dat"));

            int n;
            n = dis.readInt();

            int[] a = new int[n+1];
            a[0] = n;
            for (int i=1; i<a.length; i++)
                a[i] = dis.readInt();

            //Sap xep mang truyen thong

            for (int i=0; i<a.length; i++)
                for(int j=i; j<a.length; j++)
                    if(a[i]>a[j])
                    {
                        int temp = a[j];
                        a[j] = a[i];
                        a[i] = temp;
                    }

            //In ra man hinh
            for (int i=0; i<a.length; i++)
                {
                    int k = a[i];
                    System.out.print(k);
                    System.out.print(" ");

                }

            BufferedWriter fw;
            try
                {
                        fw = new BufferedWriter(new OutputStreamWriter(new FileOutputStream("num.txt"),"Unicode"));
                        for (int i=0; i<a.length; i++)
                        {
                           //Chuyen sang chuoi de ghi vao file text
                          String str = Integer.toString(a[i]);

                          fw.write(str);
                          fw.write(" ");
                        }
                }
                catch(IOException exc)
                {
                        System.out.println("Error opening file");
                        return ;
                }

                 fw.close();
                 dis.close();

        }
        catch(IOException ioe)
        {
        }
    }
}

