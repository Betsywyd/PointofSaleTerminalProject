using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    class Cash:Payment

    {
        public Cash(string PaymentMethod, decimal Value, decimal Change, decimal GrandTotal) :base( PaymentMethod, Value, Change, GrandTotal)
        {

        }

        public static decimal PayCash(decimal value, decimal grandTotal)
        {

            decimal change = 0;
            if (value >= grandTotal)
            {
                change = value - grandTotal;
                return change;
            }
            else
            {
                Console.WriteLine($"This is not not enough,please enter again!");
                return PayCash(value, grandTotal);
            }

        }



    }
}
