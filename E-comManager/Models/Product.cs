namespace E_comManager.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
