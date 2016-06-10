/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * MediaPlayer2.java
 *
 * Created on Nov 11, 2010, 10:58:05 AM
 */

package Gui;


import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Component;
import java.awt.FileDialog;
import java.awt.Font;
import java.awt.FontMetrics;

import java.awt.Graphics;



import java.awt.event.*;
import java.awt.image.BufferedImage;
import java.io.*;
import java.util.*;
import javax.imageio.ImageIO;
import javax.media.*;
import javax.swing.*;



public class MediaPlayer2 extends  JDialog implements ActionListener,
                                           ControllerListener,
                                           ItemListener {
    int curentvideo=0;//neu ko co lua chon thi video phat dau tien la video 0//so thu tu dc danh tu 0
 FileDialog fd;
    public Component vc,cc;
    boolean loop=false;
   boolean first=true;
    public String currentDirectory;
   public Player player;
   long i=0;
Server sv;
    Vector<String> ListLink=new Vector<String>();
    public MediaPlayer2(String title) {

//       super(title);
       
            initComponents();
            
            String[]b=new String[2];
          
           
            CMN_Open.addActionListener(this);
            CMN_Exit.addActionListener(this);
            PN_VIDEO.setLayout(new BorderLayout());
            PN_VIDEO.setSize(400,400);
            this.setSize(400,550);
             setTitle("JMF");
             setAlwaysOnTop(true);
             setResizable(false);
             this.btn_disconnet.setEnabled(false);
             this.btn_share.setEnabled(false);
             this.btn_play.setEnabled(false);
            setVisible(true);
           
          
    }

   public void actionPerformed (ActionEvent e)
    {
      
            if (e.getActionCommand().equals("Exit")) {
                dispose();
                return;
            }
            fd = new FileDialog(this, "Open File", FileDialog.LOAD);
            fd.setDirectory(currentDirectory);
            fd.show();
            if (fd.getFile() == null) {
                return;
            }
            currentDirectory = fd.getDirectory();
           String link=fd.getDirectory()+fd.getFile();
           ListLink.addElement(link);
           loadlistvideo();
           this.btn_play.setEnabled(true);
         /*   try {
                player = Manager.createPlayer(new MediaLocator("file:" + fd.getDirectory() + fd.getFile()));
            } catch (java.io.IOException e2) {
                System.out.println(e2);
                return;
            } catch (NoPlayerException e2) {
                System.out.println("Could not find a player.");
                return;
            }
            if (player == null) {
                System.out.println("Trouble creating a player.");
                return;
            }
            first = false;
           
           
            player.addControllerListener(this);
            player.prefetch();*/
         
            

   }
////////////////////////////////////////
 public void controllerUpdate (ControllerEvent e)
   {
      this.setSize(400,550);
      System.out.print(i++);
     // if(vc!=null)
     //   try {
     //       getScreenShot(this);
     //   } catch (IOException ex) {
    //      System.out.print("loi component");
    //    }


      if (e instanceof ControllerClosedEvent)
      {
          if (vc != null)
          {
              remove (vc);
              vc = null;
          }

          if (cc != null)
          {
              remove (cc);
              cc = null;
          }

          return;
      }

      if (e instanceof EndOfMediaEvent)
      {
         // if (loop)
          if(curentvideo+1<ListLink.size())
          {
                try {
                    
                    player = Manager.createPlayer(new MediaLocator("file:" + ListLink.elementAt(++curentvideo)));
                  player.addControllerListener(this);
                  player.prefetch();
                } catch (IOException ex) {
                    System.err.print("coudnt create player ");
                } catch (NoPlayerException ex) {
                     System.err.print("or file not found");
                }

          }
           else{
                try {
                    curentvideo = 0;
                    player = Manager.createPlayer(new MediaLocator("file:" + ListLink.elementAt(+curentvideo)));
                     player.addControllerListener(this);
                  player.prefetch();
                } catch (IOException ex) {
                     System.err.print("coudnt create player ");
                } catch (NoPlayerException ex) {
                   System.err.print("or file not found");
                }
           }

          return;
      }

      if (e instanceof PrefetchCompleteEvent)
      {
          player.start ();
          return;
      }

      if (e instanceof RealizeCompleteEvent)
      {
          if(cc!=null && vc!=null){
            PN_VIDEO.remove(cc);
            PN_VIDEO.remove(vc);
          }
                vc = player.getVisualComponent();
                cc = player.getControlPanelComponent();
             
                    PN_VIDEO.add(cc, BorderLayout.SOUTH);
              
                    PN_VIDEO.add(vc);
              
                pack();
               
            } 
      }
   
 
   ///////////////////////////////////////


      public void itemStateChanged (ItemEvent e)
   {
      loop = !loop;
   }

     

   public void update (Graphics g)
   {
      paint (g);
   }
   
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        btn_disconnet = new javax.swing.JButton();
        btn_exit = new javax.swing.JButton();
        btn_share = new javax.swing.JButton();
        PN_VIDEO = new javax.swing.JPanel();
        jScrollPane2 = new javax.swing.JScrollPane();
        listvideo = new javax.swing.JList();
        jLabel2 = new javax.swing.JLabel();
        btn_play = new javax.swing.JButton();
        lblstatus = new javax.swing.JLabel();
        btn_remove = new javax.swing.JButton();
        btn_addfile1 = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        ListViwer = new javax.swing.JList();
        jMenuBar1 = new javax.swing.JMenuBar();
        jMenu1 = new javax.swing.JMenu();
        CMN_Open = new javax.swing.JMenuItem();
        CMN_Exit = new javax.swing.JMenuItem();

        setDefaultCloseOperation(javax.swing.WindowConstants.DO_NOTHING_ON_CLOSE);
        setResizable(false);

        btn_disconnet.setFont(new java.awt.Font("Tahoma", 1, 11));
        btn_disconnet.setText("Disconnect");
        btn_disconnet.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                btn_disconnetMouseClicked(evt);
            }
        });

        btn_exit.setFont(new java.awt.Font("Tahoma", 1, 11));
        btn_exit.setText("Exit");
        btn_exit.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                btn_exitMouseClicked(evt);
            }
        });

        btn_share.setFont(new java.awt.Font("Tahoma", 1, 11));
        btn_share.setText("Share");
        btn_share.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                btn_shareMouseClicked(evt);
            }
        });

        javax.swing.GroupLayout PN_VIDEOLayout = new javax.swing.GroupLayout(PN_VIDEO);
        PN_VIDEO.setLayout(PN_VIDEOLayout);
        PN_VIDEOLayout.setHorizontalGroup(
            PN_VIDEOLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 422, Short.MAX_VALUE)
        );
        PN_VIDEOLayout.setVerticalGroup(
            PN_VIDEOLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 340, Short.MAX_VALUE)
        );

        jScrollPane2.setViewportView(listvideo);

        jLabel2.setText("Các video");

        btn_play.setFont(new java.awt.Font("Tahoma", 1, 11));
        btn_play.setText("Play");
        btn_play.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                btn_playMouseClicked(evt);
            }
        });

        lblstatus.setFont(new java.awt.Font("Tahoma", 1, 11));
        lblstatus.setText("Status share");

        btn_remove.setFont(new java.awt.Font("Tahoma", 1, 11));
        btn_remove.setText("Remove");
        btn_remove.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                btn_removeMouseClicked(evt);
            }
        });

        btn_addfile1.setFont(new java.awt.Font("Tahoma", 1, 11));
        btn_addfile1.setText("Add video");
        btn_addfile1.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                btn_addfile1MouseClicked(evt);
            }
        });

        jLabel1.setText("Các client");

        ListViwer.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                ListViwerMouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(ListViwer);

        jMenu1.setText("File");

        CMN_Open.setText("Open");
        jMenu1.add(CMN_Open);

        CMN_Exit.setText("Exit");
        jMenu1.add(CMN_Exit);

        jMenuBar1.add(jMenu1);

        setJMenuBar(jMenuBar1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(PN_VIDEO, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(btn_exit, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(btn_share, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(btn_play, javax.swing.GroupLayout.PREFERRED_SIZE, 75, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(10, 10, 10)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel2)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 77, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                    .addComponent(lblstatus, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                    .addComponent(btn_remove, javax.swing.GroupLayout.DEFAULT_SIZE, 80, Short.MAX_VALUE)
                                    .addComponent(btn_addfile1))))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 71, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 80, Short.MAX_VALUE)
                            .addComponent(btn_disconnet))))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addComponent(PN_VIDEO, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addGap(38, 38, 38)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(lblstatus, javax.swing.GroupLayout.PREFERRED_SIZE, 29, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(btn_addfile1)
                        .addGap(17, 17, 17)
                        .addComponent(btn_remove))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jLabel1)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 103, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jLabel2)
                        .addGap(6, 6, 6)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(btn_play)
                                .addGap(16, 16, 16)
                                .addComponent(btn_share)
                                .addGap(18, 18, 18)
                                .addComponent(btn_exit))
                            .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 103, javax.swing.GroupLayout.PREFERRED_SIZE))))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(btn_disconnet)
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void btn_exitMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_btn_exitMouseClicked
        // TODO add your handling code here:
        System.exit(0);
    }//GEN-LAST:event_btn_exitMouseClicked

    private void btn_shareMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_btn_shareMouseClicked
        // TODO add your handling code here:
 sv=new Server("abc",this);
 this.btn_disconnet.setEnabled(true);
 lblstatus.setText("Enable Share");
    }//GEN-LAST:event_btn_shareMouseClicked

    private void ListViwerMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_ListViwerMouseClicked
        // TODO add your handling code here:

    }//GEN-LAST:event_ListViwerMouseClicked

    private void btn_disconnetMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_btn_disconnetMouseClicked
        // TODO add your handling code here:
        if(ListViwer.getSelectedIndex()!=-1){
            String temp=(String)ListViwer.getSelectedValue();
            String ID=temp.split("-")[1];
            sv.disconnet(ID);
        }
    }//GEN-LAST:event_btn_disconnetMouseClicked

    private void btn_playMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_btn_playMouseClicked
        // TODO add your handling code here:
        if(cc!=null)
     PN_VIDEO.remove(cc);
       if(vc!=null)
     PN_VIDEO.remove(vc);

           
            if (player != null) {
                player.close();
            }
            try {
                if(listvideo.getSelectedIndex()!=-1){
                    // player = Manager.createPlayer(new MediaLocator("file:" + fd.getDirectory() + fd.getFile()));
                   String temp=(String)listvideo.getSelectedValue();
                     player = Manager.createPlayer(new MediaLocator("file:" + temp ));
                }
                else{
                    if(ListLink!=null)
                    player = Manager.createPlayer(new MediaLocator("file:" + ListLink.elementAt(0) ));
                }
            } catch (java.io.IOException e2) {
                System.out.println(e2);
                return;
            } catch (NoPlayerException e2) {
                System.out.println("Could not find a player.");
                return;
            }
            if (player == null) {
                System.out.println("Trouble creating a player.");
                return;
            }
            first = false;


            player.addControllerListener(this);
            player.prefetch();
            this.btn_share.setEnabled(true);
    }//GEN-LAST:event_btn_playMouseClicked

    private void btn_removeMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_btn_removeMouseClicked
        // TODO add your handling code here:
        String link=(String)listvideo.getSelectedValue();
        ListLink.removeElement(link);
        loadlistvideo();
    }//GEN-LAST:event_btn_removeMouseClicked

    private void btn_addfile1MouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_btn_addfile1MouseClicked
        // TODO add your handling code here:
         fd = new FileDialog(this, "Open File", FileDialog.LOAD);
            fd.setDirectory(currentDirectory);
            fd.show();
            if (fd.getFile() == null) {
                return;
            }
            currentDirectory = fd.getDirectory();
           String link=fd.getDirectory()+fd.getFile();
           ListLink.addElement(link);
           loadlistvideo();
           this.btn_play.setEnabled(true);
    }//GEN-LAST:event_btn_addfile1MouseClicked

    public JPanel GetPN()
    {
        return PN_VIDEO;

    }
    /////////load list video
    public void loadlistvideo(){

DefaultListModel model = new DefaultListModel();
 listvideo=new JList(model);
 if(ListLink!=null){


         for(int i=0;i<ListLink.size();i++){

            model.addElement(ListLink.elementAt(i));
         }
       }
        else {
            model.clear();
        }


jScrollPane2.setViewportView(listvideo);



   }
    /////////////////////
   public void loadclient( Vector a){

DefaultListModel model = new DefaultListModel();
 ListViwer=new JList(model);
 if(a!=null){
        String temp[]=new String[a.size()];
       
         for(int i=0;i<a.size();i++){
            String  temp2[]=(String[])a.elementAt(i);
           // model.add(temp2[1]);
            model.addElement(temp2[1]+"-"+temp2[0]);
         }
       }
        else {
            model.clear();
        }
        
       
jScrollPane1.setViewportView(ListViwer);

//ListViwer=L;
          // ListViwer.setModel(list);

   }
    public static void main(String args[]) {
        System.out.print("abc");
        MediaPlayer2 mediaPlayer2 = new MediaPlayer2("JMF");
              //  new Cunstom();
          
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JMenuItem CMN_Exit;
    private javax.swing.JMenuItem CMN_Open;
    private javax.swing.JList ListViwer;
    private javax.swing.JPanel PN_VIDEO;
    private javax.swing.JButton btn_addfile1;
    private javax.swing.JButton btn_disconnet;
    private javax.swing.JButton btn_exit;
    private javax.swing.JButton btn_play;
    private javax.swing.JButton btn_remove;
    private javax.swing.JButton btn_share;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JLabel lblstatus;
    private javax.swing.JList listvideo;
    // End of variables declaration//GEN-END:variables

}
