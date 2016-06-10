package web.crawler;

import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.io.Serializable;
import javax.imageio.ImageIO;

/**
 * Created by Dan on 3/22/15.
 */


//Message format

/**
    CMD Options Values
 *  CMD : A string of command, for example : search, detail, stats
 * search : search with keywords
 * detail : clients send CVE-ID and get back all information
 * stats : -> Images 
 *  Options and Values ArrayLists, 
 *      "Options" contains names 
 *      "Values" contains values respectively 
 * RequestMessage 
 * AnswerMessage
 */


public class Message implements Serializable {

    public static String KEY_SRC = "myKey";
   
    public static String PIC_SRC = "test2.png";
    public static String PIC_DES = "clonetest2.png";
    public static String ERR_CMD = "Message command is empty";
    public static String ERR_CMD2 = "Wrong message command";
    
    public static String SUC_CREATE_REQ_MESSAGE = "The request message is created ";
    public static String SUC_CREATE_ANS_MESSAGE = "The answer message is created ";
    
    public static String OPTION_KEY_WORDS = "keywords";
    public static String OPTION_DATE = "date";
    public static String OPTION_SCORE = "score";
    public static String OPTION_NUMBER = "number";
    public static String OPTION_SYSTEM = "system";
    public static String OPTION_FILE_BIN = "filebin";
    public static String OPTION_FILE_XML = "filexml";


    public static String CMD_SEARCH = "search";
    public static String CMD_STATISTIC = "stat";
    public static String CMD_DETAIL = "detail";

    public static String RESULT_SEARCH = "resultSearch";
    public static String RESULT_STATISTIC = "resultStat";
    public static String RESULT_DETAIL = "resultDetail";


    private String cmd;
    private ArrayList<Object> content;
    //private String content;
    //private byte[] imageByte;
    private ArrayList<String> options;
    private ArrayList<String> values;
    

   
    //Get value of cmd
    public String getCmd() {
        return cmd;
    }
    //Get value of content
    public ArrayList<Object> getContent() {
        return content;
    }
    // Get value of imageByte;
//    public byte[] getImageByte(){
//        return imageByte;
//    }
    //Get value of Options    

    public ArrayList<String> getOptions() {
        return options;
    }
    
   //Get value of values
    public ArrayList<String> getValues() {
        return values;
    } 
    
    //Set value for cmd
    public void setCmd(String cmd) {
        this.cmd = cmd;
    }
    
    //Set value for content
    public void setContent(ArrayList<Object> content) {
        this.content = content;
    }
    //Set value for imageByte
//    public void setImageByte(byte[] imageByte)
//    {
//        this.imageByte = imageByte;
//    }
    
    //set values for options
    public void setOptions(ArrayList<String> options) {
        this.options = options;
    }

    //Set values for values
    public void setValues(ArrayList<String> values) {
        this.values = values;
    }
    
    //Constructors
    
    public Message(ArrayList<Object> content){
        this.content = content;
    }
    
    public Message()
    {
        this.cmd = null;
        this.content = null;
        this.options = null;
        this.values = null;
        
    }
    
    public  Message(String cmd, ArrayList<String> options , ArrayList<String> values){
             
        this.cmd = cmd;
        this.options = options;
        this.values = values;
        
    }
    
    //Create a request message for clients
    public void createRequestMessage(String cmd, ArrayList<String> options, ArrayList<String> values)
    {
        this.cmd = cmd;
        this.options = options;
        this.values = values;
        
    }
    
    //Create an answer for server to send to the client
    public void createAnswerMessage(String cmd, ArrayList<Object> content){
        this.content = content;
        this.cmd = cmd;
    }
    
//    public void createAnswerMessage(String cmd, byte[] imageByte){
//        this.cmd = cmd;
//        this.imageByte = imageByte;
//    }
    
    
    
    public ArrayList<Object> parseMessage(Message msg)
    {
        //TODO Parse the message
        return msg.content;
    }
    
//    public void ReadMessage() {
//        
//        String result = null;
//               
//        if (cmd.equals(CMD_SEARCH))
//        {
//            //Call the function to run the query and give back the xml file
//            result = "return search";
//        }
//        
//        if (cmd.equals(CMD_DETAIL))
//        {
//            //Call the function to run the query and give back the xml file
//            result = "return detail";
//        }
//        
//        if (cmd.equals(CMD_STATISTIC))
//        {
//            //Call the function to run and give back the image (binary)
//            result = "return statistics";
//        }
//        
//        this.content = result;
//        
//    }
    
     public static byte[] convertImageToByte(){
            byte[] imgByte = null;

            try {
                BufferedImage img = ImageIO.read(new File(PIC_SRC));
                
                try (ByteArrayOutputStream baos = new ByteArrayOutputStream()) {
                    ImageIO.write(img, "png", baos);
                    baos.flush();
                    imgByte = baos.toByteArray();
                }
                
            } catch (IOException e) {
			// TODO Auto-generated catch block
                        System.out.println("Image can't not be found!");
		}
            
            System.out.println("Image has been converted successfully!");

            return imgByte;
        }
        
        //a function to convert a string byte to an image
        public static void convertByteToImage(byte[] imgByte){
            
            if (imgByte != null){
            
            InputStream inStream = new ByteArrayInputStream(imgByte);
            try {
                BufferedImage img = ImageIO.read(inStream);
                
                ImageIO.write(img, "png", new File(PIC_DES));
                System.out.println("Image has been created successfully!");

                
            } catch (IOException e) {
			// TODO Auto-generated catch block
                        System.out.println("Image cannot be created!");
		}
            }
            
            else System.out.print("Image cannot be created!");
        }
    
    
}
