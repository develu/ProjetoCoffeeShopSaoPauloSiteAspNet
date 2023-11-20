using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjetoCoffeeShoopSaoPaulo.Bilioteca.Filters
{
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Login") == null)
            {
                if (context.Controller != null)
                {
                    Controller controlador = context.Controller as Controller;
                    controlador.TempData["MensagemErro"] = "Faça o Login para ter permissão de entrar nessa página!";
                }

                context.Result = new RedirectToActionResult("Login", "Admin", null);
            }


        }

    }
}
