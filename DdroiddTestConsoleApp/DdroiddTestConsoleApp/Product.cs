using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdroiddTestConsoleApp
{
    public class Product
    {
        private string itemName;
        private double itemPrice;
        private CountryCodes shippingCountry;
        private double weight;

        //Constructor
        public Product(string itmN,double itmP, CountryCodes sC,double we)
        {
            itemName = itmN;
            itemPrice = itmP;
            shippingCountry = sC;
            weight = we;
        }

        //Getters
        public string GetItemName() { return itemName; }
        public double GetItemPrice() { return itemPrice; }
        public CountryCodes GetItemShippedCountry() { return shippingCountry; }
        public double GetItemWeight() { return weight; }

        //Setters
        public void SetItemName(string newItemName) { itemName = newItemName; }
        public void SetItemPrice(double newItemPrice) { itemPrice = newItemPrice; }
        public void SetShippingCountry(CountryCodes newShippingCountry) { shippingCountry = newShippingCountry; }
        public void SetWeight(double newWeight) { weight = newWeight; }

        //ToStringShort is a string just with the name and price w/o shipping country and weight
        public string ToStringShort() { return " | " + AlingString(itemName,20) + " | "+ AlingString("$"+itemPrice.ToString(),20) + " |\n"; }

        //Helper Method to center a string with a given padding
        public static string AlingString(string s, int totalLenght)
        {
           string result="";
           int stringSize = s.Length;
           int sidePadding = (totalLenght - stringSize) / 2;
           for (int i = 0; i < sidePadding; i++)
            {
              result += " ";
           }
            result += s;
            for (int i = 0; i < sidePadding; i++)
           {
               result += " ";
           }
           return result;
        }
    }
}
