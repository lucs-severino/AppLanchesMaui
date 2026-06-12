using System.Threading.Tasks;
using Services;

namespace Pages;

public partial class InscricaoPage : ContentPage
{
    private readonly ApiService _apiService;
    public InscricaoPage(ApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
    }

    public async void BtnSignup_Clicked(object sender, EventArgs e)
    {
        var response = await _apiService.ResgistrarUsuario(EntNome.Text, EntEmail.Text, EntPhone.Text, EntPassword.Text);

        if (!response.HasError)
        {
            await DisplayAlert("Aviso", "Sua conta foi criada com Sucesso!!", "Ok");
            await Navigation.PushAsync(new LoginPage(_apiService));
        }
        else
        {
            await DisplayAlert("Erro", "Algo deu errado!!!", "cancelar");
        }

    }

    public async void TapLogin_Tapped (object sender, EventArgs e)
    {
         await Navigation.PushAsync(new LoginPage(_apiService));
    }
}