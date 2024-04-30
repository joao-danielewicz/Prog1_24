using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240429_01.Repository;
using _240429_01.Models;

namespace _240429_01.Controllers
{
    public class AddressController{
        private AddressRepository addressRepository;
        public AddressController(){
            addressRepository = new AddressRepository();
        }
        public Address Insert(Address address){
            addressRepository.Save(address);
            return address;
        }

        public List<Address> Get(){
            return addressRepository.RetrieveAll();
        }
        public Address Get(int id){
            return addressRepository.Retrieve(id);
        }
    }
}