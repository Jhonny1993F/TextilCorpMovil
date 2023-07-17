using Newtonsoft.Json;
using TextilCorpMovil.Models;
using System.Net;

namespace TextilCorpMovil.Views;

public partial class ProductosPage : ContentPage
{
    public ProductosPage()
    {
        InitializeComponent();
    }

    private async void Productos(object sender, EventArgs e)
    {
        //string cadena = Buscador.Text;
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("https://eb90-2800-bf0-287-ed8-2c7e-f703-cd9a-726a.ngrok.io/api/Producto");
        //request.RequestUri = new Uri("https://eb90-2800-bf0-287-ed8-2c7e-f703-cd9a-726a.ngrok.io/api/Producto/id/?ProductosId=" + cadena);
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "application/json");

        var client = new HttpClient();

        HttpResponseMessage response = await client.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            string content = await response.Content.ReadAsStringAsync();

            if (content.StartsWith("["))
            {
                var resultado = JsonConvert.DeserializeObject<List<Productos>>(content);
                Lista.ItemsSource = resultado;
            }
            else
            {
                var producto = JsonConvert.DeserializeObject<Productos>(content);
                Lista.ItemsSource = new List<Productos> { producto };
            }
        }
    }



    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Productos item)
            return;
        Shell.Current.GoToAsync(nameof(ProductosPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }

    private async void Comprar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CarritoPage());

    }
}