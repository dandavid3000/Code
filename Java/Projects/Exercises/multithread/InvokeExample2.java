import javax.swing.SwingUtilities;



public class InvokeExample2
{
	final static Runnable doHelloWorld = new Runnable() {
     public void run() {
         System.out.println("Hello World on " + Thread.currentThread());
     }
 	};
	
	public static void main(String args[])
	{
	
		Thread appThread = new Thread() {
	     	public void run() 
	     	{
		         try 
		         {
		             SwingUtilities.invokeAndWait(doHelloWorld);
		         }
		         catch (Exception e) 
		         {
		             e.printStackTrace();
		         }
		         System.out.println("Finished on " + Thread.currentThread());
     		}
 		};
 	
 		appThread.start();
	}

}
