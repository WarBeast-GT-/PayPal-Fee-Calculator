using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayPal_Fee_Calculator
{
    public class Fee_Calculate
    {
        private double price_vendor;
        private double price_pay;
        private double fee;

        public void calculateFee()
        {
            fee = Math.Round((price_pay * 0.0249) + 0.35, 2);
        }

        public void calculatePricePay()
        {
            price_pay = Math.Round((price_vendor + 0.35) / 0.9751, 2);
        }

        public void calculatePriceVendor()
        {
            price_vendor = Math.Round(price_pay - (price_pay * 0.0249 + 0.35), 2);
        }

        public void calculatePricePayFromFee()
        {
            price_pay = Math.Round((fee - 0.35) / 0.0249, 2);
        }

        public void setPricePay(double price_pay)
        {
            this.price_pay = price_pay;
        }

        public void setPriceVendor(double price_vendor)
        {
            this.price_vendor = price_vendor;
        }

        public void setFee(double fee)
        {
            this.fee = fee;
        }

        public double getFee()
        {
            return fee;
        }

        public double getPricePay()
        {
            return price_pay;
        }

        public double getPriceVendor()
        {
            return price_vendor;
        }        
    }
}