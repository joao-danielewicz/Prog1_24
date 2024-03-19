using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace _240318_01.Models
{
    public class Customer
    {
        public int CustomerId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public DateTime BirthDate {get; set;}
        public string EmailAddress {get; set;}

        public List<Address> Addresses = new List<Address>();

        public bool Validate(){
            return true;
        }
    }
}