using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PointOfSaleTerminal
{
    public class Payment
    {
        public static string PaymentMethod { get; set; }
        public static decimal Value { get; set; }
        public static decimal Change { get; set; }
        public static decimal GrandTotal { get; set; } 

        public Payment(string PaymentMethod, decimal Value, decimal Change,decimal GrandTotal)
        {
            PaymentMethod = Payment.PaymentWay();
        }
        public static string PaymentWay()
        {
            Console.WriteLine("How would you like to pay?Pleae enter number or word!  1:Cash 2:Credit 3:Check");
            string[] arr = { "cash", "credit", "check" };
            string response = Console.ReadLine().ToLower().Trim();
            int index;
            string input = "";
            try
            {
                index = int.Parse(response);
                if (index <= 3 && index >= 1)
                {
                    input = arr[index-1].ToLower().Trim();
                    return input;
                }
                else
                {
                    Console.WriteLine("This is out of range, let's try again");
                    return PaymentWay();

                }
            }
            catch (FormatException)
            {
                if(arr.Contains(response))
                {
                    input = response;
                    return input;
                }
                else
                {
                    Console.WriteLine("This is an invalid enter,Please enter again!"); 
                    return PaymentWay();
                }
     
            }
        }
     
       



        public static void ReceiptFooter()

        {
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("{0}{1,-15} {2,-18} {3,-30} {4,30}", "    ", PaymentMethod, " ", "  ", Math.Round(Value,2));
            Console.WriteLine("{0}{1,-15} {2,-18} {3,-30} {4,30}", "    ", "Change", " ", "  ", Math.Round(Change,2));
            Console.WriteLine("Thank you for your coming!");
        }









    }
}

          





                        

