using BusinessModel.Models;
using System.ComponentModel.DataAnnotations;

namespace BusinessModel
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}