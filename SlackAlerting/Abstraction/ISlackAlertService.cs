namespace SlackAlerting.Abstraction;

public interface ISlackAlertService
{
    Task SendMessageAsync(string message);
}