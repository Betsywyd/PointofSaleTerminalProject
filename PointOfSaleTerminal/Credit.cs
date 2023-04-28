using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    class Credit:Payment

    {
        //public static decimal PayCredit(string cardNo, string expiryDate, string cvv)
        //{
        //    Console.WriteLine("plese enter Credit card number: ");
        //    //string cardNo, string expiryDate, string cvv
        //    string cardNo=Console.ReadLine();
        //    Console.WriteLine("plese enter expiration number: ");
        //    string expiryDate=Console.ReadLine();
        //    Console.WriteLine("plese enter cvv number: ");
        //    string cvv=Console.ReadLine();

        //}

        public static string CardNo;
        public static string ExpiryDate;
        public static string Cvv;
        public Credit(string PaymentMethod, decimal Value, decimal Change, decimal GrandTotal) : base(PaymentMethod, Value, Change, GrandTotal)
        {
            Value = ProductPurchased.TotalReceipt(ProductPurchased.OrderList);
            
        }


        public static bool IsCreditCardInfoValid(string cardNo, string expiryDate, string cvv)
        {
            var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
            var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
            var yearCheck = new Regex(@"^20[0-9]{2}$");
            var cvvCheck = new Regex(@"^\d{3}$");

            if (!cardCheck.IsMatch(cardNo)) // <1>check card number is valid
                return false;
            if (!cvvCheck.IsMatch(cvv)) // <2>check cvv is valid as "999"
                return false;

            var dateParts = expiryDate.Split('/'); //expiry date in from MM/yyyy            
            if (!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1])) // <3 - 6>
                return false; // ^ check date format is valid as "MM/yyyy"

            var year = int.Parse(dateParts[1]);
            var month = int.Parse(dateParts[0]);
            var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month); //get actual expiry date
            var cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

            //check expiry greater than today & within next 6 years <7, 8>>
            return (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(6));
        }

        public static string[] PayCreditEnter()
        {
            string[] arrPayCredit = new string[3] ;
            Console.WriteLine("plese enter Credit card number(16 interger): ");
   
            string cardNo = Console.ReadLine();
            arrPayCredit[0] = cardNo;
            Console.WriteLine("plese enter expiration number:  in from MM/yyyy  ");
            string expiryDate = Console.ReadLine();
            arrPayCredit[1] = expiryDate;
            Console.WriteLine("plese enter cvv number: ");
            string cvv = Console.ReadLine();
            arrPayCredit[2] = cvv;
            return arrPayCredit;
        }

        public static void PayCredit()
        {
            string[] arr = PayCreditEnter();
            if (Credit.IsCreditCardInfoValid(arr[0], arr[1], arr[2]) == true)
            {
                Payment.ReceiptFooter();
                //Console.WriteLine("{0}{1,-15} {2,-18} {3,-30} {4,30}", "    ", "CardNo", " ", "  ", Change);
            }
            else if(Credit.IsCreditCardInfoValid(arr[0], arr[1], arr[2])== false)
            {
                Console.WriteLine("This is an invalid card,please enter again ");
                Credit.PayCredit();
            }
            else
            {
                Console.WriteLine("enter wrong,please enter again ");
            }

        }



    }
}
