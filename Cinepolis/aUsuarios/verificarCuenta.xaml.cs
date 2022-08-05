using Cinepolis.Clases;
using Cinepolis.Models;
using System;
using System.Diagnostics;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;




namespace Cinepolis.aUsuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class verificarCuenta : ContentPage
    {
        String a = "", nombre, apellido, correo, pass, ciudad, nombret, numerot, fechat, codigot,verificadot, toke_datos;
        public verificarCuenta(String nombre_, String apellido_, String correo_, String pass_, String ciudad_, String nombreT_, String numerot_, String fechat_, String codigot_)
        {
            InitializeComponent();
            generarCodigo(correo_);
            nombre = nombre_;
            apellido = apellido_;
            correo = correo_;
            pass = pass_;

            ciudad = ciudad_;
            nombret = nombreT_;
            numerot = numerot_;
            fechat = fechat_;
            codigot = codigot_;
            Console.WriteLine("Este es el Token verificado " + contructorCompra.tok.token_dato);
            toke_datos = contructorCompra.tok.token_dato.ToString();

        }
   

        private async void btnVerificar_Clicked(object sender, EventArgs e)
        {
            if (txtCodigo.Text == a)
            {
                verificadot = "True";
                Debug.WriteLine("Codigo " + verificadot.ToString());
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", nombre);
                parametros.Add("apellidos", apellido);
                parametros.Add("correo", correo);
                parametros.Add("pass", pass);
                parametros.Add("ubicacion", ciudad);
                parametros.Add("nombreT", nombret);
                parametros.Add("numeroT", numerot);
                parametros.Add("fechaT", fechat);
                parametros.Add("codigo", codigot);
                parametros.Add("verificado", verificadot);
                parametros.Add("token", toke_datos);


                var direc = new ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "/usuarios";
                cliente.UploadValues(direccion, "PUT", parametros);

                var emple = new constructorLogin
                {
                    nombre = nombre,
                    correo = correo
                };
                await App.BaseDatos.EmpleadoGuardar(emple);

                await DisplayAlert("¡Cuenta Verificada exitosamente!", "Seras redireccionado a la pantalla de inicio de sesion.", "OK");

                var pagina = new MainPage();

                await Navigation.PushAsync(pagina);
                
            }
            else
            {
                await DisplayAlert("Error", "Codigo Incorrecto.", "OK");
            }

        }


        async void   generarCodigo(String email)
        {
            Random rnd = new Random();



            for (uint ctr = 1; ctr <= 1; ctr++)
            {

                a = Convert.ToString(rnd.Next(9999));
                Debug.WriteLine("Codigo " + a.ToString());
            }


            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("correo_", email);
            parametros.Add("codigo_", a);
            var direc = new ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "/usuarios";

            cliente.UploadValues(direccion, "POST", parametros);

            //var respuesta = await cliente.OpenReadAsync(direccion, parametros);

        }

    }
}