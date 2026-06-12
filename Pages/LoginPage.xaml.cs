using Services;

namespace Pages;

public partial class LoginPage : ContentPage
{
    private readonly ApiService _apiService;

    public LoginPage(ApiService apiService) 
    {
        _apiService = apiService;
    }
}