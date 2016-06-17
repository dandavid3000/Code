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
public class EByc extends Verhicle{

    public int getChargingPrice() {
        return chargingPrice;
    }

    public void setChargingPrice(int chargingPrice) {
        this.chargingPrice = chargingPrice;
    }

    public int getMaxKm() {
        return maxKm;
    }

    public void setMaxKm(int maxKm) {
        this.maxKm = maxKm;
    }
    private int chargingPrice;
    private int maxKm;
    
    EByc(int day, int km )
    {
        this.setKm(km);
        this.setDay(day);
        this.setPrice(80000);
        this.setChargingPrice(10000);
        this.setMaxKm(10);
    }
    
    @Override public int Total()
    {
        int tt=0;
        tt = this.getPrice()*this.getDay() + this.getChargingPrice()*round(this.getKm()/this.getMaxKm());
        return tt;
    }
}
