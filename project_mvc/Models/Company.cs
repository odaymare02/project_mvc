﻿using System.ComponentModel.DataAnnotations;

namespace project_mvc.Models
{
    public class Company
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
