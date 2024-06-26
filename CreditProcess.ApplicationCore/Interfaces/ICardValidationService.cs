namespace CreditProcess.ApplicationCore;
public interface ICardValidationService
{
    public Task<bool> ValidateCardAsync(string cardNumber);
}
