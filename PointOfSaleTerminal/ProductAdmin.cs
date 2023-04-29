using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    public class ProductAdmin
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ProductAdmin(string Name, string Category, string Description, decimal Price)
        {
            this.Name = Name;
            this.Category = Category;
            this.Description = Description;
            this.Price = Price;
        }
        public ProductAdmin()
        {
           

        }

        public static void AdminItem()
        {
            Console.WriteLine("what do you want to change for product? ");
            Console.WriteLine("1.Add product from ProductsList \t 2.Remove product from ProductList \t 3.Change Products Properties \t 4.Exit");
            int a=Validator.GetIntFromUser(4);
            if (a==1)
            {
                ProductAdmin.AddProduct();
                Console.WriteLine("Do you want to continue add?");
                bool v=Validator.Continue();
                if (v) ProductAdmin.AddProduct();
                else if (!v) ProductAdmin.AdminItem();

            }
            else if(a==2)
            {
                ProductAdmin.RemoveProduct();
                Console.WriteLine("Do you want to continue remove?");
                bool v = Validator.Continue();
                if (v) ProductAdmin.RemoveProduct();
                else if (!v) ProductAdmin.AdminItem();
            }
            else if( a==3)
            {

            }
            else
            {
                return;
            }
        }
        public static void AddProduct()
        {
            Console.WriteLine("Enter name:");
            string name=Console.ReadLine();
            Console.WriteLine("Enter category:");
            string category=Console.ReadLine();
            Console.WriteLine("description:");
            string description=Console.ReadLine();
            Console.WriteLine("Enter price:");
            decimal price= Validator.GetIntFromUser();
            Product.ProductsList.Add(new Product(name, category, description, price));
            Console.WriteLine("This is new productslist:");
            Product.PrintProducts(Product.ProductsList);
        }

        public static void RemoveProduct()
        {
            Console.WriteLine("Please inter remove number");
            int a= Validator.GetIntFromUser(Product.ProductsList.Count);
            Product.ProductsList.RemoveAt(a);
            Console.WriteLine("This is new productslist:");
            Product.PrintProducts(Product.ProductsList);
        }

        public static void ChangeProperty()
        {
            Console.WriteLine("What property do you want to change");
        }




    }
}
