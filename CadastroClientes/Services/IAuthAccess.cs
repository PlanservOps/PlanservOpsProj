namespace CadastroClientes.Services
{
    public interface IAuthAccess
    {
        Task<string> Autheticate(string email, string password);
        Task <bool> RegisterUser(string email, string password);
        Task LogOut();
    }
}
