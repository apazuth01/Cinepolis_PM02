using Cinepolis.Controller;
using System;
using System.Diagnostics;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cinepolis.Models;
using System.Net;
using Cinepolis.Clases;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace Cinepolis.vMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class peliculas : ContentPage
    {
        public peliculas()
        {
            InitializeComponent();

        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            

            var datos = await App.BaseDatos.ObtenerCliente();
            var correo = datos.correo;
          //  var correo = "Apazuth01@gmail.com";


            //var direc = new Clases.ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "/peliculas";

            //MultipartFormDataContent parametros = new MultipartFormDataContent();
            //StringContent email = new StringContent(correo);

            //parametros.Add(email, "correo");

            var location = "";

            using (WebClient wc = new WebClient())
            {
                // var parametros = new System.Collections.Specialized.NameValueCollection();
                var parametros = "correo=" + correo;
                //parametros.Add("email", email);
                //parametros.Add("pass", pass);
                var direc = new ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "/peliculas";

                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(direccion, parametros);

                Console.WriteLine(HtmlResult);
                location = HtmlResult.ToString();

                Console.WriteLine(location.ToString());
                //if (HtmlResult.Equals("SI"))
                //{
                //    var pagina = new vMenu.home();
                //    await Navigation.PushAsync(pagina);
                //}
                //else if (HtmlResult.Equals("NO"))
                //{
                //    await DisplayAlert("Error de Datos", "Los Datos Ingresados No Coinciden", "Ok");
                //}
                //else if (HtmlResult.Equals("NO VERIFICADO"))
                //{
                //    await DisplayAlert("Erro de Verificacion", "La Cuenta está pendiente de Verficación! Favor Revisa Tu Correo e ingresa tu Codigo de Verificacion", "Ok");
                //}
                if (location.Contains("San Pedro Sula"))
                {
                    ListaEmpleados.ItemsSource = await peliculasHomeController.ObtenerPeliculasHomeSPS();
                    
                }
                else if (location.Contains("Tegucigalpa"))
                {
                    ListaEmpleados.ItemsSource = await peliculasHomeController.ObtenerPeliculasHomeTegus();
                }
                UserDialogs.Instance.HideLoading();
                await Task.Delay(500);
            }
            //using (HttpClient client = new HttpClient())
            //{
            //    Debug.WriteLine(correo.ToString());
            //    var respuesta = await client.PostAsync(direccion, parametros);

            //    Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

            //    location = respuesta.Content.ReadAsStringAsync().Result;

            //}

         
            /*
            var emple = new Models.constructorLogin
            {
                codigo = Convert.ToInt32(0)
            };
            var resultado = await App.BaseDatos.EmpleadoBorrar(emple);
            */

        }
        private async void ListaEmpleados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var d = e.SelectedItem as Models.ApiPeliculasHome.ph;
            var pagina = new peliculaElegida(d.idPelicula, d.nombre, d.synopsis, d.anio, d.clasificacion, d.genero, d.director, d.duracion, d.video, d.banner);
            await Navigation.PushAsync(pagina);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new home());
        }
    }
}