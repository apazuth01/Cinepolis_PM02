using Cinepolis.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.vMenu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page_Rate : ContentPage
	{
        string correo, opinion;
        public long Id { get; set; }
        public Page_Rate ()
		{
			InitializeComponent ();
            datoCorreo();
            try
            {
                Id = Preferences.Get("extrellas", 0);
                Console.WriteLine("Rate " + Id.ToString());
            }
            catch (Exception ex)
            {
                Id = 0;
            }
          
            if (Id.ToString() != "0")
            {
                Rating.SelectedStarValue = (int)Convert.ToInt64(Id);
            }
            else
            {
                Rating.SelectedStarValue = 1;
            }
            

        }

        async void datoCorreo()
        {
            var datos = await App.BaseDatos.ObtenerCliente();
            correo = datos.correo.ToString();
      
        }

        private async void ShowButton_Clicked(object sender, EventArgs e)
        {
            
			int rating = Rating.SelectedStarValue;

            string estrellitas = rating.ToString();
            opinion = txtopinion.Text;
            Preferences.Set("extrellas", rating);
            WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("correo", correo);
            parametros.Add("estrellas", estrellitas);
                parametros.Add("opinion", opinion);
                
          

              
                
                var direc = new ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "/usuarios";
                cliente.UploadValues(direccion, "PUT", parametros);



            DisplayAlert("Gracias por tu Calificacion", "Un Gusto Atenderte", "Ok");

            await Navigation.PushAsync(new home());

        }
       
    }
}