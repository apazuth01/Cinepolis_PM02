using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.vMenu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page_Rate : ContentPage
	{
		public Page_Rate ()
		{
			InitializeComponent ();
		}

        private void ShowButton_Clicked(object sender, EventArgs e)
        {
			int rating = Rating.SelectedStarValue;
			DisplayAlert("Aplicacion Calificada", rating.ToString(), "Ok");
		}
    }
}