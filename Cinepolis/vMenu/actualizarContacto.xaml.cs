using Cinepolis.Clases;
using Cinepolis.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.vMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class actualizarContacto : ContentPage
    {
        string nombre = "", apellido = "", ubicacion = "", tarjeta = "", nombreT = "", fechaT = "", codigoT = "", correo="", email="", contraseña="";
        int codigos;
        string token_datos;


        public actualizarContacto()
        {
            InitializeComponent();
            email= Preferences.Get("Correo", "");
          token_datos  = Preferences.Get("TokenFirebase", "");
            pedirCorreo();
        }

        async private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            tarjeta = txtNumero.Text;
            int cant = tarjeta.Length;
            if (cant != 16)
            {
                await DisplayAlert("Faltan Caracteres", "El Numero de Tarjeta debe contener los 16 caracteres Estandard", "OK");
                return;
            }
            if (String.IsNullOrWhiteSpace(ubicacion))
            {
                await DisplayAlert("Error", "Debe Seleccionar una Ubicacion.", "OK");
                return;
            }

            if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtApellidos.Text) || String.IsNullOrWhiteSpace(correo) || String.IsNullOrWhiteSpace(txtPass.Text) || String.IsNullOrWhiteSpace(txtNombreT.Text) || String.IsNullOrWhiteSpace(tarjeta) || String.IsNullOrWhiteSpace(txtFechaEx.Text) || String.IsNullOrWhiteSpace(txtCodigo.Text) || cant != 16)
            {
                await DisplayAlert("Error", "Es necesario llenar todos los campos correctamente.", "OK");
                return;
            }

                WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellidos", txtApellidos.Text);
            parametros.Add("correo", correo);
            parametros.Add("pass", txtPass.Text);
            parametros.Add("ubicacion", ubicacion);
            parametros.Add("nombreT", txtNombreT.Text);
            parametros.Add("numeroT", txtNumero.Text);
            parametros.Add("fechaT", txtFechaEx.Text);
            parametros.Add("codigo", txtCodigo.Text);
           // parametros.Add("token", token_datos.ToString());

            var direc = new ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "/usuarios";
            cliente.UploadValues(direccion, "PUT", parametros);

            var emple = new constructorLogin
            {
                nombre_completo = txtNombre.Text + " " + txtApellidos.Text,
                nombre = txtNombre.Text,
                apellidos = txtApellidos.Text,
                clave = txtPass.Text,
                ubicacion = ubicacion,
                tarjeta = txtNumero.Text,
                proveedor = txtNombreT.Text,
                fecha_tarjeta = txtFechaEx.Text,
                cod_seguridad = txtCodigo.Text,
                correo = correo,
                //codigo = codigos 
            };
            await App.BaseDatos.EmpleadoGuardar(emple);
           
            await DisplayAlert("Exito", "Datos Actualizados Exitosamente", "OK");              
            await Navigation.PushAsync(new home());
          
        }

        private void rbSps_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (rbSps.IsChecked == true)
                {
                    ubicacion = "San Pedro Sula";
                }
            }
            catch (Exception ex) { }
        }

         private void rbTeg_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (rbTeg.IsChecked == true)
                {
                    ubicacion = "Tegucigalpa";
                }
            }
            catch (Exception ex) { }
        }

        async void pedirCorreo()
        {
            var datos = await App.BaseDatos.ObtenerCliente();
            var cor = datos.correo;
            correo= datos.correo;
            //codigos = datos.codigo;
        

            txtPass.Text = datos.clave;
            txtNombre.Text = datos.nombre;
            txtApellidos.Text = datos.apellidos;
            txtCodigo.Text = datos.cod_seguridad;
            txtFechaEx.Text = datos.fecha_tarjeta;
            txtNombreT.Text = datos.proveedor;
            txtNumero.Text = datos.tarjeta;
            Console.WriteLine("Codigo Bd " + codigos);

        }

        async void nombreF(String correo)
        {
            var direc = new Clases.ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "Cinepolis/tclientes/datosCliente/nombre.php";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent email = new StringContent(correo);

            parametros.Add(email, "correo");

            var location = "";
            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

                Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                location = respuesta.Content.ReadAsStringAsync().Result;

                txtNombre.Text = location;
                nombre = location;
            }


        }

        async void apellidoF(string correo)
        {
            var direc = new Clases.ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "Cinepolis/tclientes/datosCliente/apellido.php";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent email = new StringContent(correo);

            parametros.Add(email, "correo");

            var location = "";
            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

                Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                location = respuesta.Content.ReadAsStringAsync().Result;

                txtApellidos.Text= location;
                apellido= location;
                
            }

        }

        async void ubicacionF(string correo)
        {
            var direc = new Clases.ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "Cinepolis/tclientes/datosCliente/ubicacion.php";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent email = new StringContent(correo);

            parametros.Add(email, "correo");

            var location = "";
            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

                Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                location = respuesta.Content.ReadAsStringAsync().Result;
                ubicacion = location;
                if (location.Equals("San Pedro Sula"))
                {
                    rbSps.IsChecked = true;
                }

                else if (location.Equals("Tegucigalpa"))
                {
                    rbTeg.IsChecked = true;
                }
            }

        }

        async void tarjetaF(string correo)
        {
            var direc = new Clases.ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "Cinepolis/tclientes/datosCliente/tarjeta.php";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent email = new StringContent(correo);

            parametros.Add(email, "correo");

            var location = "";
            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

                Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                location = respuesta.Content.ReadAsStringAsync().Result;

               txtNumero.Text= location;
                tarjeta = location;

            }
        }

        async void nombreTarjetaF(string correo)
        {
            var direc = new Clases.ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "Cinepolis/tclientes/datosCliente/nombreTarjeta.php";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent email = new StringContent(correo);

            parametros.Add(email, "correo");

            var location = "";
            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

                Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                location = respuesta.Content.ReadAsStringAsync().Result;

                txtNombreT.Text = location;
                nombreT = location;

            }
        }

        async void fechaF(string correo)
        {
            var direc = new Clases.ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "Cinepolis/tclientes/datosCliente/fecha.php";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent email = new StringContent(correo);

            parametros.Add(email, "correo");

            var location = "";
            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

                Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                location = respuesta.Content.ReadAsStringAsync().Result;

                txtFechaEx.Text = location;
                fechaT = location;
            }
        }

        async void codigoF(string correo)
        {
            var direc = new Clases.ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "Cinepolis/tclientes/datosCliente/codigo.php";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent email = new StringContent(correo);

            parametros.Add(email, "correo");

            var location = "";
            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

                Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                location = respuesta.Content.ReadAsStringAsync().Result;

                txtCodigo.Text = location;
                codigoT = location;

            }
        }
    }
}