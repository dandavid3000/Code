/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Dan
 */
import java.sql.*;
import javax.swing.*;


public class database {

public Object[][] DuLieu;
public int n; //Số dòng dữ liệu trong CSDL;
//    pubic void Search(String strsql)
//    {
//
//    }
    public int CheckConnect()
        {
            Connection con = null;
             try
               {
                Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
                    con = DriverManager.getConnection("jdbc:sqlserver://"+frmMain.sv+":1433;databaseName="+frmMain.dt+";user="+frmMain.us+";password="+frmMain.pw+"");
                                    if(con!=null)
                                        return 1;
                }
              catch(Exception e)
               {
                   JOptionPane.showMessageDialog(new JFrame(), "Sai thông tin đăng nhập", "Lỗi đăng nhập", JOptionPane.ERROR_MESSAGE);
                   e.printStackTrace();
                   System.out.println("Sai thông tin đăng nhập : " + e.getMessage());
               }
             return 0;
        }
    public void IUD(String strsql){
        Connection con = null;
        try
           {
               	Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            	con = DriverManager.getConnection("jdbc:sqlserver://"+frmMain.sv+":1433;databaseName="+frmMain.dt+";user="+frmMain.us+";password="+frmMain.pw+"");
				if(con!=null)
               	System.out.println("Kết nối thành công !");
                Statement pb = con.createStatement();
             
                pb.executeUpdate(strsql);
               

        }
        catch(Exception e)
           {
               JOptionPane.showMessageDialog(new JFrame(), "Sai dữ liệu khi nhập !", "Lỗi dữ liệu", JOptionPane.ERROR_MESSAGE);
               e.printStackTrace();
               System.out.println("Sai thông tin đăng nhập : " + e.getMessage());
           }

    }
    public Object[][] ConnectDatabase(String strsql)
    {
    //JDBC Driver for MS SQL Server 2005
        DuLieu= new Object[50][50];
    Connection con = null;
            try
           {
                
               	Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
                con = DriverManager.getConnection("jdbc:sqlserver://"+frmMain.sv+":1433;databaseName="+frmMain.dt+";user="+frmMain.us+";password="+frmMain.pw+"");
				if(con!=null)
               		System.out.println("Kết nối thành công");
                Statement LoadPhieuThu = con.createStatement();
                ResultSet rs = null;
                rs = LoadPhieuThu.executeQuery(strsql);
              
                int i =0;
                while(rs.next())
                {
                    DuLieu[i][0] = rs.getInt("MaPT");
                    DuLieu[i][1] = rs.getDate("NgayThu");
                    DuLieu[i][2] = rs.getInt("SoTien");
                    DuLieu[i][3] = rs.getString("LyDoThu");
                    DuLieu[i][4] = rs.getString("GhiChu");
                    i++;
                    n = i;  
                }
                
           }
           catch(Exception e)
           {
               JOptionPane.showMessageDialog(new JFrame(), "Sai dữ liệu khi nhập !", "Lỗi sai dữ liệu ", JOptionPane.ERROR_MESSAGE);
               e.printStackTrace();
               System.out.println("Sai thông tin đăng nhập : " + e.getMessage());
           }
return DuLieu;

    }


}
