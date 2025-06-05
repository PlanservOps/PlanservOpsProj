namespace CadastroClientes.Services
{
    public interface IAuthAccess
    {
        Task<bool> Autheticate(string email, string password);
        Task <bool> RegisterUser(string email, string password);
        Task LogOut();
    }
}
