namespace _240527_01.Models
{
    public class Customer
    {
        public int CustomerId {get; set;} = 0;
        public string Name {get; set;} = "Não definido";
        public string EmailAddress {get; set;} = "Não definido";
        public List<Address> Addresses {get; set;} = new();
        public Customer(){}
        public Customer(int id){
            CustomerId = id;
        }
        public Customer(int id, string name, string email){
            CustomerId = id;
            Name = name;
            EmailAddress = email;
        }

        public string PrintToExportDelimited(){
            return $"{CustomerId};{Name};{EmailAddress}";
        }

        public override string ToString() {
            return $"***************\nID: {this.CustomerId}\nNome: {this.Name}\nE-mail: {this.EmailAddress}";
        }
    }
}