using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Budget.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        public User User { get; set; }
    }
}