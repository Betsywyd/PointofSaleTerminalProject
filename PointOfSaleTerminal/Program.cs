﻿using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;

namespace PointOfSaleTerminal
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to BIG STORE!This is our productslist!");
                bool check=true;
           
                Product.ProductsList.Add(new Product("Bread", "Food", "wholegrain", 4.99m));
                Product.ProductsList.Add(new Product("Chips", "Food", "Potatoc chips", 5.99m));
                Product.ProductsList.Add(new Product("SweetPotato", "Food", "Fesh sweet potato", 0.99m));
                Product.ProductsList.Add(new Product("Beef", "Food", "Chunk roasted beef, 4pound", 35.00m));
                Product.ProductsList.Add(new Product("Notebook", "Office Supplies", "1 Subject Notebook", 0.99m));
                Product.ProductsList.Add(new Product("Binder", "Office Supplies", "3-ringed binder", 4.69m));
                Product.ProductsList.Add(new Product("Pencils", "Office Supplies", "30 Pre-Sharpened, #2 Pencils", 8.98m));
                Product.ProductsList.Add(new Product("Black Pen", "Office Supplies", "It's a really good pen", 449.99m));
                Product.ProductsList.Add(new Product("Lacrosse Stick", "Sporting Goods", "Netted stick for playing game", 99.88m));
                Product.ProductsList.Add(new Product("Basketball", "Sporting Goods", "Always round guaranteed", 15.65m));
                Product.ProductsList.Add(new Product("Horseshoes", "Sporting Goods", "Not for Horses", 44.95m));
                Product.ProductsList.Add(new Product("Shorts", "Sporting Goods", "For the true sportsperson", 19.98m));
                Product product = new Product();
            Console.WriteLine(product.PrintHead());
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Product.PrintProducts(Product.ProductsList);
                Console.WriteLine();
            do
            {
                Console.WriteLine("what product do you want to purchase,enter a number or name of products:");
                List<string> name = new List<string>();
                for (int i = 0; i < Product.ProductsList.Count; i++)
                {
                    name.Add(Product.ProductsList[i].Name.ToLower());
                   
                }
                string response = Console.ReadLine().ToLower().Trim();
                int index;
                string input = "";
                try
                {
                    index = int.Parse(response);
                    if(Validator.WithinRange(index, Product.ProductsList)) 
                    { 
                    input = Product.ProductsList[index - 1].Name.ToLower();
                    }
                    else
                    {
                        Console.WriteLine("This is out of range, Do you want to continue order? y/n");
                        bool a = Validator.Continue();
                        if (a == true)
                        {
                            continue;
                        }
                        else if (a == false)
                        {
                            Receipt();
                            check = false;
                        }

                    }
                }
                catch (FormatException)
                {
                    if (name.Contains(response))
                    {
                        input = response;
                    }
                    else
                    {
                        Console.WriteLine("Sorry,this product is not in store, Do you want to continue order? y/n");
                        bool a= Validator.Continue();
                        if (a == true)
                        {
                            continue;
                        }
                        else if (a == false)
                        {
                            Receipt();
                            check = false;
                        }
                                

                    }
                }

                for (int i = 0; i < name.Count; i++)
                {
    
                    Product p = Product.ProductsList[i];
                    p.Name = name[i];
                    if (p.Name.ToLower() == input)
                    {
                        Console.WriteLine($"{name[i]} :" + p.ToString());
                      
                        int quantity = Validator.GetIntFromUser("Please enter  quantity : ");
                        if (ProductPurchased.OrderList.Where(O => O.Name == input).Count() > 0) 
                        {
                            for (int j = 0; j < ProductPurchased.OrderList.Count(); j++)
                            { if(ProductPurchased.OrderList[j].Name == input) 
                                { 
                                
                                ProductPurchased.OrderList[j].Quantity += quantity;
                                    ProductPurchased.OrderList[j].SubTotal = ProductPurchased.OrderList[j].Quantity * ProductPurchased.OrderList[j].Price;

                                }
                            }
                        }
                       else
                        {
                            ProductPurchased.OrderList.Add(new ProductPurchased(p.Name, p.Category, p.Description, p.Price, quantity,quantity*p.Price));
                        }
                        Console.WriteLine("you added "+quantity+" "+ input + " to orderlist!");

                    }
                }
               

                Console.WriteLine("Do you want to continue order? y/n");
                bool answer = Validator.Continue();
                if (answer == true)
                {
                    

                    continue;
                }
                else if (answer == false)
                {
                    Receipt();
                 
                    check =false;
                }
              


            } while (check==true);
            decimal grandTotal = ProductPurchased.TotalReceipt(ProductPurchased.OrderList);
            Console.WriteLine();

            Payment.PaymentMethod = Payment.PaymentWay();
          

            //Console.WriteLine("Value:   " + Cash.Value);
            //Console.WriteLine("GrandTotal:   " + Cash.GrandTotal);
            //Console.WriteLine("Change:   " + Cash.Change);

            if (Payment.PaymentMethod == "cash")
            {
                Cash.Value = Validator.GetValue();
                Cash.Change = Cash.PayCash(Payment.Value, grandTotal);
                Cash.GrandTotal = grandTotal;
                Payment.ReceiptFooter();
                return;
            }
            else if(Payment.PaymentMethod == "credit")
            {
                Credit.Value = ProductPurchased.TotalReceipt(ProductPurchased.OrderList);
                Credit.Change = 0;
                Credit.PayCredit();
                return;
            }
            else if(Payment.PaymentMethod == "check")
            {
                Check.Value = ProductPurchased.TotalReceipt(ProductPurchased.OrderList);
                Check.Change = 0;
                Check.PayCheck("plese enter check number(9 digit): ");
            }


    

        }

        public static void Receipt()
        {
            Console.WriteLine();
            Console.WriteLine("Thanks for your order!This is your receipt!");
            Console.WriteLine();
            ProductPurchased item = new ProductPurchased();
            Console.WriteLine(item.PrintHead());
            Console.WriteLine("-----------------------------------------------------------------------------------------");
        }




    }
}