using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdroiddTestConsoleApp
{
    public class UI
    {
        private Service service;
        public UI() {
            service = new Service();
        }

        

        public void Run()
        {
           
            int option = 1;
            while (option != 0)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(service.CatalogToString());
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("1.Add Item\n0.Exit");
                
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        Console.Write("Item: ");
                        string item = Console.ReadLine();
                        if (service.productCatalog.GetProductByName(item) != null)
                        {
                            service.AddItem(item);
                            service.GenerateInvoice();
                            Console.Clear();
                            Console.WriteLine("Cart:");
                            Console.WriteLine(service.ShoppingCartToString());
                            Console.WriteLine(service.InvoiceToString());
                        }
                        else
                        {
                            Console.WriteLine("Invalid product!");
                        }

                    }
                    else if(option!=0)
                    {
                        Console.WriteLine("Invalid option, try again!");
                        option = 999;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Invalid option, try again!");
                    option = 999;
                }
               
                Console.WriteLine("\nPress any key to continue..");
                Console.ReadKey();

            }

        }
    }
}
