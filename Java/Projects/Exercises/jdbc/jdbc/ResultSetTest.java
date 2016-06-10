import java.sql.*;

public class ResultSetTest
{
	public static void main(String args[])
	{
		Connection con=null;
		try
		{
			Class.forName("sun.jdbc.odbc.JdbcOdbcDriver");
			con = DriverManager.getConnection("jdbc:odbc:studentsql");
			if (con!=null)
			{
				Statement stmt = con.createStatement();
				ResultSet rs = stmt.executeQuery("select * FROM student");
				//int rowcount = stmt.executeUpdate("insert into student(studentid, studentname) values (1002,'New Student')");
				//int rowcount = stmt.executeUpdate("delete student where studentid>500");
				//System.out.println("Record Affected:" + rowcount);
				
				while (rs.next())
				{
					System.out.println("StudentID: " + rs.getInt(1));
					System.out.println("StudentName: " + rs.getString(2));
				}
	
				System.out.println("Connected To SQL Server 2005");
				stmt.close();
				con.close();
				
			}
			
			
			//...

		}
		catch (SQLException se)
		{
			System.out.println(se);
		}
		catch (Exception ex)
		{
			System.out.println(ex);
		}
	}
}
