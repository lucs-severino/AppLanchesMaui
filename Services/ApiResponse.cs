namespace Services;

public class ApiResponse<T>
{
    public bool HasError => !string.IsNullOrEmpty(ErroMessage);
    public string? ErroMessage { get; set; }
    public T? Data { get; set; }

}

