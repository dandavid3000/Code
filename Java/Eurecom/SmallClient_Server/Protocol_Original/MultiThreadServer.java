package web.crawler;

import java.io.IOException;
import java.io.PrintStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Scanner;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;


public class MultiThreadServer {
        
        public static String ERR_SVDOWN = "ERR : Cannot run the server, shut down the previous one!";

    
        public static Message createImageAnswer(String cmd, Message msg)
        {
            byte[] byteImg = Message.convertImageToByte();
            Message answerMessage = new Message();
            ArrayList<Object> content = new ArrayList();
            content.add(byteImg);

            answerMessage.createAnswerMessage(cmd, content);
            System.out.println(Message.SUC_CREATE_ANS_MESSAGE);
            return answerMessage;
        }
        public static Message analyseRequestMessage(Message msg)
        {
            //We first create a virable "result" to get the result and push it to the content
            //String result = null;
            String cmd = msg.getCmd();
            Message answerMessage = new Message();
            //Depend on the command, we analyse the the message and call the right function
            if (msg.getCmd().equals(Message.CMD_SEARCH))
            {
                //Call Marie's function for searching
                
            }
            
            if (msg.getCmd().equals(Message.CMD_DETAIL))
            {
                //Call Marie's function return the detail, give Marie CVID and return all the information
            }
            
            if (msg.getCmd().equals(Message.CMD_STATISTIC))
            {
                //Set cmd for the answer message to sent back to the client
                answerMessage = createImageAnswer(cmd, msg);

            }
            
//            byte[] byteImg = Message.convertImageToByte();
//            
//            answerMessage.createAnswerMessage(cmd, byteImg);
            
            return answerMessage;
        }
	public static void main(String[] args){
		try {
			ServerSocket server = new ServerSocket(1234);
			System.out.println("Server has been created successfully and running!");
			
			while (true){ //Allow a client to connect
                            //Use multithread
                            //If a client asks to connect, then accept it
                            new ThreadSocket(server.accept()).start();
                        }
                        
		} catch (IOException e) {
			// TODO Auto-generated catch block
			//.printStackTrace();
                        System.out.println(ERR_SVDOWN);
		}
		
		
	}
}
