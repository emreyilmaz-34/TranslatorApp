using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TranslatorApp.Web.DTOs;

namespace TranslatorApp.Web.ApiService
{
    public class LanguageApiService
    {
        private readonly HttpClient _httpClient;

        public LanguageApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<LanguageDto>> GetAllAsync()
        {
            IEnumerable<LanguageDto> languageDtos;

            var response = await _httpClient.GetAsync("languages");

            if (response.IsSuccessStatusCode)
            {
                languageDtos = JsonConvert.DeserializeObject<IEnumerable<LanguageDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                languageDtos = null;
            }

            return languageDtos;
        }
        public async Task<LanguageDto> AddAsync(LanguageDto languageDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(languageDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("languages", stringContent);

            if (response.IsSuccessStatusCode)
            {
                languageDto = JsonConvert.DeserializeObject<LanguageDto>(await response.Content.ReadAsStringAsync());

                return languageDto;
            }
            else
            {
                //log
                return null;
            }
        }
        public async Task<LanguageDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"languages/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<LanguageDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                //log
                return null;
            }
        }
        public async Task<bool> Update(LanguageDto languageDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(languageDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("languages", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                //log
                return false;
            }
        }
        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"languages/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            {
                return false;
            }
        }
    }
    
}
