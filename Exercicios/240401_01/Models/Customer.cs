namespace _240401_01.Models
{
    public class Customer
    {
        public int CustomerId {get; set;} = 0;
        public string Name {get; set;} = "Não definido";
        public string EmailAddress {get; set;} = "Não definido";
        public string HomeAddress {get; set;} = "Não definido";
        public string WorkAddress {get; set;} = "Não definido";

        public Customer(){}
        public Customer(int id){
            CustomerId = id;
        }
        public Customer(int id, string nome, string email, string casa, string trabalho){
            CustomerId = id;
            Name = nome;
            EmailAddress = email;
            HomeAddress = casa;
            WorkAddress = trabalho;
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