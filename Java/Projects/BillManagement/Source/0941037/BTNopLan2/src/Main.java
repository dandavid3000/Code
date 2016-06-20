//Ho Ten : Vo Huynh Dan
//MSSV : 0941037

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Dan
 */
import javax.swing.*;
import java.awt.*;
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
              
        frmMain frame = new frmMain();
        JFrame.setDefaultLookAndFeelDecorated(true);
        JDialog.setDefaultLookAndFeelDecorated(true);

        //Create and set up the window.
       // JFrame frame1 = new JFrame("Phần mềm quản lý phiếu thu");
      //  frame1.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);


        //Display the window.
        frame.pack();
        frame.setVisible(true);
            }
        });
    }

}
