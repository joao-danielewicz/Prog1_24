using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240429_01.Repository;
using _240429_01.Models;
namespace _240429_01.Controllers
{
    public class ProductController{
        private ProductRepository productRepository;

        public ProductController(){
            productRepository = new();
        }

        public void Insert(Product product){
            productRepository.Save(product);
        }
        public Product Get(int id){
            return productRepository.Retrieve(id);
        }
        public List<Product> Get(){
            return productRepository.RetrieveAll();
        }
    }
}