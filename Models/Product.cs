using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    [Table("Product")]

    public class Product
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double costPrice { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double sellingPrice { get; set; }

        public string Image { get; set; }
    }
}