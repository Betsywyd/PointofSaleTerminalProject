using System;
using System.Collections.Generic;
using System.Linq;

using System.Security;

using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    public class Product:ProductAdmin
    {

        public static List<Product> ProductsList { get; set; } = new List<Product>();
     
        public Product(int ProductID, string Name, string Category, string Description, decimal Price):base(ProductID,Name, Category, Description, Price)
        {
            this.ProductID = ProductID;
            this.Name = Name;
            this.Category = Category;
            this.Description = Description;
            this.Price = Price;
        }
        public Product():base()
        {

        }
        public override string ToString()
        {

            return String.Format("{0,-5}{1,-15} {2,-18} {3,-30} ${4,-10}", ProductID, Name, Category, Description, Price);
        }

        public virtual string  PrintHead()
        {
            return String.Format("{0}{1,-15} {2,-18} {3,-30} {4,5}", "        ", "Name", "Category", "Description", "Price");
          
        }
        public static void PrintProducts(List<Product> list)
        {
         
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
        }

    }
   
}
