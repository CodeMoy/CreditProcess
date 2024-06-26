using CreditProcess.Api.Controllers;
using CreditProcess.Api.EndpointDtos;
using CreditProcess.ApplicationCore;
using FluentAssertions;

namespace CreditProcess.Api.Test;

public class CreditCardControllerTest
{
    private readonly Mock<ICardValidationService> cardService;
    private readonly CreditCardController cardController;

    public CreditCardControllerTest()
    {
        cardService = new Mock<ICardValidationService>();
        cardController = new CreditCardController(cardService.Object);
    }

    [Theory]
    [InlineData("26")]
    [InlineData("75")]
    [InlineData("133")]
    [InlineData("5555555555554444")]    // MasterCard test credit card number
    [InlineData("4012888888881881")]    // Visa test credit card number
    [InlineData("3056930009020004")]    // Diners Club test credit card number
    [InlineData("3566111111111113")]    // JCB test credit card number
    [InlineData("808401234567893")]     // NPI (National Provider Identifier), including 80840 prefix
    [InlineData("490154203237518")]
    public void ValidateCreditCard(string value)
    {
        //arrange
        CreditCardDto model = new CreditCardDto();
        model.CardNumber = value;
        cardService.Setup(x => x.ValidateCardAsync(model.CardNumber)).ReturnsAsync(true);    
        //act
        var cardResult = cardController.ValidateCreditCard(model);
        
        ////assert
       if (cardResult != null) Assert.True(cardResult.Result);
    }

    [Theory]
    [InlineData("26")]
    [InlineData("75")]
    [InlineData("133")]
    [InlineData("5555555555554444")]    // MasterCard test credit card number
    [InlineData("4012888888881881")]    // Visa test credit card number
    [InlineData("3056930009020004")]    // Diners Club test credit card number
    [InlineData("3566111111111113")]    // JCB test credit card number
    [InlineData("808401234567893")]     // NPI (National Provider Identifier), including 80840 prefix
    public void ValidateCreditCard_ReturnsFalse(string value)
    {
        //arrange
        CreditCardDto model = new CreditCardDto();
        model.CardNumber = value;
        cardService.Setup(x => x.ValidateCardAsync(model.CardNumber)).ReturnsAsync(false);
        //act
        var cardResult = cardController.ValidateCreditCard(model);

        ////assert
        if (cardResult != null) Assert.False(cardResult.Result);
    }
}
