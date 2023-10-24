using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.ValueObjects
{
    public class Address
    {
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }

        private Address() { }

        public Address(int country, string state, string city)
        {
            Country = Country;
            State = state;
            City = city;
        }

        public static implicit operator string(Address address)
        {
            return $"{address.Country} - {address.State} - {address.City}";
        }

        //public static bool operator ==(Address address1, Address address2)
        //{
        //    return address1.Country == address2.Country &&
        //        address1.State == address2.State &&
        //        address1.City == address2.City;
        //}
        //public static bool operator !=(Address address1, Address address2)
        //{
        //    return address1.Country != address2.Country ||
        //        address1.State != address2.State ||
        //        address1.City != address2.City;
        //}
    }
}
