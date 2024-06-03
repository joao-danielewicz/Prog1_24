namespace _240603_01.Models
{
    public class OrderItem
    {
        public int Id { get; set;}
        public Product Product {get; set;}
        public int Quantity {get; set;}
        public float PurchasePrice {get; set;}
        public bool Validate(){
            return true;
        }
        public OrderItem Retrieve(){
            return new OrderItem(); //retorno encapsulado, retorna o próprio objeto
        }
        public void Save(OrderItem orderItem){
            
        }
    }
}