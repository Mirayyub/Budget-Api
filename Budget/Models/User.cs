﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Budget.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [Required, MaxLength(50)]
        public string Fullname { get; set; }

        [MaxLength(100)]
        public string Token { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public List<Category> Categories { get; set; }
    }
}