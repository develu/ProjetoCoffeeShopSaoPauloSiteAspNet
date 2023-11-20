using ProjetoCoffeeShoopSaoPaulo.Models.FaleConosco;
using System.Net;
using System.Net.Mail;

namespace ProjetoCoffeeShoopSaoPaulo.Bilioteca.Mail
{
    public class EnviarEmail
    {        
      
        public static void EnviarMensagemFaleConosco(FaleConosco faleconosco, string pass)
        {
            string conteudo = string.Format("Nome: {0}<br /> E-mail: {1}<br /> Assunto: {2}<br /> Mensagem: {3}", faleconosco.Nome, faleconosco.Email, faleconosco.Assunto, faleconosco.Mensagem);
            //Configurar servidor smtp
            SmtpClient smtp = new SmtpClient(Constants.ServidorSMTP,Constants.PortaSMTP);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Constants.Usuario, pass);

            //Configurar envio de mensagem
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("develudot@hotmail.com");
            mensagem.To.Add("develudot@hotmail.com");
            mensagem.Subject = "Formulario de Contato";
            mensagem.IsBodyHtml = true;
            mensagem.Body = "<h1>Formulário de Contato</h1>" + conteudo;
            smtp.Send(mensagem);
        }
    }
}
