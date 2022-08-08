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
        string nombre = "", apellido = "", ubicacion = "", tarjeta = "", nombreT = "", fechaT = "", codigoT = "", correo="", email="";
        int codigos;
        
        public actualizarContacto()
        {
            InitializeComponent();
            email= Preferences.Get("Correo", "");
            pedirCorreo();
        }

        async private void btnGuardar_Clicked(object sender, EventArgs e)
        {

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
                codigo = codigos +1
            };
            await App.BaseDatos.EmpleadoGuardar(emple);

           
            await DisplayAlert("Exito", "Datos Actualizados Exitosamente", "OK");              
            await Navigation.PushAsync(new home());
            //email = correo;
            //pass = txtContra.Text;
            //WebClient cliente = new WebClient();
            //var parametros = new System.Collections.Specialized.NameValueCollection();
            //parametros.Add("correo", correo);
            //parametros.Add("pass", pass);
            //var direc = new ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "/usuarios";

            //cliente.UploadValues(direccion, "PUT", parametros);

            //await DisplayAlert("Exito", "Contraseña Actualizada Exitosamente", "OK");              
            //await Navigation.PushAsync(new MainPage());



            //var direc = new Clases.ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "Cinepolis/tclientes/datosCliente/actualizar.php";

            //MultipartFormDataContent parametros = new MultipartFormDataContent();
            //StringContent email = new StringContent(correo);
            //StringContent nombre_ = new StringContent(txtNombre.Text);
            //StringContent apellido_ = new StringContent(txtApellidos.Text);
            //StringContent ubicacion_ = new StringContent(ubicacion);
            //StringContent tarjeta_ = new StringContent(txtNumero.Text);
            //StringContent nombreT_ = new StringContent(txtNombreT.Text);
            //StringContent fecha_ = new StringContent(txtFechaEx.Text);
            //StringContent codigo_ = new StringContent(txtCodigo.Text);


            //parametros.Add(email, "correo");
            //parametros.Add(nombre_, "nombre");
            //parametros.Add(apellido_, "apellido");
            //parametros.Add(ubicacion_, "ubicacion");
            //parametros.Add(tarjeta_, "tarjeta");
            //parametros.Add(nombreT_, "nombreT");
            //parametros.Add(fecha_, "fecha");
            //parametros.Add(codigo_, "codigo");

            //var location = "";
            //using (HttpClient client = new HttpClient())
            //{
            //    var respuesta = await client.PostAsync(direccion, parametros);

            //    Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

            //    location = respuesta.Content.ReadAsStringAsync().Result;

            //    var pagina = new home();
            //    await Navigation.PushAsync(pagina);
            //}
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
            var datos = await App.BaseDatos.ObtenerClientes(email);
            var cor = datos.correo;
            correo= datos.correo;
            codigos = datos.codigo;

            // nombreF(cor);
            //  apellidoF(cor);
            //ubicacionF(cor);
            // tarjetaF(cor);
            //  nombreTarjetaF(cor);
            //  fechaF(cor);
            //  codigoF(cor);

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