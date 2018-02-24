using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ComercioElectronico.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("ComercioElectronicoContext")
        {
        }
    }

    public class Login
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Recordarme?")]
        public bool RememberMe { get; set; }
    }

    public class Register
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar clave")]
        [Compare("Password", ErrorMessage = "Las claves no coiniciden")]
        public string ConfirmPassword { get; set; }
    }

    public class LocalPassword
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Clave actual")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva clave")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar clave")]
        [Compare("NewPassword", ErrorMessage = "Las claves no coinciden")]
        public string ConfirmPassword { get; set; }
    }
}