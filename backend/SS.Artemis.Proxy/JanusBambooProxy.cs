
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using SS.Artemis.Proxy.Models.Janus;

namespace SS.Artemis.Proxy
{
    public interface IJanusProxy
    {
        Task<List<EmployeesProxyModel>> GetEmployees();
    }
    public class JanusBambooProxy : IJanusProxy
    {
        private readonly HttpClient _http;
        private readonly string? _host;
        public JanusBambooProxy(HttpClient http, IConfiguration config)
        {
            _http = http;
            _host = config.GetSection("Proxy").GetSection("JanusBamboo").Value;
        }

        public async Task<List<EmployeesProxyModel>> GetEmployees()
        {
            var request = await _http.GetAsync($"{_host}api/v2/employees?status=1");
            request.EnsureSuccessStatusCode();
            List<EmployeesProxyModel>? result = JsonSerializer.Deserialize<List<EmployeesProxyModel>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return result ?? new List<EmployeesProxyModel>();
        }
    }
}
