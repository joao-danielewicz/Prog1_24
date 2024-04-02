namespace _240401_01.Models
{
    public class Product
    {
        public string ProductName {get; set;}
        public string Description {get; set;}
        public float CurrentPrice {get; set;}
        public bool Validate(){
            return true;
        }
        public Product Retrieve(){
            return new Product(); //retorno encapsulado, retorna o próprio objeto
        }
        public void Save(Product product){
            
        }
    }
}