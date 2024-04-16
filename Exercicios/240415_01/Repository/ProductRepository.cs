using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240415_01.Models;
using _240415_01.Data;

namespace _240415_01.Repository
{
    public class ProductRepository
    {
        public void Save(Product product){
            DataSet.Products.Add(product);
        }
        public Product Retrieve(int Id){
            foreach(var p in DataSet.Products){
                if(p.ProductId == Id){
                    return p;
                }
            }
            return null;
        }
    }
}