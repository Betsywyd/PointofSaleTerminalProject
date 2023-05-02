using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    class Check : Payment
    {
        public static string CheckNo { get; set; }
        public Check(string PaymentMethod, decimal Value, decimal Change, decimal GrandTotal) : base(PaymentMethod, Value, Change, GrandTotal)
        {
            //Value = ProductPurchased.TotalReceipt(ProductPurchased.OrderList);
            
        }

        public static void PayCheck()
        {
            Console.WriteLine("plese enter check number(9 digit): ");
            string s=Console.ReadLine();
            char[] c= s.ToCharArray();
            bool b = c.Count(i => char.IsDigit(i))==9;
            if (b)
            {
                CheckNo = s;
                Payment.ReceiptFooter();
            }

            else
            {
                Console.WriteLine("This is an invalid check number,enter again!");
                Check.PayCheck();
            }
        }

    }
    }

