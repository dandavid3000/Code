class Utilities1 {
	synchronized void call1(String msg) {
	//void call(String msg) {
		System.out.print("[" + msg);
		try 
		{
			Thread.sleep(1000);
		} 
		catch(InterruptedException e) {
			System.out.println("Interrupted");
		}
		System.out.println("]");
	}
	
	synchronized void call2(String msg) {
	//void call(String msg) {
		System.out.print("{" + msg);
		try 
		{
			Thread.sleep(1000);
		} 
		catch(InterruptedException e) {
			System.out.println("Interrupted");
		}
		System.out.println("}");
	}
}

class Caller implements Runnable {
	String msg;
	Utilities1 target;
	Thread t;
	
	public Caller(Utilities1 targ, String s) {
		target = targ;
		msg = s;
		t = new Thread(this);
		t.start();
	}

	public void run() {
		target.call1(msg);
		target.call2(msg);
	}
}

class Synchronization1 {
	public static void main(String args[]) {
		
		Utilities1 target1 = new Utilities1();
		//Utilities1 target2 = new Utilities1();
		//Utilities1 target3 = new Utilities1();
		
		Caller ob1 = new Caller(target1, "Hello");
		Caller ob2 = new Caller(target1, "Synchronized");
		Caller ob3 = new Caller(target1, "World");
		
		//////////////////////////////////////////////////

		try {
			ob1.t.join();
			ob2.t.join();
			ob3.t.join();
		} catch(InterruptedException e) {
			System.out.println("Interrupted");
		}
		
	}
}