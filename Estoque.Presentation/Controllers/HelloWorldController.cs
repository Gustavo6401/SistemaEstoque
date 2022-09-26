using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Presentation.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
        {
            return "Hello World!";
        }
    }
}
