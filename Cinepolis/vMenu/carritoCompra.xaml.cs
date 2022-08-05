using Acr.UserDialogs;
using Cinepolis.Clases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.vMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class carritoCompra : ContentPage
    {
        string correoG = "", targ="";
        string correo_comprador;
        public carritoCompra(string cont, int tp)
        {
            InitializeComponent();
           
            datoCorreo();

            UserDialogs.Instance.HideLoading();
           // await Task.Delay(500);


            lblFecha.Text = DateTime.Now.ToString();
            lblGolosinas.Text = cont;
            lblTp.Text = tp.ToString();

        }

        private async void btnAtras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void btnContinuar_Clicked(object sender, EventArgs e)
        {
            comprobar();
        }

        async void datoCorreo()
        {
           
            var datos = await App.BaseDatos.ObtenerCliente();
            
            lblCorreoComprador.Text=datos.correo.ToString();
            lblComprador.Text = datos.nombre.ToString();
            correo_comprador= datos.correo.ToString();
            ubicacion();
        }

        

        async void subirCompra(string tarjeta_)
        {
            
            //var direc = new Clases.ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "/comprar";


            string dato = lblGolosinas.Text + " y su total cancelado es de L. " + lblTp.Text + ".00";
            //MultipartFormDataContent parametros = new MultipartFormDataContent();
            //StringContent email = new StringContent(lblCorreoComprador.Text);
            //StringContent idP = new StringContent("0");
            //StringContent descripcion = new StringContent(lblGolosinas.Text);
            //StringContent lugar = new StringContent(lblLugar.Text);
            //StringContent tap = new StringContent(lblTp.Text);
            //StringContent tarjeta = new StringContent(tarjeta_);

            //parametros.Add(email, "correo");
            //parametros.Add(idP, "idPelicula");
            //parametros.Add(descripcion, "descripcion");
            //parametros.Add(lugar, "lugar");
            //parametros.Add(tap, "tap");
            //parametros.Add(tarjeta, "tarjeta");

            //var nt = "";
            //using (HttpClient client = new HttpClient())
            //{
            //    var respuesta = await client.PostAsync(direccion, parametros);

            //    Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

            //    nt = respuesta.Content.ReadAsStringAsync().Result;
            //   // correo(dato);
            //   // var pagina = new comidaQR(nt);
            //  //  await Navigation.PushAsync(pagina);

            //}

            using (WebClient wc = new WebClient())
            {
                // string idc = id__;

                var nt = "";
                string email = lblCorreoComprador.Text;
                string idP = "0";
                string tipocompra = "Golosina";
                string descripcion = lblGolosinas.Text;
                string lugar = lblLugar.Text;
                string tap = lblTp.Text;
                string tarjeta = tarjeta_;


                //var parametros = "correo=" + email;
                var parametros = "correo=" + email + "&idPelicula=" + idP + "&tipoCompra=" + tipocompra  + "&descripcion=" + descripcion + "&lugar=" + lugar + "&tarjeta=" + tarjeta;

                Debug.WriteLine("Datos " + parametros.ToString());

                var direc = new ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "/comprar";
                Console.WriteLine(parametros.ToString());
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(direccion, "POST", parametros);
                Console.WriteLine(HtmlResult);

                 nt = HtmlResult;
                nt = nt.Remove(0, 3);
                Debug.WriteLine(nt.ToString());
                if (HtmlResult.Contains("si"))
                {
                   // correo(dato);
                    var pagina = new comidaQR(nt);
                    await Navigation.PushAsync(pagina);
                }
                else if (HtmlResult.Contains("error"))
                {
                    await DisplayAlert("Error de Datos", "Hubo un error durante la transaccion", "Ok");
                }

            }
        }

        async void tar()
        {
            var direc = new Clases.ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "Cinepolis/tclientes/consultaClienteTarjeta.php";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent email = new StringContent(lblCorreoComprador.Text);

            parametros.Add(email, "correo");

            var nt = "";
            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

                Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                nt = respuesta.Content.ReadAsStringAsync().Result;
                subirCompra(nt);
            }
        }

        async void ubicacion()
        {




            //var direc = new Clases.ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "/usuarios";

            //MultipartFormDataContent parametros = new MultipartFormDataContent();
            //StringContent email = new StringContent(lblCorreoComprador.Text);

            //parametros.Add(email, "correo");
            //Debug.WriteLine(parametros.ToString());
            //var location = "";
            //using (HttpClient client = new HttpClient())
            //{
            //    var respuesta = await client.PostAsync(direccion, parametros);

            //    Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

            //    location = respuesta.Content.ReadAsStringAsync().Result;

            //    lblLugar.Text = location;
            //}

            using (WebClient wc = new WebClient())
            {
               // string idc = id__;
              
                var location = "";
                string email = lblCorreoComprador.Text;
                var parametros = "correo=" + email;
                var direc = new ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "/peliculas";
                Console.WriteLine(parametros.ToString());
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(direccion, "POST", parametros);
                Console.WriteLine(HtmlResult);

                lblLugar.Text = HtmlResult;

                //if (HtmlResult.Contains("si"))
                //{
                //    rbSiete.IsVisible = true;
                //}
            }


        }


        async void comprobar()
        {
            try
            {
               /* var direc = new Clases.ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "Cinepolis/tclientes/consultaClienteTarjeta.php";

                MultipartFormDataContent parametros = new MultipartFormDataContent();
                StringContent email = new StringContent(lblCorreoComprador.Text);

                parametros.Add(email, "correo");

                var nt = "";
                using (HttpClient client = new HttpClient())
                {
                    var respuesta = await client.PostAsync(direccion, parametros);

                    Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                    nt = respuesta.Content.ReadAsStringAsync().Result;


                }*/
                using (WebClient wc = new WebClient())
                {
                    // string idc = id__;
                   // string email = lblCorreoComprador.Text;
                    var nt = "";

                    var parametros = "correo=" + correo_comprador;
                    var direc = new ruta();
                    String direccion = direc.ruta_();
                    direccion = direccion + "/tarjeta";
                    Console.WriteLine(parametros.ToString());
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string HtmlResult = wc.UploadString(direccion, "POST", parametros);
                    Console.WriteLine(HtmlResult);

                    nt = HtmlResult;

                    //if (HtmlResult.Contains("si"))
                    //{
                    //    rbSiete.IsVisible = true;
                    //}
                

                string action = await DisplayActionSheet("¿Desea Realizar esta Transaccion?", "Cancel", null, "Si", "No");
                if (action.Equals("Si"))
                {
                   // string action2 = await DisplayActionSheet("¿Desea seleccionar la tarjeta con la terminación (" + nt.Substring(12, 4) + ") ?", "Cancel", null, "Si", "No");
                  //  if (action2.Equals("Si"))
                  //  {
                           subirCompra(nt);
                    // }
                }
                }
            }
            catch (Exception ex) { }
        }


        async void correo(string txt)
        {
            
            string sf = lblFecha.Text;
            var direc = new Clases.ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "Cinepolis/tclientes/compraPelicula.php";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent email = new StringContent(lblCorreoComprador.Text);
            StringContent msj = new StringContent(txt);


            parametros.Add(email, "correo");
            parametros.Add(msj, "msj");


            var nt = "";
            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

                Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                nt = respuesta.Content.ReadAsStringAsync().Result;
                nt = nt.Remove(0, 2);
                Debug.WriteLine(nt.ToString());

            }
        }
    }
}