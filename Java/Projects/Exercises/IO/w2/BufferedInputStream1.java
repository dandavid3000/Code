import java.io.*;

public class BufferedInputStream1 {
	public static void main(String[] args) {
		try 
		{
			BufferedInputStream bin = new BufferedInputStream
										(new FileInputStream("a.txt"));
			
			BufferedOutputStream bout = new BufferedOutputStream
											(System.out);
			while (true) {
				int datum = bin.read();
				if (datum == -1)
					break;
				bout.write(datum);
			}
			bout.flush();
		}
		catch (Exception e) {
			e.printStackTrace();
		}
	}
} 
