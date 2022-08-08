using Acr.UserDialogs;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.vMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class home : ContentPage
    {
        public home()
        {
            InitializeComponent();
        }

        private async void slPelicula_Tapped(object sender, EventArgs e)
        {

            try
            {
                UserDialogs.Instance.ShowLoading("Cargando Cartelera", MaskType.Clear);
                var pagina = new peliculas();
                await Navigation.PushAsync(pagina);
                //UserDialogs.Instance.HideLoading();
                //await Task.Delay(500);
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();

                await Task.Delay(500);

                Message("Error: ", ex.Message);
            }                   
        }

        async private void slComida_Tapped(object sender, EventArgs e)
        {
            var pagina = new carrito();
            await Navigation.PushAsync(pagina);
        }

        async private void slUbicacion_Tapped(object sender, EventArgs e)
        {
            var pagina = new Nosotros();
            await Navigation.PushAsync(pagina);
        }

        async private void slUsuario_Tapped(object sender, EventArgs e)
        {
            var pagina = new actualizarContacto();
            await Navigation.PushAsync(pagina);
        }

        async private void slHistorial_Tapped(object sender, EventArgs e)
        {
            var pagina = new registro();
            await Navigation.PushAsync(pagina);
        }

        async private void slSalir_Tapped(object sender, EventArgs e)
        {
            //var datos = await App.BaseDatos.ObtenerCliente();
            //int  cor= datos.codigo;
            //var emple = new Models.constructorLogin
            //{
            //    codigo = Convert.ToInt32(cor)
            //};
            //var resultado = await App.BaseDatos.EmpleadoBorrar(emple);

            var pagina = new MainPage();
            await Navigation.PushAsync(pagina);
        }

        private async void Message(string title, string message)
        {
            await DisplayAlert(title, message, "OK");
        }

    }
}