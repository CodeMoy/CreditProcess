using CreditProcess.ApplicationCore;
using FluentAssertions;

namespace CreditProcess.Services.Test;
public class CardValidationServiceTest
{
    private readonly ICardValidationService cardService;
    public CardValidationServiceTest()
    {
        cardService = new CardValidationService();
    }
    [Theory]
    [InlineData("123A780")]
    [InlineData("123A782")]
    [InlineData("123A783")]
    [InlineData("123A784")]
    public async Task ValidateCardAsync_ReturnsFalse(string value)
    {
        var result = await cardService.ValidateCardAsync(value);
        Assert.False(result);
    }

    [Theory]
    [InlineData("5555555555554444")]    // MasterCard test credit card number
    [InlineData("4012888888881881")]    // Visa test credit card number
    [InlineData("3056930009020004")]    // Diners Club test credit card number
    [InlineData("3566111111111113")]    // JCB test credit card number
    [InlineData("808401234567893")]     // NPI (National Provider Identifier), including 80840 prefix
    public async Task ValidateCardAsync_ReturnsTrue(string value)
    {
       var result= await cardService.ValidateCardAsync(value);
       Assert.True(result);
    }
}

