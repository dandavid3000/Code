import java.io.*;

public class BufferedReader1
{
	public static void main(String args[])throws IOException
	{
		//char c;
		BufferedReader br = new BufferedReader
					(new InputStreamReader(System.in));
		System.out.print("Enter a string:");
		String str = br.readLine();
		System.out.println("You enter : " + str);
		
	}
}
