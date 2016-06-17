/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package travel;

import java.util.*;

/**
 *
 * @author Dan
 */
public class Travel {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Scanner in = new Scanner(System.in);
        System.err.println("How many vehicles do you wanna hire?: ");
        int number = in.nextInt();
        
        ArrayList<Verhicle> listVerhicle = new ArrayList();
        
        for(int i=0; i<number;++i)
        {
            System.out.println("Verhicle No "+i);
            System.out.println("1. Car; 2. Byc; 3. EByc");
            System.out.print("Your choice: ");
            int temp = in.nextInt();
             int day, km;
            System.out.print("How many days ? ");
            day = in.nextInt();
            System.out.print("How far ? ");
            km = in.nextInt();
            
            if(temp==1)
            {                
                Verhicle v = new Car(day,km);
                listVerhicle.add(v);
                
            }
            if(temp == 2)
            {
                Verhicle v = new Byc(day,km);
                listVerhicle.add(v);
            }
            
            if(temp == 3)
            {
                Verhicle v = new EByc(day,km);
                listVerhicle.add(v);
            }
            
            int total=0;
            for(int j=0;j<listVerhicle.size();++j)
            {
                total = total + listVerhicle.get(j).Total();
            }
            
            
            System.err.println("Total fees: "+total);
            
        }
        
    }
    
}
