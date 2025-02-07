using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineOrdering
{
    public class Product
    {
        private string _prodName;
        private string _prodID;
        private double _price;
        private int _quantity;


        public Product(string prodName, string prodID, double price, int quantity)
        {
            _prodName = prodName;
            _prodID = prodID;
            _price = price;
            _quantity = quantity;
        }

         public double CalculatePrice()
        {
            double totalPrice = _price * _quantity;
            return totalPrice;
        }

        public string GetProductName()
        {
            return _prodName;
        }
        public string GetProductID()
        {
            return _prodID;
        }
    }
}