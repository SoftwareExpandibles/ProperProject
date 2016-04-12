using BusinessModel.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessModel
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string EmailAddress { get; set; }
        public string CellNum { get; set; }
        public ICollection<Order> CustomerHistory { get; set; }
    }
}