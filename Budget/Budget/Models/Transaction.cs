using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Models
{
    public enum PaymentType
    {
        Expence,
        Income
    }
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public PaymentType Type { get; set; }

        [Required, Column(TypeName = "money")]
        public decimal Value { get; set; }

        [MaxLength(500)]
        public string Desc { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public Category Category { get; set; }
    }
}