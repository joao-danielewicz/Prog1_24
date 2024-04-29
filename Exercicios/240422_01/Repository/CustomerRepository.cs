using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240422_01.Models;
using _240422_01.Data;

namespace _240422_01.Repository
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
        
        public List<Customer> RetrieveAll(){
            return DataSet.Customers;
        }

        public List<Customer> SearchBy(string SearchTerm){
            List<Customer> customers = new();
            foreach(var c in DataSet.Customers){
                if(c.Name.ToLower().Contains(SearchTerm.ToLower())){
                    customers.Add(c);
                }
            }
            return customers;
        }
    }
}