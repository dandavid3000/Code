package web.crawler;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.net.Socket;
import java.io.*;
import java.util.logging.Level;
import java.util.logging.Logger;



/**
 *
 * @author Dan
 */
public class ThreadSocket extends Thread{
    
    Socket socket = null;
    
    
    public ThreadSocket(Socket socket){
        
        this.socket = socket;
    }
    
    @Override
    public void run(){
        try {
            ObjectInputStream fromClient = new ObjectInputStream(socket.getInputStream());
            //Receive from clients
            ObjectOutputStream toClient = new ObjectOutputStream(socket.getOutputStream());
            //Send to clients
            
            
                //Create a new message to prepare getting the message from client
                Message requestMsg = new Message();
               
                try {
                    requestMsg = (Message) fromClient.readObject();
                } catch (ClassNotFoundException ex) {
                    Logger.getLogger(ThreadSocket.class.getName()).log(Level.SEVERE, null, ex);
                }
               
                //Print the result 
                System.out.println(requestMsg.getCmd());
                System.out.println(requestMsg.getOptions());
                System.out.println(requestMsg.getValues());

                //Read the message and then modify the content
                
                Message answerMsg = new Message();
                answerMsg = MultiThreadServer.analyseRequestMessage(requestMsg);
                
                //Send it back to the client
                toClient.writeObject(answerMsg);
                
                toClient.close();
                fromClient.close();
                socket.close();
             
        } catch (IOException ex) {
            Logger.getLogger(ThreadSocket.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
