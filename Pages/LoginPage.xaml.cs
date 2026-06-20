using Services;
using AppLanches;

namespace Pages;

public partial class LoginPage : ContentPage
{
    private readonly ApiService _apiService;

    public LoginPage(ApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
    }

    private async void BtnSignIn_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(EntEmail.Text) || string.IsNullOrEmpty(EntPassword.Text))
        {
            await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        var response = await _apiService.Login(EntEmail.Text, EntPassword.Text);

        if (!response.HasError)
        {
            await DisplayAlert("Sucesso", "Login efetuado com sucesso!", "OK");
            if (Application.Current != null)
            {
                Application.Current.MainPage = new AppShell();
            }
        }
        else
        {
            await DisplayAlert("Erro", "Falha no login: " + response.ErroMessage, "OK");
        }
    }

    private async void TapRegister_Tapped(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new InscricaoPage(_apiService));

    }
}