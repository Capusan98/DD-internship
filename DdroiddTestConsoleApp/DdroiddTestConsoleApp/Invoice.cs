using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdroiddTestConsoleApp
{
    public class Invoice
    {
        private double subTotal;
        private double shipping;
        private double vat;
        private double total;

        private double keyboardDiscount;
        private int shippingDisctount;
        private double threePackDiscount;

        //Getters
        public double GetSubtotal() { return subTotal; }
        public double GetShipping() { return shipping; }
        public double GetVAT() { return vat; }
        public double GetTotal() { return total; }
        public double GetShippinDiscount() { return shippingDisctount; }
        public double GetKeyboardDiscount() { return keyboardDiscount; }
        public double GetThreePackDiscount() { return threePackDiscount; }
        //Constructor
        //sets totals, fees and discounts to 0 initially
        //computes in this orded: Subtotal/Shipping->VAT->Discounts->Total
        //stores values in class fields
        public Invoice(ShoppingCart shoppingCart)
        {
            subTotal = 0;
            shipping = 0;
            vat = 0;
            total = 0;
            keyboardDiscount = 0;
            shippingDisctount = 0;
            threePackDiscount = 0;
            for (int i = 0; i < shoppingCart.getList().Count(); i++)
            {
                subTotal = subTotal + (shoppingCart.getList()[i].GetItemPrice() * shoppingCart.GetProductCount(shoppingCart.getList()[i]));
                shipping = shipping + (ShippingRate.getRateForCountry(shoppingCart.getList()[i].GetItemShippedCountry()) * (shoppingCart.GetProductCount(shoppingCart.getList()[i]) * shoppingCart.getList()[i].GetItemWeight() / 0.1));
            }
           
            ComputeVat();//1st
            ApplyDiscounts(shoppingCart);//2nd
            ComputeTotal();//3rd
        }
        //customizable discounts applied 
        private void ApplyDiscounts(ShoppingCart shoppingCart)
        {
            keyboardDiscount = DiscountItem(shoppingCart, "Keyboard", 10);
            subTotal = subTotal - keyboardDiscount;
            shippingDisctount = ApplyShippingDiscount(shoppingCart, 2, 10);
            threePackDiscount= ThreePackDiscount(shoppingCart, "Monitor", "Desk Lamp", 50);
            subTotal = subTotal - threePackDiscount;
        }

        void ComputeVat()
        {
            vat = (subTotal / 100) * 19;
        }

        void ComputeTotal()
        {
            total = subTotal + shipping + vat;
        }

        //returns a given percentage of the itemprice * the number of that items in the cart  
        double DiscountItem(ShoppingCart shoppingCart,string itemName,double discountPergentage)
        {
           
            double discount = 0;

            try
            {
                if (shoppingCart.GetProductCountByString(itemName) > 0)
                {

                    discount = ((shoppingCart.GetProductCountByString(itemName) * shoppingCart.productCatalog.GetProductByName(itemName).GetItemPrice()) / 100) * discountPergentage;

                }
            }
            catch (Exception e) {
                return discount;
            }
            
            return discount;
        }
        //applies a discount on the shipping for a minimum number of items aquired
        int ApplyShippingDiscount(ShoppingCart shoppingCart,int minimumNumberOfItems, double ammountDiscounted)
        {
            int totalItems=0;
           
            //for is needed because .Count() will not show multiplicated items
            for (int i = 0; i < shoppingCart.getList().Count; i++)
            {
                totalItems += shoppingCart.GetProductCount(shoppingCart.getList()[i]);
                
            }
            if (totalItems >= minimumNumberOfItems)
            {

                shipping = shipping - ammountDiscounted;
                if (shipping < 0)
                {
                    shipping = 0;
                }
                return 1;
            }
            else return 0;
        }
        //returns returns a given percentage of the discounted items * minimum(the number of that items in the cart or discounts awarded in threepack)
        private double ThreePackDiscount(ShoppingCart shoppingCart, string item1,string itemDiscounted,double percentageDiscounted)
        {
            double discount = 0;
            try
            {
                int item1Count = shoppingCart.GetProductCountByString(item1);
                int itemDiscountedCount = shoppingCart.GetProductCountByString(itemDiscounted);
                item1Count = item1Count / 2;//nr of aquuired discounts
                if (itemDiscountedCount > item1Count) { itemDiscountedCount = item1Count; }//get the smaller number(not giving discount to 3 desk lamps is only 4 monitors were bought/ not discounting 2 desk lamps if only 1 was bought)
                discount = (double)itemDiscountedCount * (shoppingCart.productCatalog.GetProductByName(itemDiscounted).GetItemPrice() / 100) * percentageDiscounted;
            }
            catch(Exception e)
            {
                return discount;
            }
            return discount;
        }
        //return a string of the whole invoice (totals fees and discounts)
        public string InvoiceString()
        {
           
            string result = "";
            result = "Subtotal:" + subTotal.ToString() + "\n" +
                "Shipping:" + shipping.ToString() + "\n" +
                "VAT:" + vat.ToString() + "\n" +
                "Total:" + total.ToString() + "\n";
            if(keyboardDiscount!=0 || shippingDisctount!=0 || threePackDiscount != 0)
            {
                result += "\nDiscounts:\n";
                if(keyboardDiscount != 0)
                {
                    result += "10% off keyboards:-$" + keyboardDiscount.ToString() + "\n";
                }
                if (shippingDisctount != 0)
                {
                    result += "10 off shipping:-$10\n";
                }
                if (threePackDiscount != 0)
                {
                    result += "50% desk lamps:-$" + threePackDiscount.ToString() + "\n";
                }
            }
            return result;
        }
    }
}
