
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.Socket;


/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Dan
 */
public class MultiThread extends Thread {
   
    Socket socket = null;
    
    public MultiThread(Socket socket)
    {
        this.socket = socket;
    }
    
    @Override 
    public void run()
    {
        try{
            BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            BufferedWriter out = new BufferedWriter (new OutputStreamWriter(socket.getOutputStream()));
            
        while(true)
        {
            String input, output;
            
            input = in.readLine();
            //System.out.println(input);
            
            if(input.equals("quit"))
            {
                System.out.println("Client connection is closed!");
                break;
            }
            else{
                output = "Server >> "+input;
                out.write(output);       
                out.newLine();
                out.flush();
            }
            
            
        }
        } catch(IOException e)
        {
            System.err.println("Connection is closed");
        }
        
        
    }
       
}
