using System.Text;
using System.Text.Json;
using SlackAlerting.Models;

namespace SlackAlerting.Client;

public class SlackClient
{
    private readonly HttpClient _httpClient;
    private readonly SlackAlertConfiguration _config;

    public SlackClient(HttpClient httpClient, SlackAlertConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task SendMessageAsync(string message)
    {
        var payload = new { text = message };
        var jsonPayload = JsonSerializer.Serialize(payload);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(_config.WebhookUrl, content);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to send message to Slack. Status: {response.StatusCode}");
        }
    }
}