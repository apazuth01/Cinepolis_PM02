using Cinepolis.Clases;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.aUsuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OlvidoContraseña : ContentPage
    {
        String correo = "", a = "", pass = "";
        public OlvidoContraseña()
        {
            InitializeComponent();
        }

        private async void btnContinuar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                await DisplayAlert("Error", "Es necesario llenar todos los campos", "OK");
            }
            else
            {/* 
                var pagina = new ComprobarCodigo(txtCorreo.Text);

                await Navigation.PushAsync(pagina);
                */


                btnContinuar.IsVisible = false;
                fCorreo.IsVisible = false;
                lbldatos.IsVisible = false;
                lblingresacorreo.Text = "Ingresa tu Pin de Recuperacion de Contraseña";

                lbltitulo.Text = "Ingresa tu Codigo Pin";
                fCodigo.IsVisible = true;
                btnVerificar.IsVisible = true;



                correo = txtCorreo.Text;


                numeroRand();


            }

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtContra.Text))
            {
                await DisplayAlert("Error", "Es necesario Todos llenar los campos", "OK");
            }
            else
            {
                correo = txtCorreo.Text;
                pass = txtContra.Text;
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("correo", correo);
                parametros.Add("pass", pass);
                var direc = new ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "/usuarios";

                cliente.UploadValues(direccion, "PUT", parametros);

               await DisplayAlert("Exito", "Contraseña Actualizada Exitosamente", "OK");
               // var pagina = new MainPage();

              //  await Navigation.PushAsync(pagina);
                await Navigation.PushAsync(new MainPage());

                /* var direc = new ruta();
                 String direccion = direc.ruta_();
                 direccion = direccion + "/usuarios";

                 MultipartFormDataContent parametros = new MultipartFormDataContent();
                 StringContent email = new StringContent(correo);
                 StringContent pass = new StringContent(txtContra.Text);
                 parametros.Add(email, "correo");
                 parametros.Add(pass, "pass");

                 using (HttpClient client = new HttpClient())
                 {
                     //var respuesta = await client.PostAsync(direccion, parametros);
                     var respuesta = await client.PutAsync(direccion, parametros);

                     Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                     var pagina = new MainPage();

                     await Navigation.PushAsync(pagina);

                 }*/

            }

        }

        private async void btnVerificar_Clicked(object sender, EventArgs e)
        {
            if (txtCodigo.Text == a)
            {
                fCodigo.IsVisible = false;
                btnVerificar.IsVisible = false;
                lblingresacorreo.Text = "Ingresa tu Nueva Contraseña";

                lbltitulo.Text = "Ingresa tu Nueva Contraseña";


                fContra.IsVisible = true;
                btnActualizar.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Error", "Codigo Invalido", "OK");
            }

        }


        private async void numeroRand()
        {
            Random rnd = new Random();



            for (uint ctr = 1; ctr <= 1; ctr++)
            {

                a = Convert.ToString(rnd.Next(9999));
                Debug.WriteLine("codigo " + a.ToString());
            }

            var direc = new ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "/usuarios";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent email = new StringContent(correo);
            StringContent code = new StringContent(a);
            parametros.Add(email, "correo");
            parametros.Add(code, "codigo");

            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

               Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

            }

        }

    }
}