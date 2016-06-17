/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package travel;

import static java.lang.Math.round;

/**
 *
 * @author Dan
 */
public class Car extends Verhicle{
    private int helmetPrice;
    private int petrolPrice;
    private int maxKm;


    public int getHelmetPrice() {
        return helmetPrice;
    }

    public void setHelmetPrice(int helmetPrice) {
        this.helmetPrice = helmetPrice;
    }

    public int getPetrolPrice() {
        return petrolPrice;
    }

    public void setPetrolPrice(int petrolPrice) {
        this.petrolPrice = petrolPrice;
    }

    public int getMaxKm() {
        return maxKm;
    }

    public void setMaxKm(int maxKm) {
        this.maxKm = maxKm;
    }
    
    Car(int day, int km){
       this.setDay(day);
       this.setKm(km);
       this.setPrice(120000);
       this.setHelmetPrice(20000);
       this.setMaxKm(8);
       this.setPetrolPrice(13500);
    }
    
    @Override public int Total()
    {   
        int tt=0;
        tt = this.getPrice()*this.getDay()+this.getHelmetPrice()+this.getPetrolPrice()*round((this.getKm()/this.getMaxKm()));
        return tt;
    }
}
