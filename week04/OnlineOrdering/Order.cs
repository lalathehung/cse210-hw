using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineOrdering
{
    public class Order
    {
        private double _totalOrderPrice;
        private int _shippingCost;
        private Customer _customer;
        private double prodTotal;
        private List<Product> _productList = new List<Product>();

         public void AddProduct(Product product)
        {
            _productList.Add(product);
        }
        
        public Order(Customer customer, List<Product> productList)
        {
            _customer = customer;
            _productList = productList;
        }

        public double OrderTotal()
        {
            if (_customer.LivesUSA())
            {
                _shippingCost = 5;
            }
            else
            {
                _shippingCost = 35;
            }
            double sum = 0;
            foreach(Product product in _productList){
                prodTotal = product.CalculatePrice();
                sum += prodTotal;
            }

            _totalOrderPrice = sum + _shippingCost;
            return _totalOrderPrice;
        }
        public void PackingLabel()
        {
            Console.WriteLine("\nPACKING LABEL: \n");
            foreach(Product product in _productList){
                string thisProductName = product.GetProductName();
                string thisProductID = product.GetProductID();
                
                Console.WriteLine($"Product: {thisProductName}\nID:{thisProductID}");
            }
        }
        public void ShippingLabel()
        {
            string thisCustomer = _customer.DisplayCustomerName();
            string thisAddress = _customer.DisplayCustomerAddress();
            Console.WriteLine("\nSHIPPING LABEL:");
            Console.WriteLine($"\n{thisCustomer}");
            Console.WriteLine($"{thisAddress}\n");
            
        }
    }
}