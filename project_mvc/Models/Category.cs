using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace project_mvc.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public int ProductId { get; set; }
        [ValidateNever]
        public List<Product> Products { get; set; }
    }
}
