namespace _240401_01.Models
{
    public class Order
    {
        public Customer Customer {get; set;}
        public DateTime OrderDate {get; set;}
        public string ShippingAddress {get; set;}
        public List<OrderItem> OrderItems {get; set;}
        public bool Validate(){
            return true;
        }
        public Order Retrieve(){
            return new Order(); //retorno encapsulado, retorna o próprio objeto
        }
        public void Save(Order order){
            
        }
    }
}