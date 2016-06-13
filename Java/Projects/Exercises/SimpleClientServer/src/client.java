
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Dan
 */
public class client {
    public static void main(String[] args)
    {
        BufferedReader fromSv =null;
        BufferedWriter  toSv = null;
        BufferedReader stdIn = null;
        try{
            Socket clientSocket = new Socket("localhost",1234);
            System.out.println("Client has been created successfully!");

            fromSv = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
            toSv= new BufferedWriter (new OutputStreamWriter(clientSocket.getOutputStream()));
            stdIn = new BufferedReader(new InputStreamReader(System.in));
          
            while(true)
            {
                String input, output;
                output = stdIn.readLine();
                //System.err.println(output);
                if(output.equals("quit"))
                {
                    toSv.write("quit");
                    toSv.newLine();
                    toSv.flush();
                    toSv.close();
                    fromSv.close();
                    clientSocket.close();
                    break;
                }
                else{
                    toSv.write(output);
                    toSv.newLine();
                    toSv.flush();
                    input = fromSv.readLine();
                    System.out.println(input);
                }
                
               
                
               
            }
           
            
            
            
        }catch(IOException e)
        {
            //System.out.println("Cannot create connection");
        }
        

    }
        
}
