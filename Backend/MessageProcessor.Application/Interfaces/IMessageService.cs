using MessageProcessor.Domain.Entities;

namespace MessageProcessor.Application.Interfaces;

public interface IMessageService
{
    MessageResult ProcessMessage(string message);
}