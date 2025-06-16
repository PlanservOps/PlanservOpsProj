using System.ComponentModel.DataAnnotations;

namespace CadastroClientes.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirma senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O campo Role é obrigatório.")]
        public string Role { get; set; }

        public RegisterViewModel()
        {
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            Role = string.Empty;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Email) &&
                   !string.IsNullOrEmpty(Password) &&
                   Password == ConfirmPassword &&
                   !string.IsNullOrEmpty(Role);
        }
    }
}
