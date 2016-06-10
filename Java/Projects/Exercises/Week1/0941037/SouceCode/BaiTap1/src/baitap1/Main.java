/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package baitap1;

/**
 *
 * @author Dan
 */
import java.io.*;

public class Main {

    /**
     * @param args the command line arguments
     */
   public static void main(String[] args) throws IOException {
        int i; // Bien nay Ä‘á»ƒ dá»«ng khi háº¿t file


        BufferedReader a1;
        BufferedReader a2;


        BufferedWriter fw;

        try
        {
                fw = new BufferedWriter(new OutputStreamWriter(new FileOutputStream("a12.txt"),"Unicode"));
        }
        catch(IOException exc)
        {
                System.out.println("Error opening file");
                return ;
        }

        try
        {
                a1 = new BufferedReader(new InputStreamReader(new FileInputStream("a1.txt"),"utf-8"));
        }
        catch(FileNotFoundException exc)
        {
                System.out.println("File Not Found");
                return;
        }

          try
        {
                a2 = new BufferedReader(new InputStreamReader(new FileInputStream("a2.txt"),"utf-8"));

        }

        catch(FileNotFoundException exc)
        {
                System.out.println("File Not Found");
                return;
        }

        //Äá»c a1.txt vÃ  ghi vÃ o a12.txt
        do
        {
                i = a1.read();
                fw.write(i);

        }
        while(i != -1);

        do
        {
                i = a2.read();
                fw.write(i);

        }
        while(i != -1);

       a1.close();
       a2.close();
       fw.close();
    }
}
