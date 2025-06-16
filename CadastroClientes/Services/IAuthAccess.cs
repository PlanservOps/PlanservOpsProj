namespace CadastroClientes.Services
{
    public interface IAuthAccess
    {
        Task<string> Authenticate(string email, string password);
        Task<(bool Success, IEnumerable<string> Errors)> RegisterUser(string email, string password, string role);
        Task LogOut();
    }
}
