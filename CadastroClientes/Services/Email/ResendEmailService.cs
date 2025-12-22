
using Resend;

namespace CadastroClientes.Services.Email
{
    public class ResendEmailService : IEmailService
    {
        private readonly IResend _resend;

        public ResendEmailService(IConfiguration config)
        {
            var apiKey = config["Resend:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey), "A chave da API não pode ser nula ou vazia.");
            }

            _resend = ResendClient.Create(apiKey);
        }

        public async Task EnviarAsync(string para, string assunto, string html, byte[]? anexos = null, string? nomeAnexo = null)
        {
            var message = new EmailMessage
            {
                From = "Planserv <no-reply@mail.seudominio.com.br>",
                To = para,
                Subject = assunto,
                HtmlBody = html
            };

            if (anexos != null && nomeAnexo != null)
            {
                message.Attachments = new List<EmailAttachment>
                    {
                        new EmailAttachment
                        {
                            Filename = nomeAnexo,
                            Content = Convert.ToBase64String(anexos)
                        }
                    };
            }

            await _resend.EmailSendAsync(message);
        }
    }
}