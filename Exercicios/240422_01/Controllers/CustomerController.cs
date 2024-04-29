using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240422_01.Models;
using _240422_01.Repository;

namespace _240422_01.Controllers
{
    public class CustomerController
    {
        private CustomerRepository customerRepository;

        public CustomerController(){
            customerRepository = new CustomerRepository();
        }
        public void Insert(Customer customer){
            customerRepository.Save(customer);
        }

        public List<Customer> Get(){
            return customerRepository.RetrieveAll();
        }
        public Customer Get(int id){
            return customerRepository.Retrieve(id);
        }

        public List<Customer> Get(string SearchTerm){
            return customerRepository.SearchBy(SearchTerm);
        }

    }
}