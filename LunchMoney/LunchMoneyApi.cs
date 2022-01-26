using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace LunchMoneyLoader.LunchMoney;

public sealed class LunchMoneyApi : IDisposable
{
    private const string _url = @"https://dev.lunchmoney.app";
    private readonly HttpClient _httpClient;

    public LunchMoneyApi(string accessToken)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {accessToken}");
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public void Dispose()
    {
        _httpClient.Dispose();
    }

    private async Task<T> Get<T>(string path)
    {
        var response = await _httpClient.GetAsync($"{_url}{path}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json) ?? throw new InvalidOperationException("Request null");
        }

        throw new InvalidOperationException("Request failed");
    }

    private async Task Post<T>(string path, T content)
    {
        var json = JsonConvert.SerializeObject(content);
        var body = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_url}{path}", body);

        if (response.IsSuccessStatusCode)
        {
            var responseJson = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseJson);   
        }
        else
        {
            throw new InvalidOperationException("Failed to post!");
        }
    }

    public async Task<Asset[]> GetAssets()
    {
        var response = await Get<AssetsResponse>("/v1/assets");
        return response.Assets;
    }

    public async Task<Category[]> GetCategories()
    {
        var response = await Get<CategoriesResponse>("/v1/categories");
        return response.Categories;
    }

    public async Task PostTransactions(Transaction[] transactions)
    {
        var payload = new TransactionInsert
        {
            ApplyRules = false,
            CheckForRecurring = false,
            DebitAsNegative = true,
            Transactions = transactions
        };
        await Post("/v1/transactions", payload);
    }
}
