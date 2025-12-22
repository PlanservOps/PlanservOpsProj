namespace CadastroClientes.Services.Email
{
    public interface IEmailService
    {
        Task EnviarAsync(
            string para,
            string assunto,
            string html,
            byte[]? anexos = null,
            string? nomeAnexo = null
            );
    }
}
