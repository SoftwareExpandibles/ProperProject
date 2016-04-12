using BusinessModel;
using BusinessModel.Models;
using System.ComponentModel.DataAnnotations;

namespace BlackSource
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}