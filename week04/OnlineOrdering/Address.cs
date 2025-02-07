using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineOrdering
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _state;
        private string _country;
        private bool US = false;

        public bool IsUSA()
        {
            if (_country == "USA")
            {
                US = true;
            }
            else
            {
                US = false;
            }
            return US;
        }

        public Address(string street, string city, string state, string country)
        {
            _street = street;
            _city = city;
            _state = state;
            _country = country;

        }

        public string DisplayAddress()
        {
            return $"{_street}\n{_city}, {_state}\n{_country}";
        }
    }
}