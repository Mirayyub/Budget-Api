using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_Budget.ViewModel
{
    public class Register
    {
        [Required(ErrorMessage ="E-Poçt boş ola bilməz")] 
        [MaxLength(50,ErrorMessage ="E-Poçta maksimum 50 xarakter yaza bilərsiniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrəniz boş ola bilməz")]
        [MaxLength(50, ErrorMessage = "Şifrəniz maksimum 50 xarakter yaza bilərsiniz")]
        [MinLength(6,ErrorMessage ="Şifrəniz minumum 6 xarakter olmalıdır")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Ad Soyad boş ola bilməz")]
        [MaxLength(50, ErrorMessage = "Ad Soyad maksimum 50 xarakter yaza bilərsiniz")]
        public string FullName { get; set; }
    }
}