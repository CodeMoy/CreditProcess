using CreditProcess.ApplicationCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CreditProcess.Api.Controllers;
/// <summary>
/// One action method created for credit card validation
/// <example>
/// If we provide card number it will check card number and return true or false inside ApiResponse class:
/// <code>
/// ValidateCreditCard("4888") will return false, 
/// ValidateCardAsync("3056930009020004") will return true
/// </code>
/// </example>
/// </summary>
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
    public async Task<ApiResponse<bool>> ValidateCreditCard([FromBody] CreditCardDto model)
    {
        string _message = string.Empty;
        bool _result=false;
        if (!String.IsNullOrEmpty(model.CardNumber))
        {
            _result = await _cardService.ValidateCardAsync(model.CardNumber);
            _message = _result ? "Valid card number!" : "Invalid card number!";
        }

        var apiResponse = new ApiResponse<bool>
        {
            StatusCode = 200,
            Message = _message,
            Data = _result
        };
        return apiResponse;
    }
}

