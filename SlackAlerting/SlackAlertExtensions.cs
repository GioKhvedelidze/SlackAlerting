using Microsoft.Extensions.DependencyInjection;
using SlackAlerting.Client;
using SlackAlerting.Abstraction;
using SlackAlerting.Models;
using SlackAlerting.Services;

namespace SlackAlerting;

public static class SlackAlertExtensions
{
    public static IServiceCollection AddSlackAlerting(this IServiceCollection services, string? webhookUrl)
    {
        //DI
        services.AddHttpClient<SlackClient>();
        services.AddSingleton(new SlackAlertConfiguration { WebhookUrl = webhookUrl });
        services.AddTransient<ISlackAlertService, SlackAlertService>();

        return services;
    }
}