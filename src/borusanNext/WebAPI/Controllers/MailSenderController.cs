
using Application.Features.MailSender;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MailSenderController : ControllerBase
{
    private readonly IMediator _mediator;

    public MailSenderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SendMail([FromBody] MailSenderCommand command)
    {
        var result = await _mediator.Send(command);
        if (result)
        {
            return Ok("Mail başarılı bir şekilde gönderildi");
        }

        return StatusCode(500, "Mail gönderme işlemi başarısız oldu.");
    }
}
