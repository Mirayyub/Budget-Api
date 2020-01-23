using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Budget.ViewModels
{
    public class CategoryAction
    {
        [Required(ErrorMessage = "Category cant be null")]
        [MaxLength(50, ErrorMessage = "Category can have a maximum of 50 characters")]
        public string Name { get; set; }
    }
}