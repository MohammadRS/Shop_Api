﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop_Api.Entity
{
    public class Customer
    {
        public Customer()
        {

        }

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
    }
}
