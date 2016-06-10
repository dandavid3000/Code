/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Gui;

/**
 *
 * @author Asus
 */

import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.*;
import javax.sound.sampled.*;
import java.net.*;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.media.*;
import javax.swing.ImageIcon;
import sun.io.Converters;
public class Server implements Runnable {
     TargetDataLine line = null ;//line capture audio
     Vector<String[]> Nameclient=new Vector<String[]>();//ten nhung client ket vao
     Vector<sendvideo> Threadsendvideo= new Vector<sendvideo>();//nhung thread duoc tao ra phuc vu cho moi client khi ket vao
     Vector<captureaudio> Threadsendaudio =new Vector<captureaudio>();//nhung thread duoc tao ra cho moi client de truyen audio
    ByteArrayOutputStream out2;//capture audio
      ByteArrayOutputStream out ;//save sound current
    boolean running;//sound save alway
String name;
Thread t;
Time time;
String filename;
String directory;
MediaPlayer2 frame;//man hinh server

boolean audio=true;
 
///////////////////

	Server(String threadname,MediaPlayer2 f)///constructor
	{
              frame=f;
		name = threadname;
               t = new Thread(this, name);
               t.start();
	}

	public void run()
	{
           Recive_disconnet_Fromclient RD=new Recive_disconnet_Fromclient();//nhan yeu cau disconnet tu client
             int i=100;
            try
            {
                
                ServerSocket Mainservsock = new ServerSocket(222);//main serversocket dieu tiet ket noi giua client va server
               // ServerSocket  servsock = new ServerSocket(100);//audio serversocket
                    //new captureaudio(servsock);
                //new captureaudio(servsock);
                CreateLine();
                while(true){
                    Socket Ms=Mainservsock.accept();
                    ObjectInputStream ois = new ObjectInputStream(Ms.getInputStream());
                    String name=(String)ois.readObject();
                    Random generator = new Random();
                    int a = generator.nextInt(65000) + 1;//gan so random de phat biet cac client voi nhau
                    String temp[]=new String [2];
                    temp[0]= String.valueOf(a);
                    temp[1]=name;

                    if(!checkexist(temp)){
                    Nameclient.addElement(temp);
                    frame.loadclient(Nameclient);//load nhung client ket vao server ra man hinh
                    }
                    OutputStream os = Ms.getOutputStream();
                    ObjectOutputStream oos = new ObjectOutputStream(os);
                    oos.writeObject(i);
                    oos.writeObject(a);//gui lai cho client ID duoc server cap
                  
                  ServerSocket  svideo =new ServerSocket(i+1);//tao serversocket moi cho client ke tiep
                   ServerSocket  servsock = new ServerSocket(i);//audio serversocket
                   captureaudio threadsendaudio=new captureaudio(servsock,Integer.parseInt(temp[0]));
                    sendvideo threadsendvideo=new sendvideo( "bbb",svideo, Integer.parseInt(temp[0]));
                    // sendvideo(svideo);
                    Threadsendvideo.addElement(threadsendvideo);
                    Threadsendaudio.addElement(threadsendaudio);
                    i=i+2;
                    //Ms.close();
                }

   
            } 
        catch (ClassNotFoundException ex) {
            Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
        }
      
        catch (IOException ex)
            {
                System.err.print("loi khoi tao socket");
            }

	}
///////////////////////////////////////////


  

        ////Tao audio format
        private AudioFormat getFormat() {
    float sampleRate = 8000;
    int sampleSizeInBits = 8;
    int channels = 1;
    boolean signed = true;
    boolean bigEndian = true;
    return new AudioFormat(sampleRate,
      sampleSizeInBits, channels, signed, bigEndian);
  }//Tao audioformat de capture audio
        ///thread send video
        

      
       public boolean checkexist(String a[]){
           for(int i=0;i<Nameclient.size();i++){
               String b[]=(String[])Nameclient.get(i);
               if(b[0].equals(a[0]))
                   return true;
           }
           return false;
       }
       public void LoadClient(){
           for(int i=0;i<Nameclient.size();i++){
               
           }
       }

       /////////////////////class send video
       class sendvideo implements Runnable{//Thread lam nhiem vu send video cho client
          
