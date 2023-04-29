using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;

namespace PointOfSaleTerminal
{
    public class Program
    {
        static void Main()

        {
            Console.WriteLine("Welcome to BIG STORE!This is our productslist!");
            Product.ProductsList.Add(new Product((Product.ProductsList.Count+1), "Bread", "Food", "wholegrain", 4.99m));
            Product.ProductsList.Add(new Product((Product.ProductsList.Count +1),"Chips", "Food", "Potatoc chips", 5.99m));
            Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1),"SweetPotato", "Food", "Fesh sweet potato", 0.99m));
            Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1),"Beef", "Food", "Chunk roasted beef, 4pound", 35.00m));
            Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1),"Notebook", "Office Supplies", "1 Subject Notebook", 0.99m));
            Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1),"Binder", "Office Supplies", "3-ringed binder", 4.69m));
            Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1),"Pencils", "Office Supplies", "30 Pre-Sharpened, #2 Pencils", 8.98m));
            Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1),"Black Pen", "Office Supplies", "It's a really good pen", 449.99m));
            Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1),"Lacrosse Stick", "Sporting Goods", "Netted stick for playing game", 99.88m));
            Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1),"Basketball", "Sporting Goods", "Always round guaranteed", 15.65m));
            Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1),"Horseshoes", "Sporting Goods", "Not for Horses", 44.95m));
            Product.ProductsList.Add(new Product((Product.ProductsList.Count + 1),"Shorts", "Sporting Goods", "For the true sportsperson", 19.98m));
            Product product = new Product();
            Console.WriteLine(product.PrintHead());
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Product.PrintProducts(Product.ProductsList);
            ProductOrder.Order();

            Console.WriteLine();
            bool check = true;
            do {
                int a = Validator.GetIntFromUser("Do you want have an order or go to ProductAdmin or Exit,enter number?  1. Order  2.ProductAdmin 3.Exit");
                if (a ==3) check = false;
                Validator.OrderOrAdmin(a);
            } while (check==true);

        }
    }
}