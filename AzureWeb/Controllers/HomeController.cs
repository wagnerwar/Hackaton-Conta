using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AzureWeb.Models;
using AzureWeb.CognitiveServices;
using AzureWeb.Services;

using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AzureWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, ICosmosDbService cosmosDbService, IWebHostEnvironment environment)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService;
            _hostingEnvironment = environment;
        }

        [ActionName("Index")]
        public IActionResult Index()
        {
            CidadaoModel cidadao = new CidadaoModel();
            return View(cidadao);
        }

        [ActionName("EnvioDados")]
        public async Task<ActionResult> EnvioDadosAsync(CidadaoModel dados)
        {
            string audioPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            try
            {
                dados.id = Guid.NewGuid().ToString();

                if (dados.tipoEntrada == "Audio") {
                    
                    var retornoAutioTxt = await processarAudioAsync(dados, audioPath);

                    if (!string.IsNullOrEmpty(retornoAutioTxt))
                    {
                        dados.texto = retornoAutioTxt;
                    }
                }

                if (!String.IsNullOrEmpty(dados.texto))
                {
                    var retorno = await processarTextoAsync(dados);

                    if (retorno.Documents.Any())
                    {
                        dados.sentimento = retorno.Documents[0].Score.ToString();
                        dados.sentimento = dados.sentimento.Replace(".", ",");
                        dados.regiao = dados.regioes.ToString();
                        dados.servico = dados.servicos.ToString();
                        await _cosmosDbService.AddItemAsync(dados);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            TempData["mensagem"] = "Enviado com sucesso";
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private async Task<SentimentBatchResult> processarTextoAsync(CidadaoModel cidadao)
        {
            string SubscriptionKey = "9fd291e203fd4108ba6d9489d6de1c66";

            const string Endpoint = "https://textanalyticshackatonlj.cognitiveservices.azure.com/";

            TextAnalyticService analisadorTexto = new TextAnalyticService(Endpoint, SubscriptionKey);
            var retorno = await analisadorTexto.RunSentimentAnalysisAsync(cidadao);
            return retorno;
        }

        private async Task<string> processarAudioAsync(CidadaoModel cidadao,string pathAudio)
        {
            var analiadorAudio = new SpeechSynthesisService("dfe367abf6d54cccb191cc27b34d1845", "eastus", "");
            var retorno = await analiadorAudio.RunSpeechToTextAsync(pathAudio);
            return retorno;

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<JsonResult> Upload(IFormFile file)
        {
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            if (file.Length > 0)
            {
                string filePath = Path.Combine(uploads, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            return Json("Arquivo enviado com sucesso");
        }
    }
}