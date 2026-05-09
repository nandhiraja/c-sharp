namespace RepositoryPatternApp.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"[Product] ID: {Id}, Name: {Name}, Price: ${Price:F2}";
        }
    }
}
