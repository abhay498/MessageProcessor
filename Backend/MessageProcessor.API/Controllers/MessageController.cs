using Microsoft.AspNetCore.Mvc;
using MessageProcessor.Application.Interfaces;

namespace MessageProcessor.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpPost("process")]
    public IActionResult ProcessMessage([FromBody] MessageRequest request)
    {
        var result = _messageService.ProcessMessage(request.Message);

        return Ok(result);
    }
}

public class MessageRequest
{
    public string Message { get; set; } = string.Empty;
}