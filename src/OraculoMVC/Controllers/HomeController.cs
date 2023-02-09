using Microsoft.AspNetCore.Mvc;
using OraculoApi.Interfaces;
using OraculoApi.Model.OpenAI;
using OraculoMVC.Models;
using System.Diagnostics;

namespace OraculoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOpenAITextService _openAIService;

        public HomeController(ILogger<HomeController> logger, IOpenAITextService openAIService)
        {
            _logger = logger;
            _openAIService = openAIService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string pergunta)
        {
            var request = new OpenAIRequest(pergunta);
            var response = await _openAIService.CompletePrompt(request);
            
            if (response != null )
            {
                if (response.Error != null)
                {
                    ViewBag.Pergunta = pergunta;
                    ViewBag.Error = response.Error.Message.ToString();
                }
                else if (response.Choices != null)
                {
                    ViewBag.Pergunta = pergunta;
                    ViewBag.Resposta = response.Choices.Select(a => a.Text).FirstOrDefault();
                }
            }
            
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}