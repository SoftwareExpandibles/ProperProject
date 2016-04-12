using BusinessModel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModel
{
    public class InventoryItems
    {
        [Key]
        public int InventoryId { get; set; }
        public int ReOrderQuantity { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        [Column("Quantity On Hand")]
        [Display(Name = "Quantity On Hand")]
        public int QuantityOnHand { get; set; }


    }
}