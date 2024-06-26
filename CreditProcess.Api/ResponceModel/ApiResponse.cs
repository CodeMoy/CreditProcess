namespace CreditProcess.Api;
public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public string ?Message { get; set; } = default!;
    public T ?Data { get; set; } = default!;
}
