using System.Net.Http;

namespace TranslatorApp.FunTranslation
{
    public class ApiConfigs
    {
        public string GetURI(string path)
            => "https://api.funtranslations.com/translate/" + path;

        public HttpResponseMessage GET(string URL)
        {
            using HttpClient client = new HttpClient();
            var result = client.GetAsync(URL);
            result.Wait();

            return result.Result;
        }
    }
}
