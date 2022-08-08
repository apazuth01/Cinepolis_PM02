using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cinepolis.Clases;
using Xamarin.Forms.Internals;
using System.Globalization;

namespace Cinepolis.vMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
  
    public partial class horarios : ContentPage
    {
        string id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, video__, banner__ ;
        string Fecha_Peli, Fecha_Comparar;
        string FechaVerPelicula;
        CultureInfo cultureInfoUS = new CultureInfo("en-us");
        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            //TimeSpan timeSpan = DatePicker.Date.ToString();
            ///  DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            //  Log.Debug(TAG, selectedDate.ToLongDateString());
            //  _dateSelectedHandler(selectedDate);
            //   lblfecha.Text=  String.Format("{0} day{1} between dates",      timeSpan.Days, timeSpan.Days == 1 ? "" : "s");
            var picker = sender as DatePicker;
            DateTime? date = picker.Date;

            lblfecha.Text= date.Value.ToString();
            Fecha_Peli = date.Value.ToShortDateString();
            FechaVerPelicula = date.Value.ToLongDateString();

        }

        private void HeaderList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void HeaderList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lblfecha.Text = HeaderList.SelectedItem.ToString();
            horarioFTres();
            horarioFCinco();
            horarioFSiete();
            if (rbTres.IsVisible != true && rbCinco.IsVisible != true && rbSiete.IsVisible != true) 
            {
                Message("Informacion", "Lo Sentimos!" + "\nNo hay Horario Disponible para Esta Función... Intenta mas Tarde");
                return;
            }
        }

        // id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, video__, banner__



        public horarios(string id_, string nombre_, string synopsis_, string anio_, string clasificacion_, string genero_, string director_, string duracion_, string video_, string banner_)
        {
            InitializeComponent();
           
            lbhora.Text = DateTime.Now.Hour.ToString();
            Fecha_Comparar = (DateTime.Now.ToShortDateString());
          

            Console.WriteLine("Fecha Comparar" + Fecha_Comparar, cultureInfoUS);

         
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
            imgBanner.Source = banner_;
            // Console.WriteLine(id__.ToString());
            rbCinco.IsVisible = false;
            rbTres.IsVisible = false;
            rbSiete.IsVisible = false;
            // Console.WriteLine("Este es :" + id__.ToString());

            Obtener_Fechas();
          // horarioFTres();
           //horarioFCinco();
           //horarioFSiete();

        }
        async void horarioFTres()
        {
           // Console.WriteLine("En horario 3" +id__.ToString());
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
                string fecha_funcion = lblfecha.Text;
                //var parametros = "id=" + idc + "&hora=" + hora;
                var parametros = "id=" + idc + "&fecha=" + fecha_funcion + "&hora=" + hora;
                var direc = new ruta();
                String direccion = direc.ruta_();
                //direccion = direccion + "/horarios";
                direccion = direccion + "/fecha_horarios";
                Console.WriteLine(parametros.ToString());
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(direccion, "POST", parametros);
                Console.WriteLine(HtmlResult);

                if (HtmlResult.Contains("si"))
                {
                    rbTres.IsVisible = true;
                    lblhorario.IsVisible = true;
                }
                else
                {
                    rbTres.IsVisible = false;
                    lblhorario.IsVisible = false;
                }
            }
      

        }

        async void horarioFCinco()
        {
           

            using (WebClient wc = new WebClient())
            {
                string idc = id__;
                string hora = "2";
                string fecha_funcion = lblfecha.Text;

                var parametros = "id=" + idc + "&fecha=" + fecha_funcion + "&hora=" + hora;
                var direc = new ruta();
                String direccion = direc.ruta_();
                //direccion = direccion + "/horarios";
                direccion = direccion + "/fecha_horarios";
                Console.WriteLine(parametros.ToString());
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(direccion, "POST", parametros);
                Console.WriteLine(HtmlResult);

                if (HtmlResult.Contains("si"))
                {
                    rbCinco.IsVisible = true;
                    lblhorario.IsVisible = true;
                }
                else
                {
                    rbCinco.IsVisible = false;
                    lblhorario.IsVisible = false;
                }
            }

            //var direc = new Clases.ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "/horarios";

            //MultipartFormDataContent parametros = new MultipartFormDataContent();
            //StringContent idC = new StringContent(id__);
            //StringContent horaC = new StringContent("2");
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
            //    rbCinco.IsVisible = true;
            //}

        }

        async void horarioFSiete()
        {
            using (WebClient wc = new WebClient())
            {
                string idc = id__;
                string hora = "3";
                string fecha_funcion = lblfecha.Text;

                // var parametros = "id=" + idc + "&hora=" + hora;
                var parametros = "id=" + idc + "&fecha=" + fecha_funcion + "&hora=" + hora;
                var direc = new ruta();
                String direccion = direc.ruta_();
                //direccion = direccion + "/horarios";
                direccion = direccion + "/fecha_horarios";
                Console.WriteLine(parametros.ToString());
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(direccion, "POST", parametros);
                Console.WriteLine(HtmlResult);

                if (HtmlResult.Contains("si"))
                {
                    rbSiete.IsVisible = true;
                    lblhorario.IsVisible = true;
                }
                else
                {
                    rbSiete.IsVisible = false;
                    lblhorario.IsVisible = false;
                }
            }

            //var direc = new Clases.ruta();
            //String direccion = direc.ruta_();
            //direccion = direccion + "/horarios";

            //MultipartFormDataContent parametros = new MultipartFormDataContent();
            //StringContent idC = new StringContent(id__);
            //StringContent horaC = new StringContent("3");
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
            //    rbSiete.IsVisible = true;
            //}

        }

        async void Obtener_Fechas() 
        {
            using (WebClient wc = new WebClient())
            {
                string idc = id__;


                var parametros = "idPelicula=" + idc;
                var direc = new ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "/funciones";
                Console.WriteLine(parametros.ToString());
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(direccion, "POST", parametros);
                Console.WriteLine("Fechas de Funcion" + HtmlResult);
                string nt;
                string nt2, nt3;
                string[] items;
                string[] remover1 = new string[] { "\"", "[", "]" };
                string[] items2;
               // nt = HtmlResult.ToString();
                //for (int i = 0; i < 41; i++)
                //{
                //    HtmlResult.Replace("\"", string.Empty);
                //    HtmlResult.Replace("[", string.Empty);
                //    HtmlResult.Replace("]", string.Empty);
                //    Console.WriteLine(Convert.ToString("Convertido " + HtmlResult + " sillitas"));
                //    //Console.WriteLine("Aca Esta " + este);
                //}
                nt = HtmlResult.Replace("\"", string.Empty);
                nt2 = nt.Replace("[", string.Empty);
                nt3 = nt2.Replace("]", string.Empty);
                // items = new string[] {HtmlResult.Remove(0,2)};
                string[] words = nt3.Split(',');

                //foreach (var word in words)
                //{
                //    System.Console.WriteLine($"{word}");
                //}
                items = words ;
               // nt = items.ToString();
                
                // nt = items.ToString();
                // nt = nt.Remove(0, 2);
               
               // items2 = new string[] { nt.Replace("[", string.Empty) };
               // items2 = new string[] { nt };
                HeaderList.ItemsSource = items;
               
                Console.WriteLine("Aca Esta " + nt3);
                //if (HtmlResult.Contains("si"))
                // lista.ItemsSource = items;
                // fechas_picker.Date = HtmlResult;
                //{
                //    rbSiete.IsVisible = true;
                //}
                // For i As Integer = 0 To list.Count - 1


                //  Dim value As String = TryCast(list(i), String);
                // Console.WriteLine(value);

                //textbox.text = value & vbCrLf





                // Next

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
                  

                    if (string.IsNullOrEmpty(lblfecha.Text))
                    {
                        rbSiete.IsChecked = false;

                        Message("Advertencia", "Seleccione la Fecha");
                        return;

                    }

                    //lbhora.Text = DateTime.Now.Hour.ToString();
                    //string dos_letras = rbSiete.Content.ToString();
                    //string horas_comparar = dos_letras.Substring(0, 2);
                    //DateTime f1 = Convert.ToDateTime(lblfecha.Text, cultureInfoUS);
                    //DateTime f2 = Convert.ToDateTime(Fecha_Comparar, cultureInfoUS);
                    //int result = DateTime.Compare(f1, f2);
                    //if (f1.Date < f2.Date)
                    //{
                    //    rbCinco.IsChecked = false;
                    //    Message("Error", "La Fecha Seleccionada es Anterior a la Fecha Actual!");
                    //    return;
                    //}
                    //else if (f1.Date >= f2.Date && Convert.ToInt32(lbhora.Text) > Convert.ToInt32(horas_comparar))
                    //{
                    //    rbCinco.IsChecked = false;
                    //    Message("Error", "La Hora de la Funcion elegida es menor a la Hora Actual");
                    //    return;
                    //}
                  
                  
                        string action = await DisplayActionSheet("¿Confirma la Fecha " + Fecha_Peli + " y el horario de las 19:00?", "Cancel", null, "Si", "No");
                    if (action.Equals("Si"))
                    {
                        string hora__ = "19:00";
                        var pagina = new silla(id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, video__, banner__, hora__, lblfecha.Text, FechaVerPelicula);
                        await Navigation.PushAsync(pagina);
                    }
                }
            }
            catch (Exception ex) {
            }
        }

        async private void rbCinco_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Console.WriteLine("La Fecha " + lblfecha.Text);
            try
            {
              
                if (rbCinco.IsChecked == true)
                {
                    if (string.IsNullOrEmpty(lblfecha.Text))
                    {
                        rbCinco.IsChecked = false;

                        Message("Advertencia", "Seleccione la Fecha");
                        return;
                        
                    }
                    //lbhora.Text = DateTime.Now.Hour.ToString();
                    //string dos_letras = rbSiete.Content.ToString();
                    //string horas_comparar = dos_letras.Substring(0, 2);
                    //DateTime f1 = Convert.ToDateTime(lblfecha.Text, cultureInfoUS);
                    //DateTime f2 = Convert.ToDateTime(Fecha_Comparar, cultureInfoUS);
                    //int result = DateTime.Compare(f1, f2);
                    //if (f1.Date < f2.Date)
                    //{
                    //    rbCinco.IsChecked = false;
                    //    Message("Error", "La Fecha Seleccionada es Anterior a la Fecha Actual!");
                    //    return;
                    //}
                    //else if (f1.Date >= f2.Date && Convert.ToInt32(lbhora.Text) > Convert.ToInt32(horas_comparar))
                    //{
                    //    rbCinco.IsChecked = false;
                    //    Message("Error", "La Hora de la Funcion elegida es menor a la Hora Actual");
                    //    return;
                    //}

                    string action = await DisplayActionSheet("¿Confirma la Fecha " + Fecha_Peli + " y el horario de las 17:00?", "Cancel", null, "Si", "No");
                    if (action.Equals("Si"))
                    {
                        string hora__ = "17:00";
                        var pagina = new silla(id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, video__, banner__, hora__,lblfecha.Text,FechaVerPelicula);
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

                    if (string.IsNullOrEmpty(lblfecha.Text))
                    {
                        rbTres.IsChecked = false;

                        Message("Advertencia", "Seleccione la Fecha");
                        return;

                    }
                    //lbhora.Text = DateTime.Now.Hour.ToString();
                    //string dos_letras = rbSiete.Content.ToString();
                    //string horas_comparar = dos_letras.Substring(0, 2);
                    //DateTime f1 = Convert.ToDateTime(lblfecha.Text, cultureInfoUS);
                    //DateTime f2 = Convert.ToDateTime(Fecha_Comparar, cultureInfoUS);
                    //int result = DateTime.Compare(f1, f2);
                    //if (f1.Date < f2.Date)
                    //{
                    //    rbCinco.IsChecked = false;
                    //    Message("Error", "La Fecha Seleccionada es Anterior a la Fecha Actual!");
                    //    return;
                    //}
                    //else if (f1.Date >= f2.Date && Convert.ToInt32(lbhora.Text) > Convert.ToInt32(horas_comparar))
                    //{
                    //    rbCinco.IsChecked = false;
                    //    Message("Error", "La Hora de la Funcion elegida es menor a la Hora Actual");
                    //    return;
                    //}

                    string action = await DisplayActionSheet("¿Confirma la Fecha " + Fecha_Peli + " y el horario de las 15:00?", "Cancel", null, "Si", "No");
                    if (action.Equals("Si"))
                    {
                        string hora__ = "15:00";
                        var pagina = new silla(id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, video__, banner__, hora__, lblfecha.Text,FechaVerPelicula);
                        await Navigation.PushAsync(pagina);
                    }
                }
            }
            catch (Exception ex) { }
        }

        private async void Message(string title, string message)
        {
            await DisplayAlert(title, message, "OK");
        }


    }
}