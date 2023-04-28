using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    class Check : Payment
    {
        public static string CheckNo { get; set; }
        public Check(string PaymentMethod, decimal Value, decimal Change, decimal GrandTotal) : base(PaymentMethod, Value, Change, GrandTotal)
        {
            Value = ProductPurchased.TotalReceipt(ProductPurchased.OrderList);
        }

        public static void PayCheck(string s)
        {
            int checkNo = Validator.GetIntFromUser(s);
            Payment.ReceiptFooter();

        }
    }
}
