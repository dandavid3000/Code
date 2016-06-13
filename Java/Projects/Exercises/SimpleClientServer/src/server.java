
import java.io.IOException;
import java.net.ServerSocket;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Dan
 */
public class server {
    public static void main(String[] args)
    {
        try{
            ServerSocket svSocket = new ServerSocket(1234);
            System.out.println("Server has been created successfully!");
            
            while(true)
            {
                new MultiThread(svSocket.accept()).start();
            }
            
            
        }catch(IOException e){
        
            System.err.println("Cannot create server!");
        }
    }
    
}
