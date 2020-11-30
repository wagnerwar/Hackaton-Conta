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

        public async Task<string> RunSpeechToTextAsync(string path)        
        {
            string completePath = path + "\\file.wav";
            if (File.Exists(completePath))
            {
                var speechConfig = SpeechConfig.FromSubscription(endpoint, key1);
                //string path = @"c:\temp\file.wav";
                using var audioConfig = AudioConfig.FromWavFileInput(completePath);                
                using var recognizer = new SpeechRecognizer(speechConfig, "pt-BR", audioConfig);
                var result = await recognizer.RecognizeOnceAsync();                               
              
                return result.Text;
            }           
            return "";
        }
    }
}
