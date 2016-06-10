/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package baitap2;

/**
 *
 * @author Dan
 */
import java.io.*;
public class TaoFileDat {
    public static void main(String[] args){

        try {

            DataOutputStream dos = new DataOutputStream(new 		 	  FileOutputStream("num.dat"));

            //Ghi cÃ¡c sá»‘ vÃ o file dat
            dos.writeInt(6);
            dos.writeInt(1);
            dos.writeInt(5);
            dos.writeInt(2);
            dos.writeInt(9);
            dos.writeInt(5);
            dos.writeInt(6);
            dos.close();

        }

        catch(IOException ioe)
        {
        }

}



}
