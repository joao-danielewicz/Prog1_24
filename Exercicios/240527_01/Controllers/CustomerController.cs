using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240527_01.Models;
using _240527_01.Repository;
using _240527_01.Utils;

namespace _240527_01.Controllers
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

        public bool ExportToDelimited(){
            List<Customer> list = Get();

            string fileContent = string.Empty;
            foreach(var c in list){
                fileContent += $"{c.PrintToExportDelimited()}\n";
            }

            string fileName = $"Customer_{DateTimeOffset.Now.ToUnixTimeSeconds()}.txt";
            return ExportToFile.SaveToDelimitedTxt(fileName, fileContent);
        }

    }
}