using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserID { get; set; }
        public string UserName { get; set; }

        public Guid PersonID { get; set; }
        public Person Person { get; set; }

        public List<UserRole> UserRoles { get; set; }
        public List<Product> Products { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }        
    }
}
