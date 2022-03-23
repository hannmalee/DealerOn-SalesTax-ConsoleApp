using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Receipt
{
    // creating a class and outlining the properties

    public class Product
        { 
        
        // creates the properties of the Product class
        public string ProductName;
        public decimal ProductPrice;
        public bool ProductImported;
        public bool ProductTaxFree;
        public int ProductQuantity;

        // method for import fee calculation ; uses the bool value for ProductImported property
        public double ImportFeeCalc()
        {
            double importFee = 0.00;
            if (ProductImported)
            {
                importFee = (Convert.ToDouble(ProductPrice) * .05);
            }
            else
            {
                importFee = 0.00;
            }
            return importFee;
        }

        // method for matching outlined formatting preferences when quantity > 1 for a product
        public virtual string QuantityShownCalc()
        {
            var quantity = "";
            if (ProductQuantity > 1)
            {
                // used another variable to make it look cleaner and be easier to debug
                var qPrice = ((Convert.ToDouble(ProductPrice)) + ImportFeeCalc()).ToString("0.00");
                quantity = $" ({ProductQuantity} @ {qPrice}) ";
            }
            else
            {
                // set to null so that when we string interpolate it it doesn't look weird
                quantity = null;
            }
            return quantity;
        }

        // method for sales tax calculation using the bool value of ProductTaxFree 
        public virtual double SalesTaxCalc()
        {
            double salesTax = 0.00;
            if (!ProductTaxFree)
            {
                salesTax = (Convert.ToDouble(ProductPrice) * .10);
            }
            else
            {
                salesTax = 0.00;
            }
            return salesTax;
           
        }

    }
}


