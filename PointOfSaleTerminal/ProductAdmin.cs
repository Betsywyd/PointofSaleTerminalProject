using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    public class ProductAdmin
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QtyInStore { get; set; }

        public ProductAdmin(int ProductID,string Name, string Category, string Description, decimal Price)
        {   this.ProductID = ProductID;
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
            Console.WriteLine("1.Add product from ProductsList \n 2.Remove product from ProductList \n 3.Change Products Properties \n 4.Show sold product list in the past \n 5.Exit");
            int a=Validator.GetIntFromUser(4);
            if (a==1)
            {
                ProductAdmin.AddProduct();
                Console.WriteLine("Do you want to continue add? y/n");
                bool v=Validator.Continue();
                if (v) ProductAdmin.AddProduct();
                else if (!v) ProductAdmin.AdminItem();

            }
            else if(a==2)
            {
                ProductAdmin.RemoveProduct();
                Console.WriteLine("Do you want to continue remove? y/n");
                bool v = Validator.Continue();
                if (v) ProductAdmin.RemoveProduct();
                else if (!v) ProductAdmin.AdminItem();
            }
            else if( a==3)
            {

            }
            else if (a == 4)
            {
                SoldProductsSum.SoldSumShow();
                ProductAdmin.AdminItem();
            }
            else
            {
                return;
            }
        }

        //public static void ProductListsCreate()
        //{
        //    Console.WriteLine("Welcome to BIG STORE!This is our productslist!");
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "Bread", "Food", "wholegrain", 4.99m));
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "Chips", "Food", "Potatoc chips", 5.99m));
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "SweetPotato", "Food", "Fesh sweet potato", 0.99m));
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "Beef", "Food", "Chunk roasted beef, 4pound", 35.00m));
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "Notebook", "Office Supplies", "1 Subject Notebook", 0.99m));
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "Binder", "Office Supplies", "3-ringed binder", 4.69m));
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "Pencils", "Office Supplies", "30 Pre-Sharpened, #2 Pencils", 8.98m));
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "Black Pen", "Office Supplies", "It's a really good pen", 449.99m));
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "Lacrosse Stick", "Sporting Goods", "Netted stick for playing game", 99.88m));
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "Basketball", "Sporting Goods", "Always round guaranteed", 15.65m));
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "Horseshoes", "Sporting Goods", "Not for Horses", 44.95m));
        //    Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1), "Shorts", "Sporting Goods", "For the true sportsperson", 19.98m));
        //    Product product = new Product();
        //    Console.WriteLine(product.PrintHead());
        //    Console.WriteLine("-----------------------------------------------------------------------------------------");
        //    Product.PrintProducts(Product.ProductsList);
        //}




        public static void AddProduct()
        {
            //Console.WriteLine("Enter ProductID:");
            //int ProductID =(int)Validator.GetIntFromUser();
            bool check = true;
            do
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter category:");
                string category = Console.ReadLine();
                Console.WriteLine("description:");
                string description = Console.ReadLine();
                Console.WriteLine("Enter price:");
                decimal price = Validator.GetIntFromUser();
                Product.ProductsList.Add(new Product(Product.ProductsList.Count, name, category, description, price));
                Console.WriteLine("Do you want to continue to add new products? y/n");
                bool a = Validator.Continue();
                    if (a) continue;
             
                    else if (!a)
                    {

                    Product.AdminItem();
                    check = false;
                    }
               

                Console.WriteLine("This is new productslist:");
                Product.PrintProducts(Product.ProductsList);
            
            }while (check==true);
        }

        public static void RemoveProduct()
        {
            Console.WriteLine("Please enter remove number");
            int a= Validator.GetIntFromUser(Product.ProductsList.Count);
            Product.ProductsList.RemoveAt(a-1);
            for(int i=0;i<Product.ProductsList.Count;i++)
            {
                Product product = Product.ProductsList[i];
                product.ProductID = i+1;
            }
            Console.WriteLine("This is new productslist:");
            Product.PrintProducts(Product.ProductsList);
        }

        public static void ChangeProperty()
        {
            Console.WriteLine("What property do you want to change");
        }




    }
}
