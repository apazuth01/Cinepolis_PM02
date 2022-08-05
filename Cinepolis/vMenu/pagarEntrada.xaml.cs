using Cinepolis.Clases;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.vMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pagarEntrada : ContentPage
    {
        int[] nSilla;

        int contador = 0;
        string arreglo;
        string sillas;
        string nt;
        string id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, banner__, video__, hora__;
        string correo__ = "", nCliente__ = "", ubicacion__ = ""; 

        public pagarEntrada(string id_, string nombre_, string synopsis_, string anio_, string clasificacion_, string genero_, string director_, string duracion_, string video_, string banner_, string hora_, int[] a)
        {
            string sillaMostrar = "Numero de silla: ";
            int contadorSilla = 0;
            id__ = id_;
            nombre__ = nombre_;
            synopsis__ = synopsis_;
            anio__ = anio_;
            clasificacion__ = clasificacion_;
            genero__ = genero_;
            director__ = director_;
            duracion__ = duracion_;
            banner__ = banner_;
            video__ = video_;
            hora__ = hora_;
            //Console.Write("Sillas " + a);
            InitializeComponent();


            for (int i = 0; i < 40; i++)
            {
                if (a[i] != 0)
                {
                    //DisplayAlert("a", a[i].ToString(), "ok");
                    sillaMostrar = sillaMostrar + a[i].ToString() + ", ";

                    contadorSilla++;
                    contador++;
                    if (contadorSilla > 1)
                    {
                        arreglo = arreglo + ",\"" + a[i] + "\"";
                    }
                    else
                    {
                        arreglo = arreglo + "\"" + a[i] + "\"";
                    }
                }
            }
            sillaMostrar = sillaMostrar + "\nSillas a Pagar: (" + contadorSilla.ToString() + ")";
          //  arreglo = "[" + sillaMostrar + "]";
            Console.Write("Sillas 2 " + "[" + arreglo + "]");
            sillas = "[" + arreglo + "]";
            datoCorreo();
            


           

            lblPelicula.Text = nombre_;
            lblFecha.Text = DateTime.Now.ToString();
            lblHora.Text = hora_ + " horas";

            lblDuracion.Text = duracion_;
            lblSillas.Text = sillaMostrar;
            

            int tap = contadorSilla * 80;
            lblTp.Text = "L. " + tap.ToString() + ".00";
            
            correo__ = lblCorreoComprador.Text;
            nCliente__ = lblComprador.Text;
            ubicacion__ = lblLugar.Text;

            nSilla = a;


        }


        async void datoCorreo()
        {
            var datos = await App.BaseDatos.ObtenerCliente();
            lblCorreoComprador.Text = datos.correo.ToString();
            lblComprador.Text= datos.nombre.ToString();
            //ubicacion(lblCorreoComprador.Text);
            ubicacion();
        }



        async void ubicacion()
        {




            //var direc = new Clases.ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "Cinepolis/tclientes/consultaClientesCorreo.php";

            //MultipartFormDataContent parametros = new MultipartFormDataContent();
            //StringContent email = new StringContent(correo);

            //parametros.Add(email, "correo");

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

        async private void btnAtras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async private void btnContinuar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //var direc = new Clases.ruta();
                //String direccion = direc.ruta_();
                //direccion = direccion + "/tarjeta";

                //MultipartFormDataContent parametros = new MultipartFormDataContent();
                //StringContent email = new StringContent(lblCorreoComprador.Text);

                //parametros.Add(email, "correo");

                //var nt = "";
                //using (HttpClient client = new HttpClient())
                //{
                //    var respuesta = await client.PostAsync(direccion, parametros);

                //    Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                //    nt = respuesta.Content.ReadAsStringAsync().Result;                    
                //}

                using (WebClient wc = new WebClient())
                {
                    // string idc = id__;

                  
                    string email = lblCorreoComprador.Text;
                    var parametros = "correo=" + email;
                    var direc = new ruta();
                    String direccion = direc.ruta_();
                    direccion = direccion + "/tarjeta";
                   // Console.WriteLine(parametros.ToString());
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string HtmlResult = wc.UploadString(direccion, "POST", parametros);
                   // Console.WriteLine(HtmlResult);

                    nt= HtmlResult;

                    //if (HtmlResult.Contains("si"))
                    //{
                    //    rbSiete.IsVisible = true;
                    //}
                }

                string action = await DisplayActionSheet("¿Desea realizar esta compra?", "Cancel", null, "Si", "No");
                if (action.Equals("Si"))
                {
                    // string action2 = await DisplayActionSheet("¿Desea seleccionar la tarjeta con la terminación ("+nt.Substring(12,4)+") ?", "Cancel", null, "Si", "No");
                    //if (action2.Equals("Si"))
                    //{
                    //  for (int i = 0; i < 40; i++)
                    // {
                    //   if (nSilla[i] != 0)
                    // {
                    //       comprarSilla(nSilla[i]);

                    //}                      

                    //  }

                    // correo();
                    comprarSilla();
                      //  subirCompra(nt);
                    //}
                }
            }
            catch (Exception ex) { }
        }

        async void comprarSilla()
        {
            //var direc = new Clases.ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "/sillas";

            //MultipartFormDataContent parametros = new MultipartFormDataContent();
            //StringContent email = new StringContent(lblCorreoComprador.Text);
            //StringContent idP = new StringContent(id__);
            //StringContent hora = new StringContent(hora__);
            //StringContent nsilla_ = new StringContent(silla.ToString());

            //parametros.Add(email, "correo");
            //parametros.Add(idP, "idPelicula");
            //parametros.Add(hora, "hora");
            //parametros.Add(nsilla_, "nSilla");

            //Debug.WriteLine("Sillas " + nsilla_.ToString());

            //var nt = "";
            //using (HttpClient client = new HttpClient())
            //{
            //    var respuesta = await client.PostAsync(direccion, parametros);

            //    Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

            //    nt = respuesta.Content.ReadAsStringAsync().Result;


            //}

            using (WebClient wc = new WebClient())
            {
                // string idc = id__;

                var nt = "";
                string email = lblCorreoComprador.Text;
                string idP = id__;
                string hora = hora__;
                string nsilla_ = arreglo.ToString();


                //var parametros = "correo=" + email;
                var parametros = "email=" + email + "&idPelicula=" + idP + "&hora=" + hora + "&Silla=" + nsilla_;

                Debug.WriteLine("Sillas " + parametros.ToString());

                var direc = new ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "/sillas";
                Console.WriteLine(parametros.ToString());
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(direccion, "POST", parametros);
                Console.WriteLine(HtmlResult);

                lblLugar.Text = HtmlResult;

            
            }
        }

        async void subirCompra(string tarjeta_)
        {   int t_p = contador * 80;
            //var direc = new Clases.ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "/comprar";
            string datoDes = lblSillas.Text + " - La pelicula es: " + nombre__+" y sera en el horario: " +hora__;
            //MultipartFormDataContent parametros = new MultipartFormDataContent();
            //StringContent email = new StringContent(lblCorreoComprador.Text);
            //StringContent idP = new StringContent(id__);
            //StringContent descripcion = new StringContent(datoDes);
            //StringContent lugar = new StringContent(lblLugar.Text);
            //StringContent tap = new StringContent(t_p.ToString());
            //StringContent tarjeta = new StringContent(tarjeta_);

            //parametros.Add(email, "correoComprador");
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

            //    var pagina = new peliculaQR(nt);
            //    await Navigation.PushAsync(pagina);

            //}
            using (WebClient wc = new WebClient())
            {
                // string idc = id__;

                var nt = "";
                string email = lblCorreoComprador.Text;
                string idP = id__;
                string tipocompra = "Pelicula";
                string descripcion = datoDes;
                string lugar = lblLugar.Text;
                string tap = t_p.ToString();
                string tarjeta = tarjeta_;


                //var parametros = "correo=" + email;
                var parametros = "correo=" + email + "&idPelicula=" + idP + "&tipoCompra=" + tipocompra + "&descripcion=" + descripcion + "&lugar=" + lugar + "&tarjeta=" + tarjeta;

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

        async void correo()
        {
            string txt = "Se a realizado la compra de las siguientes sillas: ";
            for (int i = 0; i < 40; i++)
            {
                if (nSilla[i] != 0)
                {
                    txt= txt + nSilla[i].ToString()+ " " ;

                }
                

            }
            string sf= lblFecha.Text;
            txt = txt + " con un total a pagar de: " + lblTp.Text + ", la pelicula "+nombre__+" se podra ver en la fecha "+sf.Substring(0,10)+", a las "+lblHora.Text+" en la ciudad de "+lblLugar.Text;
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