using TextilCorpMovil.Views;

namespace TextilCorpMovil;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new UsuariosPage());
    }
}
