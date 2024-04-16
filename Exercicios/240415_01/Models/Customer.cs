namespace _240415_01.Models
{
    public class Customer
    {
        public int CustomerId {get; set;} = 0;
        public string Name {get; set;} = "Não definido";
        public string EmailAddress {get; set;} = "Não definido";
        public List<Address> Addresses {get; set;} = null;
        public Customer(){}
        public Customer(int id){
            CustomerId = id;
        }
        public Customer(int id, string nome, string email){
            CustomerId = id;
            Name = nome;
            EmailAddress = email;
        }


        public bool Validate(){
            var isValid = true;
            if(string.IsNullOrWhiteSpace(Name)) isValid = false;
            return isValid;
        }
    }
}