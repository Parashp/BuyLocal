using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductID { set; get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal  Quantity { get; set; }
        public string PhotoID { get; set; }
        public bool IsAvailable { get; set; }
        public IList<ProductPrice> Prices { get; set; }
        public DateTime DateCreated { get; set; }        
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
