/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * MailSchedule.java
 *
 * Created on Oct 30, 2010, 9:12:11 PM
 */

package javamail;

import java.io.*;
import java.net.Socket;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.*;
import java.util.*;
import java.text.*;



/**
 *
 * @author Dan
 */
public class MailSchedule extends javax.swing.JFrame {

    /** Creates new form MailSchedule */
    public MailSchedule() {
        initComponents();
        ButtonGroup buttonGroup = new ButtonGroup();
        buttonGroup.add(rdNgay);
        buttonGroup.add(rdThang);
       
        txtNgay.setEnabled(true);
        txtThang.setEnabled(false);
    }
    public int GetMailSv()
    {
            int k =0;
            String sentMessage = "";
            String receivedMessage = "";

            try {
            Socket s = new Socket(Login.SvAd, 110);
            InputStream is = s.getInputStream();
            BufferedReader br = new BufferedReader(new InputStreamReader(s.getInputStream(), "UTF8"));
            BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(s.getOutputStream(),"UTF8"));

            String us = Login.NormalUser;
            String pw = Login.NormalPass;

            receivedMessage=br.readLine();

            sentMessage="user "+us+"";
            bw.write(sentMessage);
            bw.newLine();
            bw.flush();
            receivedMessage=br.readLine();

            sentMessage="";
            sentMessage="pass "+pw+"";
            bw.write(sentMessage);
            bw.newLine();
            bw.flush();
            receivedMessage=br.readLine();

            String []ST= receivedMessage.split(" ");
            k = Integer.parseInt(ST[4]);

            sentMessage="Quit";
            bw.write(sentMessage);
            bw.newLine();
            bw.flush();

            br.close();
            bw.close();
            s.close();


        }
            catch (IOException e)
            {
        }
                // note cho nay
             return k;
    }
    public void ScheduleFile() throws FileNotFoundException, UnsupportedEncodingException, IOException
    {
        

         int k =0;
         k=ReceiveMail.nMail;
         
         int temp1 = GetMailSv();
         if(temp1==0)
             k=0;
         if(temp1<ReceiveMail.nMail)
             k=temp1;
         
         String filetempOldMailServer = Login.NormalUser+"TempOldMailServer.txt";
         File f = new File(filetempOldMailServer);
         if (f.exists())
             f.delete();

         String tempt = ""+k;
         BufferedWriter fwt;
         fwt = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(filetempOldMailServer),"UTF-8"));
         fwt.write(tempt);
         fwt.close();

        //Lay ngay thang nam hien tai
        int day,month,year;
      
        Date now = new Date();
        SimpleDateFormat sdf = new SimpleDateFormat("dd MM yyyy");
        String d = sdf.format(now);
        String []temp= d.split(" ");

        day = Integer.parseInt(temp[0]);
        month = Integer.parseInt(temp[1]);
        year= Integer.parseInt(temp[2]);

        BufferedWriter fw;
        fw = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(Login.NormalUser+"Schedule.txt"),"UTF-8"));


        if(rdNgay.isSelected())
        {
           day = day + Integer.parseInt(txtNgay.getText().toString());

           //Kiem tra ngay toi da cua mot thang

           int tempDay = 0;
           if(month==1)
               tempDay = 31;
            if(month==2)
               tempDay = 28;
            if(month==3)
               tempDay = 31;
            if(month==4)
               tempDay = 30;
            if(month==5)
               tempDay = 31;
            if(month==6)
               tempDay = 30;
            if(month==7)
               tempDay = 31;
            if(month==8)
               tempDay = 31;
            if(month==9)
               tempDay = 30;
            if(month==10)
               tempDay = 31;
            if(month==11)
               tempDay = 30;
            if(month==12)
               tempDay = 31;

            //neu nhu vuot qua so ngay gioi than thi tinh lai ngay va tang thang len 1
            while(day>tempDay)
            {
                day = day - tempDay;
                month++;
            }

            while(month>12)
            {
                month = month - 12;
                year++;
            }

            //Tao mot chuoi moi gom ngay thang nam hen de ghi vao file
            String nString = day+" "+month+" "+year;
            fw.write(nString);
            fw.write("\r\nSoNgay "+txtNgay.getText().toString());

        }

        if(rdThang.isSelected())
        {

            String sMonth = txtThang.getText().toString();
            int tempMonth = Integer.valueOf(sMonth);

            month = month + tempMonth;
            while(month>12)
            {
                month = month - 12;
                year++;
            }

            int tempDay = 0;
            if(month==1)
               tempDay = 31;
            if(month==2)
               tempDay = 28;
            if(month==3)
               tempDay = 31;
            if(month==4)
               tempDay = 30;
            if(month==5)
               tempDay = 31;
            if(month==6)
               tempDay = 30;
            if(month==7)
               tempDay = 31;
            if(month==8)
               tempDay = 31;
            if(month==9)
               tempDay = 30;
            if(month==10)
               tempDay = 31;
            if(month==11)
               tempDay = 30;
            if(month==12)
               tempDay = 31;

            //neu nhu vuot qua so ngay gioi than thi tinh lai ngay va tang thang len 1
            while(day>tempDay)
            {
                day = day - tempDay;
                month++;
            }

            while(month>12)
            {
                month = month - 12;
                year++;
            }
            
            //Tao mot chuoi moi gom ngay thang nam hen de ghi vao file
            String nString = day+" "+month+" "+year;
            fw.write(nString);
            fw.write("\r\nSoThang "+txtThang.getText().toString());
        }

        fw.close();
        //Sau khi da check xong thi ta da co 1 file schedule de biet duoc ngay ma chung ta can kiem tra mail
    }

    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabel2 = new javax.swing.JLabel();
        rdNgay = new javax.swing.JRadioButton();
        rdThang = new javax.swing.JRadioButton();
        txtNgay = new javax.swing.JTextField();
        txtThang = new javax.swing.JTextField();
        jLabel1 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        jButton1 = new javax.swing.JButton();
        jToggleButton1 = new javax.swing.JToggleButton();
        jLabel5 = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Thiết lập kiểm tra thư định kỳ");
        addWindowListener(new java.awt.event.WindowAdapter() {
            public void windowActivated(java.awt.event.WindowEvent evt) {
                formWindowActivated(evt);
            }
        });

        jLabel2.setFont(new java.awt.Font("Tahoma", 1, 36)); // NOI18N
        jLabel2.setForeground(new java.awt.Color(0, 204, 51));
        jLabel2.setText("Kiểm tra thư định kỳ");

        rdNgay.setSelected(true);
        rdNgay.setText("Ngày");
        rdNgay.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mousePressed(java.awt.event.MouseEvent evt) {
                rdNgayMousePressed(evt);
            }
        });

        rdThang.setText("Tháng");
        rdThang.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mousePressed(java.awt.event.MouseEvent evt) {
                rdThangMousePressed(evt);
            }
        });

        txtThang.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txtThangActionPerformed(evt);
            }
        });

        jLabel1.setText("Chọn \"Ngày\" thì sau bao nhiêu ngày sẽ kiểm tra thư 1 lần");

        jLabel4.setText("Chọn \"Tháng\" thì sau bao nhiêu tháng sẽ kiểm tra thư 1 lần");

        jButton1.setText("Cài đặt");
        jButton1.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                jButton1MouseClicked(evt);
            }
        });

        jToggleButton1.setFont(new java.awt.Font("Tahoma", 1, 11));
        jToggleButton1.setForeground(new java.awt.Color(255, 0, 0));
        jToggleButton1.setText("Hủy lập lịch");
        jToggleButton1.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                jToggleButton1MouseClicked(evt);
            }
        });

        jLabel5.setFont(new java.awt.Font("Tahoma", 1, 24)); // NOI18N
        jLabel5.setForeground(new java.awt.Color(255, 0, 0));
        jLabel5.setText("Theo ngày, tháng");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel2)
                .addContainerGap())
            .addGroup(layout.createSequentialGroup()
                .addGap(20, 20, 20)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jLabel4)
                    .addComponent(jLabel1)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(rdNgay)
                            .addComponent(txtNgay, javax.swing.GroupLayout.PREFERRED_SIZE, 79, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(30, 30, 30)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(txtThang, javax.swing.GroupLayout.PREFERRED_SIZE, 83, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(rdThang, javax.swing.GroupLayout.DEFAULT_SIZE, 93, Short.MAX_VALUE))
                        .addGap(35, 35, 35)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(jButton1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(jToggleButton1))))
                .addGap(53, 53, 53))
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap(102, Short.MAX_VALUE)
                .addComponent(jLabel5)
                .addGap(97, 97, 97))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel2)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jLabel5)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 21, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(rdNgay)
                            .addComponent(rdThang))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(txtNgay, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(txtThang, javax.swing.GroupLayout.PREFERRED_SIZE, 20, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(26, 26, 26))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jToggleButton1)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(jButton1)
                        .addGap(25, 25, 25)))
                .addComponent(jLabel1)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jLabel4)
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void formWindowActivated(java.awt.event.WindowEvent evt) {//GEN-FIRST:event_formWindowActivated
        // TODO add your handling code here:
        
    }//GEN-LAST:event_formWindowActivated

    private void rdNgayMousePressed(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_rdNgayMousePressed
        // TODO add your handling code here:
            txtNgay.setEnabled(true);
            txtThang.setEnabled(false);

    }//GEN-LAST:event_rdNgayMousePressed

    private void rdThangMousePressed(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_rdThangMousePressed
        // TODO add your handling code here:
        txtNgay.setEnabled(false);
        txtThang.setEnabled(true);
    }//GEN-LAST:event_rdThangMousePressed

    public void CancelSchedule()
    {
        String fileName = Login.NormalUser+"Schedule.txt";
        // A File object to represent the filename
        File f = new File(fileName);

        // Make sure the file or directory exists and isn't write protected
        if (!f.exists())
          System.out.print("File không tồn tại");

        if (!f.canWrite())
          System.out.print("File ko đọc được");

        // If it is a directory, make sure it is empty
        if (f.isDirectory()) {
          String[] files = f.list();
          if (files.length > 0)
            System.out.print("Không tồn tại đường dẫn");
        }

        // Attempt to delete it
        boolean success = f.delete();

        if (!success)
          JOptionPane.showMessageDialog(null,"Hủy lập lịch thành công !");
    }
    private void jButton1MouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_jButton1MouseClicked
        try {
            // TODO add your handling code here:
            ScheduleFile();
            JOptionPane.showMessageDialog(null,"Bạn đã thiết lập thành công thời gian kiểm tra mail !");
            this.setVisible(false);
            
        } catch (FileNotFoundException ex) {
            Logger.getLogger(MailSchedule.class.getName()).log(Level.SEVERE, null, ex);
        } catch (UnsupportedEncodingException ex) {
            Logger.getLogger(MailSchedule.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(MailSchedule.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_jButton1MouseClicked

    private void txtThangActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtThangActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_txtThangActionPerformed

    private void jToggleButton1MouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_jToggleButton1MouseClicked
        // TODO add your handling code here:
        CancelSchedule();
    }//GEN-LAST:event_jToggleButton1MouseClicked

    /**
    * @param args the command line arguments
    */
    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new MailSchedule().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButton1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JToggleButton jToggleButton1;
    private javax.swing.JRadioButton rdNgay;
    private javax.swing.JRadioButton rdThang;
    private javax.swing.JTextField txtNgay;
    private javax.swing.JTextField txtThang;
    // End of variables declaration//GEN-END:variables

}
