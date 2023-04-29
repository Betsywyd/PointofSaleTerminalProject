using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    class ProductPurchased : Product
    {
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime Date { get; set; }

        public static List<ProductPurchased> OrderList { get; set; } = new List<ProductPurchased>();
        public ProductPurchased(string Name, string Category, string Description, decimal Price,int Quantity, decimal SubTotal ) : base(Name, Category, Description, Price)
        {
            this.Name = Name;
            this.Category = Category;
            this.Description = Description;
            this.Price = Price;
            this.Quantity =Quantity;
            this.SubTotal = Price*Quantity;
        }
        
        public ProductPurchased()
        {

        }
        public override string ToString()
        {

            return base.ToString()+"X"+Quantity+"            "+SubTotal;
        }

        public override string PrintHead()
        {

            return base.PrintHead()+"                 " +"SubTotal";
            
        }

        public static decimal TotalReceipt(List<ProductPurchased> OrderList)

        {
            decimal total = 0;
            for(int i=0;i< OrderList.Count;i++)
            {
                total += OrderList[i].Price* OrderList[i].Quantity;
            }
            decimal tax = 0.06m * total;
            decimal GrandTotal = total + tax;

            ProductPurchased.PrintProducts(ProductPurchased.OrderList.Cast<Product>().ToList());
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("{0}{1,-15} {2,-18} {3,-30} {4,30}", "    ", "Total", " ", "  ", Math.Round(total,2));
            Console.WriteLine("{0}{1,-15} {2,-18} {3,-30} {4,30}", "    ", "Tax", " ", "  ", Math.Round(tax,2));
            Console.WriteLine("{0}{1,-15} {2,-18} {3,-30} {4,30}", "    ", "GrandTotal ", " ", "  ", Math.Round(GrandTotal,2));
            Console.WriteLine("{0}{1,-15} {2,-18} {3,-30} {4,30}", "    ", "DateTime ", " ", "  ", DateTime.Now);
            return GrandTotal;
        }
 
    }
}
