import java.io.*;

public class ReadWriteData 
{
	public static void main(String args[]) throws IOException 
	{
		//File a = new File("a.txt");
		
		
		/*
		DataOutputStream of;
		try
		{
			of = new DataOutputStream(new FileOutputStream("so1.bin"));
		}
		catch (IOException ex)
		{
			System.out.println("File cannot be opened");
			return;
		}
		
		try
		{
			of.writeInt(10);
			of.writeDouble(61.61);
			of.writeDouble(12.78);
			of.writeDouble(178.3);
			of.writeDouble(16546.4);
			of.writeDouble(1.765);
			of.writeDouble(105.6);
			of.writeDouble(31.7);
			of.writeDouble(671.8);
			of.writeDouble(8781.9);
			of.writeDouble(27.045);
			
		}
		catch (IOException ex)
		{
			System.out.println("Cannot write to file !");
			return;
		}
		
		of.close();	
		*/
		
		/*
		DataOutputStream of;
		try
		{
			of = new DataOutputStream(new FileOutputStream("so.bin"));
		}
		catch (IOException ex)
		{
			System.out.println("File cannot be opened");
			return;
		}
		
		try
		{
			of.writeInt(10);
			of.writeDouble(1.1);
			of.writeDouble(1.2);
			of.writeDouble(1.3);
			of.writeDouble(1.4);
			of.writeDouble(1.5);
			of.writeDouble(1.6);
			of.writeDouble(1.7);
			of.writeDouble(1.8);
			of.writeDouble(1.9);
			of.writeDouble(2.0);
			
		}
		catch (IOException ex)
		{
			System.out.println("Cannot write to file !");
			return;
		}
		
		of.close();	
		*/
		
		/*
		DataInputStream ifs;
		
		try {
			ifs = new DataInputStream(new FileInputStream("so1.bin"));
		}
		catch(IOException exc) 
		{
			System.out.println("Error open file.");
			return;
		}
		double data[] = new double[10];
		try 
		{
			int t;
			t = ifs.readInt();
			System.out.println(t);
			int i;
			
			for (i=0;i<10;i++)
			{
				double d;
				d = ifs.readDouble();
				data[i] = d;
				//System.out.println(d + " ");
			}
		}
		catch(IOException exc) 
		{
			System.out.println("Error reading file.");
		}
		
		ifs.close();
		
		int i,j;
		for (i=0;i<9;i++)
			for (j=i+1;j<10;j++)
				if (data[i]>data[j])
				{
					double temp;
					temp = data[i];
					data[i] = data[j];
					data[j] = temp;
				}
		
		for (i=0;i<10;i++)
			System.out.println(data[i]);
		*/
	
		/*
		int iVal = 25678;
		double dVal = -67.76;
		boolean bVal = true;
		
		
		
		
		DataOutputStream dos;
		try 
		{
			dos=new DataOutputStream(
					new FileOutputStream("a.txt"));
		}
		catch(IOException exc) 
		{
			System.out.println("Error open file !");
			return;
		}
		
		try 
		{
			dos.writeInt(iVal);
			dos.writeDouble(dVal);
			dos.writeBoolean(bVal);
		}
		catch(IOException exc) 
		{
			System.out.println("Error write file.");
		}
		dos.close();
		
		*/
		
		
		int iVal = 0;
		double dVal = 0;
		boolean bVal = false;
		DataInputStream dis;
		
		try {
			dis = new DataInputStream(new FileInputStream("a.txt"));
		}
		catch(IOException exc) 
		{
			System.out.println("Error open file.");
			return;
		}
		try 
		{
			iVal = dis.readInt();
			System.out.println("Reading " + iVal);
			dVal = dis.readDouble();
			System.out.println("Reading " + dVal);
		
			
			bVal = dis.readBoolean();
			System.out.println("Reading " + bVal);
		}
		catch(IOException exc) 
		{
			System.out.println("Error reading file.");
		}
		
		dis.close();
		
		
	}
}
