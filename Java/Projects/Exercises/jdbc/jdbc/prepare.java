try {
	String sql = "INSERT INTO my_table (col_string) VALUES(?)";
	PreparedStatement pst = con.prepareStatement(sql);
    
	for (int i=0; i<10; i++) 
	{
		pst.setString(1, "row "+i);
    
		pst.executeUpdate();
	}
} 
catch (SQLException e) 
{
}
