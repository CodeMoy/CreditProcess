using CreditProcess.Domain;

namespace CreditProcess.ApplicationCore;
public class CardValidationService : ICardValidationService
{
    /// <summary>
    /// This method validate credit card number based on Luhn algorithm.
    /// <example>
    /// If we provide card number it will check card number and return true or false:
    /// <code>
    /// ValidateCardAsync("4") will return false
    /// ValidateCardAsync("3056930009020004") will return true
    /// </code>
    /// </example>
    /// </summary>

    public async Task<bool> ValidateCardAsync(string cardNumber)
    {
        if (cardNumber.Length < 2)
        {
            return false;
        }
        var result = await Task.Run(() => ValidateUsingLuhn(cardNumber));
        return result;
    }

    /// <summary>
    /// Private method validate credit card number based on Luhn algorithm.
    /// <example>
    /// If we provide card number it will check card number and return true or false:
    /// <code>
    /// ValidateUsingLuhn("4889999") will false
    /// ValidateCardAsync("3056930009020004") will true
    /// </code>
    /// </example>
    /// </summary>

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

