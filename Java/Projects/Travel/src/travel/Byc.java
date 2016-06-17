/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package travel;

/**
 *
 * @author Dan
 */
public class Byc extends Verhicle{
    
    Byc(int day,int km)
    {
        this.setPrice(60000);
        this.setDay(day);
        this.setKm(km);
    }
    
    @Override public int Total()
    {
        int tt=0;
        tt = this.getPrice()*this.getDay();
        return tt;
    }
    
    
}
