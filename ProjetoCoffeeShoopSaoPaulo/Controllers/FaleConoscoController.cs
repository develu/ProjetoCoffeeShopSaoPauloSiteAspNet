using Microsoft.AspNetCore.Mvc;
using ProjetoCoffeeShoopSaoPaulo.Bilioteca.Mail;
using ProjetoCoffeeShoopSaoPaulo.Models.FaleConosco;
using ProjetoCoffeeShopSaoPauloServices.interfaces.config;

namespace ProjetoCoffeeShoopSaoPaulo.Controllers
{
    public class FaleConoscoController : Controller
    {

        private IAppSettings _appSettings;

        public FaleConoscoController(IAppSettings appSettings)
        {
            this._appSettings = appSettings;
        }

        public IActionResult Index()
        {
            ViewBag.FaleConosco = new FaleConosco();
            return View();

        }
        public IActionResult ReceberContato([FromForm] FaleConosco faleconosco )
        {
            if (ModelState.IsValid)
            {
                // string conteudo = string.Format("Nome: {0}<br , E-mail: {1},Assunto: {2}<br , Mensagem: {3}", faleconosco.Nome, faleconosco.Email,faleconosco.Assunto, faleconosco.Mensagem);
                //return new ContentResult() { Content = conteudo };

                ViewBag.FaleConosco = new FaleConosco();
                EnviarEmail.EnviarMensagemFaleConosco(faleconosco, _appSettings.SendMailPassword);
                ViewBag.Mensagem = "Mensagem enviada com sucesso!";
                return View("Index");
            }
            else
            {

                ViewBag.FaleConosco = faleconosco;
                return View("Index");
            }
            
        }
      
        
    }
}
