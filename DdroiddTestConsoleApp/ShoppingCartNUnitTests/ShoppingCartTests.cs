using NUnit.Framework;
using DdroiddTestConsoleApp;

namespace ShoppingCartTests
{
    public class ShoppingCartTests
    {
        
        [Test]
        public void EmptyShoppingCartResultsInZeroTotal()
        {
            var productCatalog = new ProductCatalog();
            var shoppingCart = new ShoppingCart(productCatalog);
            ShippingRate.setCountryRate(CountryCodes.RO, 1);
            ShippingRate.setCountryRate(CountryCodes.UK, 2);
            ShippingRate.setCountryRate(CountryCodes.US, 3);
            var invoice = new Invoice(shoppingCart);

            Assert.AreEqual(invoice.GetTotal(),0);
        }
        [Test]
        public void AddedAMouseItemTotals()
        {
            var productCatalog = new ProductCatalog();
            var shoppingCart = new ShoppingCart(productCatalog);
            ShippingRate.setCountryRate(CountryCodes.RO, 1);
            ShippingRate.setCountryRate(CountryCodes.UK, 2);
            ShippingRate.setCountryRate(CountryCodes.US, 3);
            shoppingCart.AddToCart(productCatalog.GetProductByName("Mouse"));
            var invoice = new Invoice(shoppingCart);

            Assert.AreEqual(invoice.GetTotal(), 15.0781);
          
           
        }
        [Test]
        public void AddedAMouseItemSubtotal()
        {
            var productCatalog = new ProductCatalog();
            var shoppingCart = new ShoppingCart(productCatalog);
            ShippingRate.setCountryRate(CountryCodes.RO, 1);
            ShippingRate.setCountryRate(CountryCodes.UK, 2);
            ShippingRate.setCountryRate(CountryCodes.US, 3);
            shoppingCart.AddToCart(productCatalog.GetProductByName("Mouse"));
            var invoice = new Invoice(shoppingCart);

          
            Assert.AreEqual(invoice.GetSubtotal(), 10.99);
          
            
        }
        [Test]
        public void AddedAMouseItemShipping()
        {
            var productCatalog = new ProductCatalog();
            var shoppingCart = new ShoppingCart(productCatalog);
            ShippingRate.setCountryRate(CountryCodes.RO, 1);
            ShippingRate.setCountryRate(CountryCodes.UK, 2);
            ShippingRate.setCountryRate(CountryCodes.US, 3);
            shoppingCart.AddToCart(productCatalog.GetProductByName("Mouse"));
            var invoice = new Invoice(shoppingCart);

            
            Assert.AreEqual(invoice.GetShipping(), 2);
          
           
        }
        [Test]
        public void AddedAMouseItemVAT()
        {
            var productCatalog = new ProductCatalog();
            var shoppingCart = new ShoppingCart(productCatalog);
            ShippingRate.setCountryRate(CountryCodes.RO, 1);
            ShippingRate.setCountryRate(CountryCodes.UK, 2);
            ShippingRate.setCountryRate(CountryCodes.US, 3);
            shoppingCart.AddToCart(productCatalog.GetProductByName("Mouse"));
            var invoice = new Invoice(shoppingCart);

          
            Assert.AreEqual(invoice.GetVAT(), 2.0881);
          
        }
        [Test]
        public void AddedAKeboardItemEqualsDiscount()
        {
            var productCatalog = new ProductCatalog();
            var shoppingCart = new ShoppingCart(productCatalog);
            ShippingRate.setCountryRate(CountryCodes.RO, 1);
            ShippingRate.setCountryRate(CountryCodes.UK, 2);
            ShippingRate.setCountryRate(CountryCodes.US, 3);
            shoppingCart.AddToCart(productCatalog.GetProductByName("Keyboard"));
            var invoice = new Invoice(shoppingCart);
          
            Assert.AreEqual(invoice.GetKeyboardDiscount(), 4.099);
            
        }
        [Test]
        public void AddedTowMonitorsEqualDeskLampDiscount()
        {
            var productCatalog = new ProductCatalog();
            var shoppingCart = new ShoppingCart(productCatalog);
            ShippingRate.setCountryRate(CountryCodes.RO, 1);
            ShippingRate.setCountryRate(CountryCodes.UK, 2);
            ShippingRate.setCountryRate(CountryCodes.US, 3);
            shoppingCart.AddToCart(productCatalog.GetProductByName("Monitor"));
            shoppingCart.AddToCart(productCatalog.GetProductByName("Monitor"));
            shoppingCart.AddToCart(productCatalog.GetProductByName("Desk Lamp"));
            var invoice = new Invoice(shoppingCart);

            Assert.AreEqual(invoice.GetThreePackDiscount(),44.995);

        }
        [Test]
        public void AddedTowItemsEqualShippingDiscount()
        {
            var productCatalog = new ProductCatalog();
            var shoppingCart = new ShoppingCart(productCatalog);
            ShippingRate.setCountryRate(CountryCodes.RO, 1);
            ShippingRate.setCountryRate(CountryCodes.UK, 2);
            ShippingRate.setCountryRate(CountryCodes.US, 3);
            shoppingCart.AddToCart(productCatalog.GetProductByName("Monitor"));
            shoppingCart.AddToCart(productCatalog.GetProductByName("Monitor"));
            var invoice = new Invoice(shoppingCart);

            Assert.AreEqual(invoice.GetShippinDiscount(), 1);

        }
        [Test]
        public void AddedAWebcamEqualNoDiscount()
        {
            var productCatalog = new ProductCatalog();
            var shoppingCart = new ShoppingCart(productCatalog);
            ShippingRate.setCountryRate(CountryCodes.RO, 1);
            ShippingRate.setCountryRate(CountryCodes.UK, 2);
            ShippingRate.setCountryRate(CountryCodes.US, 3);
            shoppingCart.AddToCart(productCatalog.GetProductByName("Webcam"));
            
            var invoice = new Invoice(shoppingCart);

            Assert.AreEqual(invoice.GetShippinDiscount(), 0);
            Assert.AreEqual(invoice.GetKeyboardDiscount(), 0);
            Assert.AreEqual(invoice.GetThreePackDiscount(), 0);

        }
    }
}