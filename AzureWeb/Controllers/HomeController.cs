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

namespace AzureWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICosmosDbService cosmosDbService)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService;
        }

        [ActionName("Index")]
        public IActionResult Index()
        {
            CidadaoModel cidadao = new CidadaoModel();
            return View(cidadao);

            //todo: caso queira buscar os dados do db
            //return View(await _cosmosDbService.GetItemsAsync("SELECT * FROM c"));
        }

        [ActionName("EnvioDados")]
        public async Task<ActionResult> EnvioDadosAsync(CidadaoModel dados)
        {
            try
            {
                dados.id = Guid.NewGuid().ToString();

                if (!String.IsNullOrEmpty(dados.texto))
                {
                    // TODO: Chamar o serviço
                    var retorno = await processarTextoAsync(dados);

                    if (retorno.Documents.Any())
                    {
                        dados.sentimento = retorno.Documents[0].Score.ToString();
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

            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private async Task<SentimentBatchResult> processarTextoAsync(CidadaoModel cidadao)
        {
            string SubscriptionKey = "";

            const string Endpoint = "";

            TextAnalyticService analisadorTexto = new TextAnalyticService(Endpoint, SubscriptionKey);
            var retorno = await analisadorTexto.RunSentimentAnalysisAsync(cidadao);
            //await analisadorTexto.RunRecognizeEntitiesAsync(cidadao);
            //await analisadorTexto.RunLanguageDetectionAsync(cidadao);
            //await analisadorTexto.RunKeyPhraseExtractionAsync(cidadao);                       

            return retorno;
        }

        private void processarAudio(CidadaoModel cidadao)
        {
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
