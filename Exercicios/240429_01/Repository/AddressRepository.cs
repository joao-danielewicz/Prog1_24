using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240429_01.Models;
using _240429_01.Data;

namespace _240429_01.Repository
{
    public class AddressRepository
    {
        public void Save(Address address){
            address.Id = this.GetNextId();
            DataSet.Addresses.Add(address);
        }
        public Address Retrieve(int id){
            foreach(var a in DataSet.Addresses){
                if(a.Id == id){
                    return a;
                }
            }
            return null;
        }
        public List<Address> RetrieveAll(){
            return DataSet.Addresses;
        }

        private int GetNextId(){
            int n = 0;
            foreach(var a in DataSet.Addresses){
                if(a.Id>n){
                    n=a.Id;
                }
            }
            return n++;
        }
    }
}