using MessageProcessor.Application.Interfaces;
using MessageProcessor.Domain.Entities;

namespace MessageProcessor.Application.Services;

public class MessageService : IMessageService
{
    public MessageResult ProcessMessage(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return new MessageResult
            {
                Result = "Message cannot be empty."
            };
        }

        return new MessageResult
        {
            Result = $"Backend processed: {message.ToUpper()}"
        };
    }
}