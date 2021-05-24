using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop_Api.Entity
{
    public class Customer
    {

        [Key]
        public int CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public List<Orders> Orders { get; set; }

        public Customer(int customerId, string firstName, string lastName, string email, string phone, string address, string city, string state, string zipCode)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}
