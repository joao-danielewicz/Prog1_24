using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240415_01.Models;
using _240415_01.Data;

namespace _240415_01.Repository
{
    public class CustomerRepository
    {

        public void Save(Customer customer){
            DataSet.Customers.Add(customer);
        }

        public Customer Retrieve(int id){
            foreach(var c in DataSet.Customers){
                if(c.CustomerId == id){
                    return c;
                }
            }
            return null;
        }
    }
}