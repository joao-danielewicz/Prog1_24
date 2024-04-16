using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240415_01.Models;
using _240415_01.Data;

namespace _240415_01.Repository
{
    public class AddressRepository
    {
        public void Save(Address address){
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
    }
}