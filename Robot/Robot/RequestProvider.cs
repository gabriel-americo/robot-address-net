using System.Net.Http.Json;
using System.Text.Json;

namespace Robot
{
    public class RequestProvider
    {
        private readonly Lazy<HttpClient> _httpClient =
            new(() =>
            {
                var httpCliente = new HttpClient();
                httpCliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                return httpCliente;
            }, LazyThreadSafetyMode.ExecutionAndPublication);

        public async Task<TResult?> GetAsync<TResult>(string url)
        {
            var httpClient = _httpClient.Value;
            try
            {
                var response = await httpClient.GetAsync(url).ConfigureAwait(false);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return default;
                }

                return await response.Content.ReadFromJsonAsync<TResult>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return default;
            }
        }

        public async Task<TResult?> PutAsync<TResult>(string url, TResult data)
        {
            var httpClient = _httpClient.Value;
            var content = new StringContent(JsonSerializer.Serialize(data));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await httpClient.PutAsync(url, content).ConfigureAwait(false);

            return await response.Content.ReadFromJsonAsync<TResult>();
        }

    }
}