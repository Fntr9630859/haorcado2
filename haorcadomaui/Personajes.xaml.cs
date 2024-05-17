namespace haorcadomaui;

public partial class Personajes : ContentPage
{
	public Personajes()
	{
		InitializeComponent();
	}

	public async void Cambio1(object sender, EventArgs e)
	{
        data.Datos.seleccionju = "ga";
        await Navigation.PushAsync(new MainPage());
    }

    public async void Cambio2(object sender, EventArgs e)
    {
        data.Datos.seleccionju = "lo";
        await Navigation.PushAsync(new MainPage());
    }

    public async void Cambio3(object sender, EventArgs e)
    {
        data.Datos.seleccionju = "po";
        await Navigation.PushAsync(new MainPage());
    }

    public async void Cambio4(object sender, EventArgs e)
    {
        data.Datos.seleccionju = "pr";
        await Navigation.PushAsync(new MainPage());
    }

    public async void Cambio5(object sender, EventArgs e)
    {
        data.Datos.seleccionju = "ri";
        await Navigation.PushAsync(new MainPage());
    }

    public async void Cambio6(object sender, EventArgs e)
    {
        data.Datos.seleccionju = "sp";
        await Navigation.PushAsync(new MainPage());
    }
}