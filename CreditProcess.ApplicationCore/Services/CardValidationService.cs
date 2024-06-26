namespace CreditProcess.ApplicationCore;
public class CardValidationService : ICardValidationService
{
    public async Task<bool> ValidateCardAsync(string cardNumber)
    {
        if (String.IsNullOrEmpty(cardNumber) || cardNumber.Length < 2)
        {
            return false;
        }
        var result = await Task.Run(() => ValidateUsingLuhn(cardNumber));
        return result;
    }

    private bool ValidateUsingLuhn(string cardNumber)
    {
        int cardLenth = cardNumber.Length;

        int cardNumberSum = 0;
        bool isSecondPos = false;
        for (int i = cardLenth - 1; i >= 0; i--)
        {
            int digit = cardNumber[i] - '0';

            if (isSecondPos == true)
                digit = digit * 2;

            cardNumberSum += digit / 10;
            cardNumberSum += digit % 10;

            isSecondPos = !isSecondPos;
        }
        return (cardNumberSum % 10 == 0);
    }


}

