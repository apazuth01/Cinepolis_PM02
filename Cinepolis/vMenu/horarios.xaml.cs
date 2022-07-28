using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cinepolis.Clases;

namespace Cinepolis.vMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class horarios : ContentPage
    {
        string id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, video__, banner__ ;
       // id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, video__, banner__



        public horarios(string id_, string nombre_, string synopsis_, string anio_, string clasificacion_, string genero_, string director_, string duracion_, string video_, string banner_)
        {
            InitializeComponent();


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
           // Console.WriteLine(id__.ToString());
            rbCinco.IsVisible = false;
            rbTres.IsVisible = false;
            rbSiete.IsVisible = false;
            Console.WriteLine("Este es :" + id__.ToString());
            horarioFTres();
           // horarioFCinco();
           // horarioFSiete();

        }
        async void horarioFTres()
        {
            Console.WriteLine("En horario 3" +id__.ToString());
           // Console.WriteLine("Este es :" + id__.ToString());
            //var direc = new Clases.ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "/horarios";
            //WebClient cliente = new WebClient();
            //var parametros = new System.Collections.Specialized.NameValueCollection();
            //parametros.Add("correo_", email);
            //parametros.Add("codigo_", a);
            //var direc = new ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "/usuarios";

            //cliente.UploadValues(direccion, "POST", parametros);


            using (WebClient wc = new WebClient())
            {
                string idc = id__;
                string hora = "1";
                // var parametros = new System.Collections.Specialized.NameValueCollection();
                var parametros = "id=" + idc + "&hora=" + hora;
                //parametros.Add("email", email);
                //parametros.Add("pass", pass);
                var direc = new ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "/horarios";
                Console.WriteLine(parametros.ToString());
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(direccion, "POST", parametros);
                Console.WriteLine(HtmlResult);

                if (HtmlResult.Contains("si"))
                {
                    rbTres.IsVisible = true;
                }
                //else if (HtmlResult.Equals("NO"))
                //{
                //    await DisplayAlert("Error de Datos", "Los Datos Ingresados No Coinciden", "Ok");
                //}
                //else if (HtmlResult.Equals("NO VERIFICADO"))
                //{
                //    await DisplayAlert("Erro de Verificacion", "La Cuenta está pendiente de Verficación! Favor Revisa Tu Correo e ingresa tu Codigo de Verificacion", "Ok");
                //}
            }
            //MultipartFormDataContent parametros = new MultipartFormDataContent();
            //StringContent idC = new StringContent(id__);
            //StringContent horaC = new StringContent("15:00");
            //parametros.Add(idC, "id");
            //parametros.Add(horaC, "hora");

            //var rsp = "";
            //using (HttpClient client = new HttpClient())
            //{
            //    var respuesta = await client.PostAsync(direccion, parametros);

            //    Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

            //    rsp = respuesta.Content.ReadAsStringAsync().Result;

            //}
            //if (rsp.Equals("si"))
            //{
            //    rbTres.IsVisible = true;
            //}

        }

        async void horarioFCinco()
        {
            var direc = new Clases.ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "/horarios";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent idC = new StringContent(id__);
            StringContent horaC = new StringContent("2");
            parametros.Add(idC, "id");
            parametros.Add(horaC, "hora");

            var rsp = "";
            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

                Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                rsp = respuesta.Content.ReadAsStringAsync().Result;

            }
            if (rsp.Equals("si"))
            {
                rbCinco.IsVisible = true;
            }

        }

        async void horarioFSiete()
        {
            var direc = new Clases.ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "/horarios";

            MultipartFormDataContent parametros = new MultipartFormDataContent();
            StringContent idC = new StringContent(id__);
            StringContent horaC = new StringContent("3");
            parametros.Add(idC, "id");
            parametros.Add(horaC, "hora");

            var rsp = "";
            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.PostAsync(direccion, parametros);

                Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);

                rsp = respuesta.Content.ReadAsStringAsync().Result;

            }
            if (rsp.Equals("si"))
            {
                rbSiete.IsVisible = true;
            }

        }

        async private void btnAtras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async private void rbSiete_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (rbSiete.IsChecked == true)
                {
                    string action = await DisplayActionSheet("¿Desea seleccionar el horario de las 19:00?", "Cancel", null, "Si", "No");
                    if (action.Equals("Si"))
                    {
                        string hora__ = "19:00";
                        var pagina = new silla(id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, video__, banner__, hora__);
                        await Navigation.PushAsync(pagina);
                    }
                }
            }
            catch (Exception ex) {  }
        }

        async private void rbCinco_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (rbCinco.IsChecked == true)
                {
                    string action = await DisplayActionSheet("¿Desea seleccionar el horario de las 17:00?", "Cancel", null, "Si", "No");
                    if (action.Equals("Si"))
                    {
                        string hora__ = "17:00";
                        var pagina = new silla(id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, video__, banner__, hora__);
                        await Navigation.PushAsync(pagina);
                    }
                }
            }
            catch (Exception ex) { }
        }

        async private void rbTres_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (rbTres.IsChecked == true)
                {
                    string action = await DisplayActionSheet("¿Desea seleccionar el horario de las 15:00?", "Cancel", null, "Si", "No");
                    if (action.Equals("Si"))
                    {
                        string hora__ = "15:00";
                        var pagina = new silla(id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, video__, banner__, hora__);
                        await Navigation.PushAsync(pagina);
                    }
                }
            }
            catch (Exception ex) { }
        }




    }
}