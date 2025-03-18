using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace WebUI.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _baseUrl = configuration.GetValue<string>("ApiSettings:GatewayUrl") ?? "https://localhost:5003/gateway";
        }

        // Article API methods
        public async Task<List<ArticleModel>> GetAllArticlesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/articles");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ArticleModel>>(content) ?? new List<ArticleModel>();
        }

        public async Task<ArticleModel> GetArticleByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/articles/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ArticleModel>(content) ?? new ArticleModel();
        }

        public async Task<ArticleModel> CreateArticleAsync(ArticleModel article)
        {
            var content = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/articles", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ArticleModel>(responseContent) ?? new ArticleModel();
        }

        public async Task<ArticleModel> UpdateArticleAsync(int id, ArticleModel article)
        {
            var content = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/articles/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ArticleModel>(responseContent) ?? new ArticleModel();
        }

        public async Task DeleteArticleAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/articles/{id}");
            response.EnsureSuccessStatusCode();
        }

        // Writer API methods
        public async Task<List<WriterModel>> GetAllWritersAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/writers");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<WriterModel>>(content) ?? new List<WriterModel>();
        }

        public async Task<WriterModel> GetWriterByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/writers/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WriterModel>(content) ?? new WriterModel();
        }

        public async Task<WriterModel> CreateWriterAsync(WriterModel writer)
        {
            var content = new StringContent(JsonConvert.SerializeObject(writer), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/writers", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WriterModel>(responseContent) ?? new WriterModel();
        }

        public async Task<WriterModel> UpdateWriterAsync(int id, WriterModel writer)
        {
            var content = new StringContent(JsonConvert.SerializeObject(writer), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/writers/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WriterModel>(responseContent) ?? new WriterModel();
        }

        public async Task DeleteWriterAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/writers/{id}");
            response.EnsureSuccessStatusCode();
        }

        // Category API methods
        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/categories");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CategoryModel>>(content) ?? new List<CategoryModel>();
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/categories/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoryModel>(content) ?? new CategoryModel();
        }

        public async Task<CategoryModel> CreateCategoryAsync(CategoryModel category)
        {
            var content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/categories", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoryModel>(responseContent) ?? new CategoryModel();
        }

        public async Task<CategoryModel> UpdateCategoryAsync(int id, CategoryModel category)
        {
            var content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/categories/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoryModel>(responseContent) ?? new CategoryModel();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/categories/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
} 