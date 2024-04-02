namespace _240401_01.Models
{
    public class Customer
    {
        public int CustomerId {get; set;}
        public string Name {get; set;}
        public string EmailAddress {get; set;}
        public string HomeAddress {get; set;}
        public string WorkAddress {get; set;}

        public Customer(){}
        public Customer(int id){
            CustomerId = id;
        }


        public bool Validate(){
            var isValid = true;
            if(string.IsNullOrWhiteSpace(Name)) isValid = false;
            return isValid;
        }
        public Customer Retrieve(int customerId){
            return new Customer(); //retorno encapsulado, retorna o próprio objeto
        }
        public List<Customer> Retrieve(){
            return new List<Customer>();
        }
        public void Save(Customer customer){
            
        }
    }
}