using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdroiddTestConsoleApp
{
    public class Service
    {
        public ProductCatalog productCatalog;
        ShoppingCart shoppingCart;
        Invoice invoice;

        public Service()
        {
            productCatalog = new ProductCatalog();
            shoppingCart = new ShoppingCart(productCatalog);
            SetRates();
        }
        private void SetRates()
        {
            ShippingRate.setCountryRate(CountryCodes.RO, 1);
            ShippingRate.setCountryRate(CountryCodes.UK, 2);
            ShippingRate.setCountryRate(CountryCodes.US, 3);
        }

        public String CatalogToString()
        {
            return productCatalog.ToStringShort();
        }

        public void AddItem(string itemName)
        {
            if (productCatalog.GetProductByName(itemName) != null)
            {
                shoppingCart.AddToCart(productCatalog.GetProductByName(itemName));
            }
        }

        public String ShoppingCartToString()
        {
            return shoppingCart.CartToString();
        }

        public void GenerateInvoice()
        {
            invoice = new Invoice(shoppingCart);
        }

        public string InvoiceToString()
        {
            return invoice.InvoiceString();
        }


    }
}
