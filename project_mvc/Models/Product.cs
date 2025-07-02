using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace project_mvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(5)]
        [MaxLength(100,ErrorMessage ="the product can't exued 100 charachter")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0,10000)]
        public decimal Price { get; set; }
        [Range(0,500)]
        public int Quantity { get; set; }
        public string? Image { get; set; }
        [Range(0, 5)]
        public double Rate { get; set; }
<<<<<<< HEAD
        public int? CompanyId { get; set; }
=======
        public int CompanyId { get; set; }
>>>>>>> 5f29b9ff7e1d1e78649a68071e7e585a34789e72
        [ValidateNever]
        public Company Company { get; set; }
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
    }
}
