import javax.swing.SwingUtilities;

public class InvokeExample1
{
	public static void main(String args[])
	{
		Runnable doHelloWorld = new Runnable() {
	     public void run() {
	         System.out.println("Hello World on " + Thread.currentThread());
	     }
		};
	
		SwingUtilities.invokeLater(doHelloWorld);
		System.out.println("This might well be displayed before the other message.");
	
	}

}
