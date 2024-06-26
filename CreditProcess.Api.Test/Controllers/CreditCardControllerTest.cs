using CreditProcess.Api.Controllers;
using CreditProcess.Api;
using CreditProcess.ApplicationCore;
using FluentAssertions;
using Microsoft.AspNetCore.Cors.Infrastructure;

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
    [InlineData("5555555555554444")]
    [InlineData("4012888888881881")]
    public void ValidateCreditCard_Returns_True(string value)
    {
        //arrange
        CreditCardDto model = new CreditCardDto();
        model.CardNumber = value;
        cardService.Setup(x => x.ValidateCardAsync(model.CardNumber)).ReturnsAsync(true);    
        //act
        var cardResult = cardController.ValidateCreditCard(model);

        ////assert
        cardResult.Result.Data.Should().Be(true);
    }

    [Theory]
    [InlineData("26")]
    [InlineData("75")]       
    public void ValidateCreditCard_Returns_False(string value)
    {
        //arrange
        CreditCardDto model = new CreditCardDto();
        model.CardNumber = value;
        cardService.Setup(x => x.ValidateCardAsync(model.CardNumber)).ReturnsAsync(false);
        //act
        var cardResult = cardController.ValidateCreditCard(model);

        ////assert
        cardResult.Result.Data.Should().Be(false);
    }

    [Theory]
    [InlineData("")]
    public void ValidateCardAsync_EmtyValue_Returns_False(string value)
    {
        CreditCardDto model = new CreditCardDto();
        model.CardNumber = value;
        Assert.False(false, "Invalid card");
    }
}
  