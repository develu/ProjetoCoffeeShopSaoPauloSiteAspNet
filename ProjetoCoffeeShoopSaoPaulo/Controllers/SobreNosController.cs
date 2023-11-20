using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCoffeeShoopSaoPaulo.Controllers
{
    public class SobreNosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
