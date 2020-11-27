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
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AzureWeb.CognitiveServices
{
    public class SpeechSynthesisService
    {
        private string endpoint, key1, key2;
        private string region = "eastus";
        public SpeechSynthesisService(string endpoint, string key1, string key2 )
        {
            this.endpoint = endpoint;
            this.key1 = key1;
            this.key2 = key2;
        }

        public async Task RunSpeechToTextAsync(CidadaoModel cidadao,IFormFile arquivo)
        {
            var config = SpeechConfig.FromSubscription(key1, region);
            var caminhoArquivo = Path.GetTempFileName();

            var reader = new BinaryReader(File.OpenRead(caminhoArquivo));
            using var audioInputStream = AudioInputStream.CreatePushStream();
            using var audioConfig = AudioConfig.FromStreamInput(audioInputStream);

            byte[] readBytes;
            do
            {
                readBytes = reader.ReadBytes(1024);
                audioInputStream.Write(readBytes, readBytes.Length);
            } while (readBytes.Length > 0);


            using (var recognizer = new SpeechRecognizer(config, audioConfig))
            {
                var result = recognizer.RecognizeOnceAsync();

            }

        }
    }
}
