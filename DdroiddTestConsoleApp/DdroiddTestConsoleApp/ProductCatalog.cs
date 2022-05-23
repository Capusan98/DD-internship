using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DdroiddTestConsoleApp
{
    public class ProductCatalog
    {
        private List<Product> productList = new List<Product>();

        public ProductCatalog()
        {
            InitCatalog();
        }

        //Adds Items in Catalog on start-up
        private void InitCatalog()
        {
           
            productList.Add(new Product("Mouse", 10.99, CountryCodes.RO, 0.2));
            productList.Add(new Product("Keyboard", 40.99, CountryCodes.UK, 0.7));
            productList.Add(new Product("Monitor", 164.99, CountryCodes.US, 1.9));
            productList.Add(new Product("Webcam", 84.99, CountryCodes.RO, 0.2));
            productList.Add(new Product("Headphones", 59.99, CountryCodes.US, 0.6));
            productList.Add(new Product("Desk Lamp", 89.99, CountryCodes.UK, 1.3));
        }

        //retrives a product object in list by its name(string)
        public Product GetProductByName(string productName)
        {
            Product prod = null;
            for (int i = 0; i < productList.Count(); i++)
            {
                if (productList[i].GetItemName() == productName)
                    prod = productList[i];
            }
            return prod;
        }

        //returns a string of the whole list of products
        public string ToStringShort()
        {
            string result= Product.AlingString("ITEM",22)+ Product.AlingString("PRICE", 25)+"\n";
            for(int i = 0; i < productList.Count(); i++)
            {
                result = result + productList[i].ToStringShort();
            }
            return result;
        }
    }
}
