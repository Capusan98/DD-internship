using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdroiddTestConsoleApp
{
    public class ShoppingCart
    {
        //list of products the user has selected 
        private List<Product> userProductList = new List<Product>();
        //a map key(item)->value(times the user has selected that item)
        private Dictionary<string, int> productCount = new Dictionary<string, int>();
        public ProductCatalog productCatalog { get; set; }

        public ShoppingCart(ProductCatalog productCat) { productCatalog = productCat; }
        public List<Product> getList() { return userProductList; }
        public void AddToCart(Product product) {
            if (!ProductAlreadyInList(product))
            {
                userProductList.Add(product);
                productCount[product.GetItemName()] = 1;
            }
            else
            {
                productCount[product.GetItemName()]++;
            }
           
        }
        //return true if that type of item already is in the list
        private bool ProductAlreadyInList(Product product)
        {
            for(int i = 0; i < userProductList.Count(); i++)
            {
                if (userProductList[i].GetItemName() == product.GetItemName())
                    return true;
            }
            return false;
        }
        //returns a string of the whole contents of the shopping cart
        public string CartToString()
        {
            string result="";
            for(int i = 0; i < userProductList.Count(); i++)
            {
                result = result + userProductList[i].GetItemName() + " x " + productCount[userProductList[i].GetItemName()].ToString()+"\n";
            }
            return result;
        }


        public int GetProductCount(Product product)
        {
            return productCount[product.GetItemName()];
        }
        public int GetProductCountByString(string product)
        {
           
                return productCount[product];
            
            
        }
    }
}