           String name;
           int port;
           ServerSocket svideo;
           int ID;
           Thread T;
           boolean con=true;
           sendvideo(String threadname,ServerSocket s,int ID){
      
        name = threadname;
this.ID=ID;
		T = new Thread(this, name);
		//System.out.println("New thread: " + t);

               svideo=s;
		T.start();
    }
    public void run() {
               // capturevideo CTVDO =new capturevideo();

                while(true){
                    try {

                        Socket sock = svideo.accept();
                       while(con){
                    OutputStream os = sock.getOutputStream();
                    ObjectOutputStream oos = new ObjectOutputStream(os);
                     
                    Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
                    SystemWin win = new SystemWin();
                    Rectangle rect = new Rectangle(0, 0, screenSize.width, screenSize.height);
                    rect = win.getRectActiveWindow();
                    rect.setSize((int) rect.getWidth(),(int) rect.getHeight()-110);
                    Robot robot = new Robot();


                    BufferedImage image = robot.createScreenCapture(rect);
                   Image a = Toolkit.getDefaultToolkit().createImage(image.getSource());
                   ImageIcon imic =new ImageIcon(a);//chup hinh video
                   oos.writeObject(imic);//gui hinh cho client
                   oos.flush();
                   Thread.currentThread().sleep(80);//gui 24 hinh /s va hinh duoc load lien tuc ben client thanh video
                        }
                    } catch (InterruptedException ex) {
                        Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
                    }catch (AWTException ex) {
                        Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
                    }
                catch (IOException ex) {
                        System.err.print("loi khoi tao socket");
                    }
                }
            }




}
       ////disconnet mot client bang id
       public boolean disconnet(String id){//ham ngat ket noi cua mot client thong qua id cua client do
           boolean sussesvideo=false;
           if(Threadsendvideo!=null){
               for(int i=0;i<Threadsendvideo.size();i++){
                  if(Threadsendvideo.get(i).ID==Integer.parseInt(id))
                  {
                   Threadsendvideo.get(i).con=false;
                 
                   if(Remove_EL_NameClient(id)){
                   frame.loadclient(Nameclient);
                   sussesvideo = true;
                      }
                  }

               }

           }
            if(Threadsendaudio!=null){
               for(int i=0;i<Threadsendaudio.size();i++){
                  if(Threadsendaudio.get(i).ID==Integer.parseInt(id))
                  {
                   Threadsendaudio.get(i).cont=false;


                  }

               }

           }
           return false;
       }
public boolean Remove_EL_NameClient(String id){
    int i;
    for(i=0;i<Nameclient.size();i++){
        if(Nameclient.elementAt(i)[0].equals(id)){

         Nameclient.removeElementAt(i);
         return true;

        }

    }
   return false;
}
   class Recive_disconnet_Fromclient implements Runnable{//Thread lam nhiem vu lang nghe iu cau ngat ket noi cua client gui toi server
       Thread T;
       boolean cont=true;
public Recive_disconnet_Fromclient(){
    T=new Thread(this);
    T.start();
}
       public void run(){
            try {
                
                ServerSocket Mainservsock = new ServerSocket(333);
                while(cont){
                Socket Ms=Mainservsock.accept();//nhan iu cau disconnet tu server
                ObjectInputStream ois = new ObjectInputStream(Ms.getInputStream());
                String ID=(String)ois.readObject();
                disconnet(ID);
                }
            } catch (ClassNotFoundException ex) {
                System.err.print("loi khi nhan lenh ngat ket noi cua client");
            } catch (IOException ex) {
                System.err.print("loi khoi tao socket disconnet");
               
            }
       }
   }
   public void CreateLine(){
        final AudioFormat format = getFormat();
      DataLine.Info info = new DataLine.Info(
        TargetDataLine.class, format);

      Mixer.Info[] mixerInfo = AudioSystem.getMixerInfo();
      int i=0;


        for( i=0;i<mixerInfo.length;i++){


        try{



             Mixer mixer = AudioSystem.getMixer(mixerInfo[i]);//lay line de capture
             line = (TargetDataLine)mixer.getLine(info);
             line.open(format);
           line.start();
          System.err.print("  "+mixerInfo[i]+"   ");
           break;
          } catch(Exception e){

          }

      }
   }
class captureaudio implements Runnable{//captue audio va gui den cho client phat ra
    ServerSocket servsock;
    Thread T;
    boolean cont=true;
    int ID;
    public captureaudio(ServerSocket sv,int ID){
        servsock=sv;
        this.ID=ID;
        T=new Thread(this);
        T.start();
    }
    public void run(){
        /* final AudioFormat format = getFormat();
      DataLine.Info info = new DataLine.Info(
        TargetDataLine.class, format);
           
      Mixer.Info[] mixerInfo = AudioSystem.getMixerInfo();
      int i=0;
        TargetDataLine line = null ;

        for( i=0;i<mixerInfo.length;i++){
        

        try{
         
           
                   
             Mixer mixer = AudioSystem.getMixer(mixerInfo[i]);//lay line de capture
             line = (TargetDataLine)mixer.getLine(info);
             line.open(format);
           line.start();
          System.err.print("  "+mixerInfo[i]+"   ");
           break;
          } catch(Exception e){

          }

      }*/
        final AudioFormat format = getFormat();
         int bufferSize = (int)format.getSampleRate()
          * format.getFrameSize();
        byte buffer[] = new byte[bufferSize];
        if(line!=null)
        while(cont){
             out = new ByteArrayOutputStream();

              int count =
                line.read(buffer, 0, buffer.length);
              if (count > 0) {
                    try {
                        Socket sock;
                        sock = servsock.accept();
                        OutputStream os = sock.getOutputStream();
                        ObjectOutputStream oos = new ObjectOutputStream(os);
                        out.write(buffer, 0, count);
                        out.close();
                        oos.writeObject(out.toByteArray());//gui lien tuc nhung gi capture lai duoc cho client
                        oos.flush();
                        Thread.currentThread().sleep(40);
                    } catch (InterruptedException ex) {
                        Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
                    } catch (IOException ex) {
                        System.err.print("lost connect form clinet");
                        cont=false;
                    }
        }
    }
}
    }
}
