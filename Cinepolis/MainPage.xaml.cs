using Acr.UserDialogs;
using Cinepolis.Clases;
using Cinepolis.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Cinepolis
{
    public partial class MainPage : ContentPage
    {
       public string email = "", pass = "", nombre="";      
        public MainPage()
        {
            InitializeComponent();
            lblCrearFunc();
            lblOlvidoFunc();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var datos = await App.BaseDatos.listaempleados();
                int n = datos.Count();
                if (n == 1)
                {
                    var pagina = new vMenu.home();
                    await Navigation.PushAsync(pagina);
                }
            }
            catch (Exception ex)
            {
                var datos = await App.BaseDatos.listaempleados();
                int n = datos.Count();
                if (n == 1)
                {
                    var pagina = new vMenu.home();
                    await Navigation.PushAsync(pagina);
                }
            }

            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                Message("Advertencia", "Actualmente no cuenta con acceso a internet");
                return;
            }  
        }
        private async void btnContinuar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCorreo.Text) || String.IsNullOrWhiteSpace(txtContra.Text))
            {
                await DisplayAlert("Error", "Es necesario llenar los campos", "OK");
            }
            else
            {
                email = txtCorreo.Text;
                pass = txtContra.Text;               


                using (WebClient wc = new WebClient())
                {              
                    var parametros = "email=" + email + "&pass=" + pass;
                    var direc = new ruta();
                    String direccion = direc.ruta_();
                    direccion = direccion + "/login";
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string HtmlResult = wc.UploadString(direccion, parametros);
                    Console.WriteLine(HtmlResult);
                    if (HtmlResult.Equals("SI")) {
                        var emple = new constructorLogin
                        {
                            nombre = HtmlResult,
                            correo = txtCorreo.Text
                        };
                        var resultado = await App.BaseDatos.EmpleadoGuardar(emple);
                        if (resultado != 0)
                        {                  
                           var pagina = new vMenu.home();
                           await Navigation.PushAsync(pagina);
                        }                       
                    }
                    else if (HtmlResult.Equals("NO"))
                    {
                        await DisplayAlert("Error de Datos", "Los Datos Ingresados No Coinciden", "Ok");
                    }
                    else if (HtmlResult.Equals("NO VERIFICADO"))
                    {
                        await DisplayAlert("Error de Verificacion", "La Cuenta está pendiente de Verficación! Favor Revisa Tu Correo e ingresa tu Codigo de Verificacion", "Ok");
                    }
                }    
            }
        }
        void lblCrearFunc()
        {
            lblCrear.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    var pagina = new aUsuarios.RegistrarUsuario();

                    Navigation.PushAsync(pagina);
                })
            });
        }

        void lblOlvidoFunc()
        {
            lblOlvido.GestureRecognizers.Add(new TapGestureRecognizer()            
            {

                Command = new Command(() =>
                {
                    var pagina = new aUsuarios.OlvidoContraseña();

                    Navigation.PushAsync(pagina);
                })
            });
        }

        private async void Message(string title, string message)
        {
            await DisplayAlert(title, message, "OK");
        }

    }
}
