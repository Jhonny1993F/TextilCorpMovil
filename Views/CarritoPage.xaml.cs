using Microsoft.Maui.Graphics.Text;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using TextilCorpMovil.Models;

namespace TextilCorpMovil.Views;

public partial class CarritoPage : ContentPage
{
    public CarritoPage()
    {
        InitializeComponent();
    }

    //private async void Carrito(object sender, EventArgs e)
    //{
    //    //string cadena = Buscador.Text;
    //    var request = new HttpRequestMessage();
    //    request.RequestUri = new Uri("https://662b-2800-bf0-287-ed8-2c7e-f703-cd9a-726a.ngrok.io/api/Carrito");
    //    //request.RequestUri = new Uri("https://662b-2800-bf0-287-ed8-2c7e-f703-cd9a-726a.ngrok.io/api/Carrito/id/?CarritoId=" + cadena);
    //    request.Method = HttpMethod.Get;
    //    request.Headers.Add("Accept", "application/json");

    //    var client = new HttpClient();

    //    HttpResponseMessage response = await client.SendAsync(request);
    //    if (response.StatusCode == HttpStatusCode.OK)
    //    {
    //        string content = await response.Content.ReadAsStringAsync();

    //        // Verificar si el JSON es un arreglo o un objeto
    //        if (content.StartsWith("["))
    //        {
    //            // Deserializar el JSON como una lista de objetos Usuarios
    //            var resultado = JsonConvert.DeserializeObject<List<Carrito>>(content);
    //            ListaVentas.ItemsSource = resultado;
    //        }
    //        else
    //        {
    //            // Deserializar el JSON como un objeto Usuarios
    //            var carrito = JsonConvert.DeserializeObject<Carrito>(content);
    //            ListaVentas.ItemsSource = new List<Carrito> { carrito };
    //        }
    //    }
    //}

    private async void Carrito(object sender, EventArgs e)
    {
        string cantidad = Cantidad.Text;
        string productosId = Producto.Text;
        string clientesId = Cliente.Text;
        Carrito nuevoCarrito = new Carrito
        {
            cantidad = cantidad,
            productosId = productosId,
            clientesId = clientesId,
        };

        string jsonUsuario = JsonConvert.SerializeObject(nuevoCarrito);

        try
        {
            var client = new HttpClient();
            var content = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://eb90-2800-bf0-287-ed8-2c7e-f703-cd9a-726a.ngrok.io/api/Carrito", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Venta", "Gracias por tu compra", "Aceptar");
            }
            else
            {
                await DisplayAlert("Venta", "Venta no realizada", "Aceptar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Venta", "Error de conexión con la API: " + ex.Message, "Aceptar");
        }
    }
}