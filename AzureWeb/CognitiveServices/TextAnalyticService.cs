using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using AzureWeb.Models;

namespace AzureWeb.CognitiveServices
{
    public class TextAnalyticService
    {
        private string endpoint, key;

        public TextAnalyticService(string endpoint, string key)
        {
            this.endpoint = endpoint;
            this.key = key;
        }


        public async Task<SentimentBatchResult> RunSentimentAnalysisAsync(CidadaoModel cidadao)
        {
            var credentials = new ApiKeyServiceClientCredentials(key);
            var client = new TextAnalyticsClient(credentials)
            {
                Endpoint = endpoint
            };

            // The documents to be analyzed. Add the language of the document. The ID can be any value.
            var inputDocuments = new MultiLanguageBatchInput(
                new List<MultiLanguageInput>
                {
                     new MultiLanguageInput("1", cidadao.texto, "pt"),
                });

            var result = await client.SentimentBatchAsync(inputDocuments);

            // Printing sentiment results
            // Console.WriteLine("===== Sentiment Analysis =====\n");

            //foreach (var document in result.Documents)
            //{

            //    // Console.WriteLine($"Document ID: {document.Id} , Sentiment Score: {document.Score:0.00}");
            //}

            return result;

        }

        public async Task RunRecognizeEntitiesAsync(CidadaoModel cidadao)
        {
            var credentials = new ApiKeyServiceClientCredentials(key);
            var client = new TextAnalyticsClient(credentials)
            {
                Endpoint = endpoint
            };

            // The documents to be submitted for entity recognition. The ID can be any value.
            var inputDocuments = new MultiLanguageBatchInput(
                new List<MultiLanguageInput>
                {
                    new MultiLanguageInput("1", cidadao.texto, "pt"),

                });

            var entitiesResult = await client.EntitiesBatchAsync(inputDocuments);


            foreach (var document in entitiesResult.Documents)
            {
                foreach (var entity in document.Entities)
                {
                    foreach (var match in entity.Matches)
                    {
                        // Console.WriteLine($"\t\t\tOffset: {match.Offset},\tLength: {match.Length},\tScore: {match.EntityTypeScore:F3}");
                    }
                }
            }
            // Console.WriteLine();
        }


        public async Task RunLanguageDetectionAsync(CidadaoModel cidadao)
        {
            var credentials = new ApiKeyServiceClientCredentials(key);
            var client = new TextAnalyticsClient(credentials)
            {
                Endpoint = endpoint
            };

            // The documents to be submitted for language detection. The ID can be any value.
            var inputDocuments = new LanguageBatchInput(
                    new List<LanguageInput>
                        {
                            new LanguageInput("1", cidadao.texto),

                        });

            var langResults = await client.DetectLanguageBatchAsync(inputDocuments);

            // Printing detected languages

            foreach (var document in langResults.Documents)
            {
            }
        }

        public async Task RunKeyPhraseExtractionAsync(CidadaoModel cidadao)
        {
            var credentials = new ApiKeyServiceClientCredentials(key);
            var client = new TextAnalyticsClient(credentials)
            {
                Endpoint = endpoint
            };

            var inputDocuments = new MultiLanguageBatchInput(
                        new List<MultiLanguageInput>
                        {
                            new MultiLanguageInput("1", "猫は幸せ", "ja"),
                            new MultiLanguageInput("2", "Fahrt nach Stuttgart und dann zum Hotel zu Fu.", "de"),
                            new MultiLanguageInput("3", "My cat might need to see a veterinarian.", "en"),
                            new MultiLanguageInput("4", "A mi me encanta el fútbol!", "es")
                        });

            var kpResults = await client.KeyPhrasesBatchAsync(inputDocuments);

            // Printing keyphrases

            foreach (var document in kpResults.Documents)
            {

                foreach (string keyphrase in document.KeyPhrases)
                {

                }
            }
        }

    }

    public class ApiKeyServiceClientCredentials : ServiceClientCredentials
    {
        private const string cKeyLbl = "Ocp-Apim-Subscription-Key";

        private readonly string subscriptionKey;
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
        public ApiKeyServiceClientCredentials(string subscriptionKey)

        {

            this.subscriptionKey = subscriptionKey;

        }
        /*public override Task ProcessHttpRequestAsync(HttpRequestMessage

          request, CancellationToken cancellationToken)

        {

            if (request != null)

            {

                request.Headers.Add(cKeyLbl, subscriptionKey);

                return base.ProcessHttpRequestAsync(

                    request, cancellationToken);

            }

            else return null;

        }*/
    }


}
