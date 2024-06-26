namespace CreditProcess.Domain;
public class CreditCardDetails:BaseEntity
{
    public string CardNumber { get; set; }
    public string MaskedNumber { get; set; }
    public CardType Type { get; set; }
    public DateTime Valid => DateTime.Now.AddYears(4);
}
