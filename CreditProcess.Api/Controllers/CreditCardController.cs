using CreditProcess.Api.EndpointDtos;
using CreditProcess.ApplicationCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CreditProcess.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditCardController : ControllerBase
{
    private readonly ICardValidationService _cardService;
    public CreditCardController(ICardValidationService cardService)
    {
        _cardService = cardService;
    }

    [HttpPost]
    public async Task<bool> ValidateCreditCard([FromBody] CreditCardDto model)
    {
        bool result = await _cardService.ValidateCardAsync(model.CardNumber);
        return result;
    }
}

