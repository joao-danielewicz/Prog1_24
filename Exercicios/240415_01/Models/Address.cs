using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _240415_01.Models
{

    public enum AddressType{
        Residential,
        Commercial,
        Outher
    }
    public class Address
    {
        public int Id { get; set; }
        public AddressType Type { get; set; }
        public string? Street { get; set; }
        public string? District { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? FederalState { get; set; }
        public string? Country { get; set; }
        public bool IsDefault { get; set; }

        public Address(int id, AddressType addressType, string street, string district, string zipCode, string city, string federalState, string country, bool isDefault){
            Id = id;
            Type = addressType;
            Street = street;
            District = district;
            ZipCode = zipCode;
            City = city;
            FederalState = federalState;
            Country = country;
            IsDefault = isDefault;
        }   
    }
}