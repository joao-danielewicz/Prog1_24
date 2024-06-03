namespace _240527_01.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName {get; set;}
        public string? Description {get; set;}
        public float CurrentPrice {get; set;}

        public Product(){}
        public Product(int productId, string? productName, string? description, float currentPrice) {
            ProductId = productId;
            ProductName = productName;
            Description = description;
            CurrentPrice = currentPrice;
        }
        
        public bool Validate(){
            var isValid = true;
            if(string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            return isValid;
        }
    }
}