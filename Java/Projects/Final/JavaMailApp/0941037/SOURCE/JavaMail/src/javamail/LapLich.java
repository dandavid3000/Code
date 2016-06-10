/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package javamail;

import java.io.*;
import java.io.IOException;
import java.net.Socket;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;

/**
 *
 * @author KimLong
 */
public class LapLich implements Runnable {
    Thread T;
    int time;
    Login Lg;
    boolean cont = true;
    public LapLich(int time,Login LG){
        Thread T=new Thread(this);
        this.time=time;
        this.Lg=LG;
        T.start();
    }
    public void run(){
       
            try {
                while(cont)
                {
                   int n =0;
                   n = nMail();
                   
                   JOptionPane.showMessageDialog(null, "Bạn có " +n+ " thư mới !");
                   Thread.currentThread().sleep(time*1000);
                }
                
        } catch (UnsupportedEncodingException ex) {
            Logger.getLogger(LapLich.class.getName()).log(Level.SEVERE, null, ex);
        } catch (FileNotFoundException ex) {
            Logger.getLogger(LapLich.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(LapLich.class.getName()).log(Level.SEVERE, null, ex);
        } catch (InterruptedException ex) {
               
            }

    }
    public int GetMailSv()
    {
            int k =0;
            String sentMessage = "";
            String receivedMessage = "";

            try {
            Socket s = new Socket(Login.SvAd, 110);
            InputStream is = s.getInputStream();
            BufferedReader br = new BufferedReader(new InputStreamReader(s.getInputStream(), "UTF8"));
            BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(s.getOutputStream(),"UTF8"));

            String us = Login.NormalUser;
            String pw = Login.NormalPass;

            receivedMessage=br.readLine();

            sentMessage="user "+us+"";
            bw.write(sentMessage);
            bw.newLine();
            bw.flush();
            receivedMessage=br.readLine();

            sentMessage="";
            sentMessage="pass "+pw+"";
            bw.write(sentMessage);
            bw.newLine();
            bw.flush();
            receivedMessage=br.readLine();

            String []ST= receivedMessage.split(" ");
            k = Integer.parseInt(ST[4]);

            sentMessage="Quit";
            bw.write(sentMessage);
            bw.newLine();
            bw.flush();

            br.close();
            bw.close();
            s.close();


        }
            catch (IOException e)
            {
        }
                // note cho nay
             return k;
    }
    
     public int nMail() throws UnsupportedEncodingException, FileNotFoundException, IOException
    {
            int soMail;
            int soMailCu;

            String filetempOldMailServer = Login.NormalUser+"TempOldMailServer.txt";
            BufferedReader rd1;
            rd1 = new BufferedReader(new InputStreamReader(new FileInputStream(filetempOldMailServer),"UTF-8"));
            soMailCu = Integer.parseInt(rd1.readLine());
            rd1.close();


            soMail = GetMailSv();

            if(soMailCu<soMail)
                return soMail-soMailCu;
            return 0;
        
    }
}

 

