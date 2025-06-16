namespace CadastroClientes.ViewModels
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

}
