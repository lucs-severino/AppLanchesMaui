using Pages;

namespace AppLanches;

public partial class App : Application
{
	public App(InscricaoPage inscricaoPage)
	{
		InitializeComponent();

		MainPage = new NavigationPage (inscricaoPage);
	}
}
