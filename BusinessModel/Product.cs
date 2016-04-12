using BusinessModel.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModel
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        [Column("Photo")]
        [Display(Name = "Photos")]
        public string Photo { get; set; }
        [Column("Size")]
        [Display(Name = "Size")]
        public string Size { get; set; }
        [Column("Colour")]
        [Display(Name = "Colour")]
        public string Colour { get; set; }
        [Column("Selling Price")]
        [Display(Name = "Selling Price")]
        public decimal SellingPrice { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public int InventoryId { get; set; }
    }
}