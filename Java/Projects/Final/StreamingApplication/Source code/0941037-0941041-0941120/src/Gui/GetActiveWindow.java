package Gui;
import com.sun.java.swing.plaf.windows.resources.windows;
import com.sun.jna.Native;
import com.sun.jna.Pointer;
import com.sun.jna.platform.win32.GDI32;
import com.sun.jna.platform.win32.User32;
import com.sun.jna.win32.StdCallLibrary;
import java.awt.AWTException;
import java.awt.Dimension;
import java.awt.Rectangle;
import java.awt.Robot;
import java.awt.Toolkit;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import javax.imageio.ImageIO;



//Tạo lớp User32API như sau:
 interface User32API
        extends StdCallLibrary {

    public static interface WNDENUMPROC
            extends com.sun.jna.win32.StdCallLibrary.StdCallCallback {

        public abstract boolean callback(Pointer hWnd, Pointer hWnd1);
    }
    public static final User32API INSTANCE = (User32API) Native.loadLibrary("user32", User32API.class);
	//Hàm này dùm lấy hWnd của active window
	public abstract Pointer GetForegroundWindow();

	//Hàm này lấy Rect ra:
	public abstract boolean GetWindowRect(Pointer hWnd, GDI32.RECT rect);
}
//Tạo lớp SystemWin như sau:
  class SystemWin {
	private static final User32API api;
	public SystemWin() {
	}
	public Rectangle getRectActiveWindow() {
       
             Pointer hWnd = User32.INSTANCE.FindWindow(null, "JMF").getPointer();//lay handle cua cua so JMF cua so phat video

        GDI32.RECT rect = (GDI32.RECT) GDI32.RECT.newInstance(GDI32.RECT.class);
        api.GetWindowRect(hWnd, rect);
        return rect.toRectangle();

    }
	static {
        api = User32API.INSTANCE;

    }
        /////////////////////
        //ham main
        public static void main(String args[]) throws AWTException, IOException, InterruptedException
    {
           long i=0;
             while(true){
            Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
            SystemWin win = new SystemWin();
            Rectangle rect = new Rectangle(0, 0, screenSize.width, screenSize.height);
            rect = win.getRectActiveWindow();
            Robot robot = new Robot();


            BufferedImage image = robot.createScreenCapture(rect);

            File file;
           
            file = new File("screen"+i+".png");
            i++;
            ImageIO.write(image, "png", file);
            Thread.currentThread().sleep(4);
        }
    }
}

