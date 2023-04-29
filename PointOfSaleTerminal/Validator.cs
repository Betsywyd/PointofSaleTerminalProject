using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    public class Validator
    {
        public static bool WithinRange(int index, List<Product> list)
        {
            if (index < list.Count() && index >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetIntFromUser(string message)
        {
            Console.WriteLine(message);

            try
            {
                int num = int.Parse(Console.ReadLine());
                if(num > 0 ) 
                { 
                return num;
                }
                else
                {
                    Console.WriteLine("That was not a valid integer lets try again");
                    return GetIntFromUser(message);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("That was not a valid integer lets try again");
                return GetIntFromUser(message);
            }
        }

        public static int GetIntFromUser(int x)
        {
       
            try
            {
                int num = int.Parse(Console.ReadLine());
                if (num > 0&&num<=x)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("That was not a valid integer lets try again");
                    return GetIntFromUser(x);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("That was not a valid integer lets try again");
                return GetIntFromUser(x);
            }
        }
      
        public static decimal GetIntFromUser()
        {

            try
            {
                decimal num = decimal.Parse(Console.ReadLine());
                if (num > 0 )
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("That was not a valid integer lets try again");
                    return GetIntFromUser();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("That was not a valid integer lets try again");
                return GetIntFromUser();
            }
        }
        public static decimal GetValue()
        {
            Console.WriteLine("How much cash:  ");

            try
            {
                decimal num = decimal.Parse(Console.ReadLine());
                if (num > 0)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("That was not a valid integer lets try again");
                    return GetValue();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("That was not a valid integer lets try again");
                return GetValue();
            }
        }

        public static bool Continue()
        {

            string answer = Console.ReadLine().ToLower().Trim();
            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("This is an invalid enter,Please enter again! y/n");
                return Continue();
            }

        }

        public static void OrderOrAdmin(int x)
        {
          
            if (x == 1)
            {   ProductPurchased.OrderList.Clear();
                Product product = new Product();
                Console.WriteLine(product.PrintHead());
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Product.PrintProducts(Product.ProductsList);
               
                ProductOrder.Order();
            }
            else if (x == 2)
            {
              ProductAdmin.AdminItem();
            }
            else if (x == 3)
            {
                return;
            }
            else
            {
                Validator.GetIntFromUser("Do you want have an order or go to ProductAdmin or Exit,enter number?  1. Order  2.ProductAdmin 3.Exit ");
            }
        }

       
    }

}
