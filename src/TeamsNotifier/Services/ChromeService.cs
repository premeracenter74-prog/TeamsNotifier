using System.Net.Http;
using System.Text.Json;

namespace TeamsNotifier.Services;

public class ChromeService
{
    private readonly HttpClient _client = new();

    public async Task<List<BrowserTab>> GetTabsAsync()
    {
        try
        {
            string json = await _client.GetStringAsync("http://127.0.0.1:9222/json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var tabs = JsonSerializer.Deserialize<List<BrowserTab>>(json, options);

            return tabs ?? new List<BrowserTab>();
        }
        catch
        {
            return new List<BrowserTab>();
        }
    }

    public async Task<BrowserTab?> FindTeamsTabAsync()
    {
        var tabs = await GetTabsAsync();

        return tabs.FirstOrDefault(x =>
            x.Url.Contains("teams.microsoft", StringComparison.OrdinalIgnoreCase));
    }

    public async Task<bool> IsTeamsRunning()
    {
        return await FindTeamsTabAsync() != null;
    }
}
