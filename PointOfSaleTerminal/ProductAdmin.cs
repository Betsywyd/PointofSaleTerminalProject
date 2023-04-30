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
        public int ProductNo { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QtyInStore { get; set; }

        public ProductAdmin(int ProductNo,string Name, string Category, string Description, decimal Price)
        {   this.ProductNo = ProductNo;
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
            int a=Validator.GetIntFromUser(5);
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
                ProductAdmin.ChangeProperty();
                Console.WriteLine("Do you want to continue change? y/n");
                bool v = Validator.Continue();
                if (v) ProductAdmin.ChangeProperty();
                else if (!v) ProductAdmin.AdminItem();

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

        public static void AddProduct()
        {
            //Console.WriteLine("Enter ProductNo:");
            //int ProductNo =(int)Validator.GetIntFromUser();
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
                product.ProductNo = i+1;
            }
            Console.WriteLine("This is new productslist:");
            Product.PrintProducts(Product.ProductsList);
        }

        public static void ChangeProperty()
        {
            Console.WriteLine("Which product do you want to change? enter number 1-"+Product.ProductsList.Count);
            int p = Validator.GetIntFromUser(Product.ProductsList.Count);
            Console.WriteLine("What property do you want to change? 1.Name 2.Category 3.Description, 4. Price");
       
            int a=Validator.GetIntFromUser(4);
           
            for (int i = 0; i < Product.ProductsList.Count; i++)
            {
                if (Product.ProductsList[i].Name == Product.ProductsList[p - 1].Name)
                {
                  switch(a)
                    {
                        case 1:
                        Console.WriteLine("Enter new value:");
                        string s1 = Console.ReadLine();
                        Product.ProductsList[i].Name = s1;
                        break;
                        case 2:
                        Console.WriteLine("Enter new value:");
                        string s2 = Console.ReadLine();
                        Product.ProductsList[i].Category = s2;
                        break;
                        case 3:
                        Console.WriteLine("Enter new value:");
                        string s3 = Console.ReadLine();
                        Product.ProductsList[i].Description = s3;
                        break;
                        case 4:
                        Console.WriteLine("Enter new value:");
                        decimal d = Validator.GetIntFromUser();
                        Product.ProductsList[i].Price = d;
                        break;
                    }
                 
                }
            }
            Console.WriteLine("This is new productslist:");
            Product.PrintProducts(Product.ProductsList);

        }




    }
}
