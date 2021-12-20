using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TranslatorApp.Web.DTOs;

namespace TranslatorApp.Web.ApiService
{
    public class TranslationApiService
    {
        private readonly HttpClient _httpClient;

        public TranslationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<TranslationWithLanguageDto>> GetAllAsync()
        {
            IEnumerable<TranslationWithLanguageDto> translationDtos;

            var response = await _httpClient.GetAsync("translations");

            if (response.IsSuccessStatusCode)
            {
                translationDtos = JsonConvert.DeserializeObject<IEnumerable<TranslationWithLanguageDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                translationDtos = null;
            }

            return translationDtos;
        }
        public async Task<TranslationWithLanguageDto> GetWithLanguageAsync(int id)
        {
            var response = await _httpClient.GetAsync($"translations/{id}/language");
            
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TranslationWithLanguageDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                //log
                return null;
            }
        }
        public async Task<TranslationDto> AddAsync(TranslationDto translationDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(translationDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("translations", stringContent);

            if (response.IsSuccessStatusCode)
            {
                translationDto = JsonConvert.DeserializeObject<TranslationDto>(await response.Content.ReadAsStringAsync());

                return translationDto;
            }
            else
            {
                //log
                return null;
            }
        }
        public async Task<TranslationDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"translations/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TranslationDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                //log
                return null;
            }
        }
        public async Task<bool> Update(TranslationDto translationDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(translationDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("translations", stringContent);

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
            var response = await _httpClient.DeleteAsync($"translations/{id}");

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
