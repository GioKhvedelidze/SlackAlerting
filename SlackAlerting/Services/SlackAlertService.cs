using SlackAlerting.Abstraction;
using SlackAlerting.Client;

namespace SlackAlerting.Services;

public class SlackAlertService : ISlackAlertService
{
    private readonly SlackClient _slackClient;

    public SlackAlertService(SlackClient slackClient)
    {
        _slackClient = slackClient;
    }
    
    public async Task SendMessageAsync(string message)
    {
        await _slackClient.SendMessageAsync(message);
    }
}