namespace MyBussSiteAPIs.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DeliveryTimeSpan { get; set; }
        public int CategoryId { get; set; }
    }
}
