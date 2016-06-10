package web.crawler;

import java.io.IOException;
import java.net.UnknownHostException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.net.ssl.SSLSocket;
import javax.net.ssl.SSLSocketFactory;
        
public class Client {
                public static void analyseAnswerMessage(Message answerMsg)
                {
                    //Analyse the message from the server,
                    //Depends on the cmd, we can determine the values 
                    String cmd = answerMsg.getCmd();
                   // System.out.println(cmd);
                    if (cmd == null)
                    {
                        System.out.println(Message.ERR_CMD);
                    }
                    
                    else if (cmd.equals(Message.RESULT_SEARCH)){
                        //show GUI for search
                        //Call Huy's function
                        ArrayList<Object> resultContent = new ArrayList();
                        resultContent = answerMsg.getContent();
                        String kq = (String)resultContent.get(0);
                        System.out.println(kq);
                    }
                    
                    else if (cmd.equals(Message.RESULT_DETAIL)){
                        //show GUI for detail of a specific record
                        //Call Huy's function
                        
                    }
                    
                    else if (cmd.equals(Message.RESULT_STATISTIC)){
                        //show picture
                        //Use a function to convert binary to image
                        ArrayList<Object> resultContent = new ArrayList();
                        resultContent = answerMsg.getContent();
                        byte[] imgByte = (byte[])resultContent.get(0);
                        Message.convertByteToImage(imgByte);
                        
                        //Call Huy's function to load Image
                    }
                    
                    else System.out.print(Message.ERR_CMD2);
                   
                }
                
                public static Message createRequestMessage(String cmd, ArrayList<String> options, ArrayList<String> values)
                {
                    Message requestMsg = new Message(cmd,options,values);
                    System.out.println(Message.SUC_CREATE_REQ_MESSAGE);
                    return requestMsg;
                }
                
		public static void main(String[] args){
                        SSLSocket sslClient = null;
                        try {
                                System.setProperty("javax.net.ssl.trustStore", Message.KEY_SRC);

				SSLSocketFactory sslSocketFactory = (SSLSocketFactory)SSLSocketFactory.getDefault();
                                sslClient = (SSLSocket)sslSocketFactory.createSocket("LocalHost",1234);
                                    
                                //sslClient.setEnabledCipherSuites(sslClient.getSupportedCipherSuites());
                                
                                //Socket client = new Socket("LocalHost",1234);
				System.out.println("Client has been created successfully!");
				
                                ObjectOutputStream outputStream = new ObjectOutputStream(sslClient.getOutputStream());
                                ObjectInputStream inputStream = new ObjectInputStream(sslClient.getInputStream());
                                
                                //Create a temporary data to tests
                                String cmd ="stat";
                                ArrayList<String> options = new ArrayList();
                                ArrayList<String> values = new ArrayList();
                                
                                options.add("keyword");
                                options.add("year");
                                options.add("system");
                                
                                values.add("Stuxnet");
                                values.add("2014");
                                values.add("windows");
                                
                                //Create a msg with constructors
                                Message msg = createRequestMessage(cmd, options, values);
                                                 
                                //Push the message to server
                                outputStream.writeObject(msg);
                                
                                //Get back the message from server
                                Message answerMsg = new Message();
                                try {
                                    answerMsg = (Message) inputStream.readObject();
                                } catch (ClassNotFoundException ex) {
                                    Logger.getLogger(MultiThreadServer.class.getName()).log(Level.SEVERE, null, ex);
                                }
                                
                                //Print out the content from the server
                               // System.out.println(answerMsg.getContent());
                                
                                analyseAnswerMessage(answerMsg);
                               // Message.convertByteToImage(answerMsg.getImageByte());
                                
                                outputStream.close();
                                inputStream.close();
				sslClient.close();
				
			} catch (UnknownHostException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
                               //  System.out.println("Cannot receive the message from server");
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
                             //   System.out.println("Cannot connect to the server");
			}
			
		}

}
