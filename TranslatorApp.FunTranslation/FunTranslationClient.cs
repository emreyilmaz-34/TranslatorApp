using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using TranslatorApp.FunTranslation.Models;
using TranslatorApp.FunTranslation.ResponseModels;

namespace TranslatorApp.FunTranslation
{
    public class FunTranslationClient : ApiConfigs
    {
        HttpClient client = new();

        public string DoTranslate(string text, string language)
        {
            string path = language;

            var translateModel = new TranslateModel{ text = text};

            var json = JsonConvert.SerializeObject(translateModel);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(GetURI(path)),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(request).ConfigureAwait(false);
            var responseInfo = response.GetAwaiter().GetResult();
            var result = responseInfo.Content.ReadAsStringAsync().Result;

            TranslateResponse res = JsonConvert.DeserializeObject<TranslateResponse>(result);

            return res.contents.translated;
        }
    }
}
