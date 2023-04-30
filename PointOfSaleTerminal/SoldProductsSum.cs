using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleTerminal
{
    public class SoldProductsSum:ProductPurchased
    {
        public static List<SoldProductsSum> SoldSumList { get; set; } = new List<SoldProductsSum>();

        public SoldProductsSum(int ProductNo, string Name, string Category, string Description, decimal Price, int Quantity, decimal SubTotal) : base(ProductNo, Name, Category, Description, Price,Quantity,SubTotal)
        {
            this.ProductNo = ProductNo;
            this.Name = Name;
            this.Category = Category;
            this.Description = Description;
            this.Price = Price;
            this.Quantity = Quantity;
            this.SubTotal = Price * Quantity;
        }
        
        public static void SoldSumShow()
        {
            Console.WriteLine("Below are products sold in past. ");

            SoldProductsSum.PrintProducts(SoldProductsSum.SoldSumList.Cast<Product>().ToList());
        }
    }
}
