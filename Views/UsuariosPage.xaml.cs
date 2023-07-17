using Newtonsoft.Json;
using System.Net;
using System.Text;
using TextilCorpMovil.Models;

namespace TextilCorpMovil.Views;

public partial class UsuariosPage : ContentPage
{
    public UsuariosPage()
    {
        InitializeComponent();
    }

    private async void Ingresar(object sender, EventArgs e)
    {
        string correo = Usuario.Text;
        string clave = Clave.Text;

        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "https://eb90-2800-bf0-287-ed8-2c7e-f703-cd9a-726a.ngrok.io/api/Usuario");
        request.Headers.Add("Accept", "application/json");

        HttpResponseMessage response = await client.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            string content = await response.Content.ReadAsStringAsync();
            var usuarios = JsonConvert.DeserializeObject<List<Usuarios>>(content);

            var usuario = usuarios.FirstOrDefault(u => u.correo == correo && u.clave == clave);

            if (usuario != null)
            {
                await DisplayAlert("Ingreso", "El ingreso ha sido exitoso", "Aceptar");
                await Navigation.PushAsync(new AppShell());
            }
            else
            {
                await DisplayAlert("Ingreso", "El correo o la clave son incorrectos", "Aceptar");
            }
        }
        else
        {
            await DisplayAlert("Ingreso", "Servicio desconectado", "Aceptar");
        }
    }


    private async void Registrar(object sender, EventArgs e)
    {
        string nombres = Nombres.Text;
        string apellidos = Apellidos.Text;
        string correo = Correo.Text;
        string clave = Contraseña.Text;
        string direccion = Direccion.Text;
        int telefono = int.Parse(Telefono.Text);
        Usuarios nuevoUsuario = new Usuarios
        {
            nombres = nombres,
            apellidos = apellidos,
            correo = correo,
            clave = clave,
            direccion = direccion,
            telefono = telefono
        };

        string jsonUsuario = JsonConvert.SerializeObject(nuevoUsuario);

        try
        {
            var client = new HttpClient();
            var content = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://eb90-2800-bf0-287-ed8-2c7e-f703-cd9a-726a.ngrok.io/api/Usuario", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Registro", "Usuario registrado exitosamente", "Aceptar");
            }
            else
            {
                await DisplayAlert("Registro", "No sepudo registar el usuario", "Aceptar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Registro", "Error de conexión con la API: " + ex.Message, "Aceptar");

        }
    }
}