using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240422_01.Models;
using _240422_01.Data;

namespace _240422_01.Repository
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

        public List<Product> RetrieveAll(){
            return DataSet.Products;
        }
    }
}