using CreditProcess.ApplicationCore;
using FluentAssertions;

namespace CreditProcess.Services.Test;
public class CardValidationServiceTest
{
    private readonly ICardValidationService cardService;
    public CardValidationServiceTest()=>cardService = new CardValidationService();
 
    [Theory]
    [InlineData("123A780")]
    [InlineData("123A782")]
    public async Task ValidateCardAsync_ReturnsFalse(string value)
    {
        var result = await cardService.ValidateCardAsync(value);
        result.Should().Be(false);
    }

    [Theory]
    [InlineData("3056930009020004")]     
    [InlineData("808401234567893")]     
    public async Task ValidateCardAsync_ReturnsTrue(string value)
    {
       var result= await cardService.ValidateCardAsync(value);
       result.Should().Be(true);
    }

    [Theory]
    [InlineData("6")]
    [InlineData("7")]
    public async void ValidateCardAsync_CardLengthFalse(string value)
    {
        var result = await cardService.ValidateCardAsync(value);
        result.Should().Be(false);
    }
           
}

