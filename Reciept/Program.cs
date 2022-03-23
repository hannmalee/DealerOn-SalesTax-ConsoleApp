// namespaces (collections of classes) 
using System; 
using System.Collections.Generic;
using System.Linq;

namespace Receipt
{
    //contains methods
    internal class Program 
    {
        // method that is the entry point for our code
        static void Main(string[] args) 

        {
            // List that acts as the container for the items we are going to add into our "basket"
            List<Product> myProducts = new List<Product>();

            // launches console and provides visible header (string)
            Console.WriteLine("... Receipt Calculator...");

            // while session is activated, do these things
            while (true)
            {

                Console.WriteLine("What is the name of product?");
                // assigns whatever the user inputs into console to the string variable 
                string productNameResponse = Console.ReadLine(); 
                Console.WriteLine("What is the price of this product?");
                // assigns whatever the user inputs into console to the decimal variable 
                decimal productPriceResponse = Convert.ToDecimal(Console.ReadLine()); 
                Console.WriteLine("Is this product imported? Y/N");
                // converts user input to UPPER case and if the string matches "Y", ternary condition to assign user input to true or false
                bool productImportedResponse = Console.ReadLine().ToUpper() == "Y" ? true : false;
                // asking to find out if tax free?
                Console.WriteLine("Is this a book, food, or medical product? Y/N");
                // converts user input to UPPER case and if the string matches "Y", ternary condition to assign user input to true or false
                bool productTaxFreeResponse = Console.ReadLine().ToUpper() == "Y" ? true : false;
                Console.WriteLine("What is the quantity of this item?");
                // converts input from string and assigns to integer variable
                int productQuantityResponse = Convert.ToInt32(Console.ReadLine()); 
                Console.WriteLine("Do you have another item to add to your basket? Y/N");
                // question that either leads repeats back in the loop or exits session (see line 48)
                string newProductResponse = Console.ReadLine().ToUpper(); 



                //assign values to the properties of the new product being added to the list
                myProducts.Add(new Product()
                {
                    ProductName = productNameResponse,
                    ProductPrice = productPriceResponse,
                    ProductImported = productImportedResponse,
                    ProductTaxFree = productTaxFreeResponse,
                    ProductQuantity = productQuantityResponse,
                });

                // determines when to exit session
                if (newProductResponse == "Y")
                {
                    continue;
                }
                else
                {
                    break;
                }

            }

            // when we break out of our session, we can begin to display our receipt calculations
            Console.WriteLine("------RECEIPT-----");

            // cycles through our myProducts list and for each item, executes the following code to construct a string for product name and price, also additional code for if quantity is greater than one (see product.cs file for calculations)
            foreach (var item in myProducts)
            {
                // using variables to help it look cleaner and help with debugging
                var rProductPrice = (item.ProductQuantity * (item.ProductPrice +
                     Convert.ToDecimal((item.ImportFeeCalc() + item.SalesTaxCalc()))));

                var rQuantity = item.QuantityShownCalc();

                Console.WriteLine($"{item.ProductName}: {rProductPrice.ToString("0.00")} {rQuantity}");
            }

            // now that we are out of the loop, we can construct the sales taxes and totals. 
            var rSalesTax = (myProducts.Sum(item => Convert.ToDecimal(item.SalesTaxCalc() + item.ImportFeeCalc())));
            var rTotalPrice = (myProducts.Sum(item => ((item.ProductPrice + (Convert.ToDecimal(item.SalesTaxCalc()) + Convert.ToDecimal(item.ImportFeeCalc()))) * item.ProductQuantity)));


            Console.WriteLine($"Sales Taxes: {rSalesTax.ToString("0.00")}");
            Console.WriteLine($"Total: {rTotalPrice.ToString("0.00")}");

        }
    
    }
}
