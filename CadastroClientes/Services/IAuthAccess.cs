namespace CadastroClientes.Services
{
    public interface IAuthAccess
    {
        Task<bool> Autheticate(string email, string password);
        Task LogOut();
    }
}
