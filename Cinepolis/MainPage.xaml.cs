using Cinepolis.Clases;
using Cinepolis.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;

namespace Cinepolis
{
    public partial class MainPage : ContentPage
    {
       public string email = "", pass = "";
      
        public MainPage()
        {
            InitializeComponent();
            lblCrearFunc();
            lblOlvidoFunc();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
           

            try { 
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


        }
        private async void btnContinuar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCorreo.Text) || String.IsNullOrWhiteSpace(txtContra.Text))
            {
                await DisplayAlert("Error", "Es necesario llenar los campos", "OK");
            }
            else
            {

                /*  var direc = new ruta();
                  String direccion = direc.ruta_();
                  direccion = direccion + "/login";

                 MultipartFormDataContent parametros = new MultipartFormDataContent();
                  StringContent email = new StringContent(txtCorreo.Text);
                  StringContent pass = new StringContent(txtContra.Text);
                  parametros.Add(email, "email");
                  parametros.Add(pass, "pass");
                  Debug.WriteLine("Texto " + parametros.ToString());

                  using (HttpClient client = new HttpClient())
                  {
                      var respuesta = await client.PostAsync(direccion, parametros);

                      Debug.WriteLine(respuesta.Content.ReadAsStringAsync().Result);
                      var rs = respuesta.Content.ReadAsStringAsync().Result;
                      Debug.WriteLine(rs.ToString());

                      if (rs.Equals("NO"))
                      {
                          await DisplayAlert("Error", "Datos Incorrectos", "Ok");
                      }
                      else
                      {

                          var emple = new constructorLogin
                          {
                              nombre = rs,
                              correo = txtCorreo.Text
                          };
                          var resultado = await App.BaseDatos.EmpleadoGuardar(emple);
                          if (resultado != 0)
                          {
                              var pagina = new vMenu.home();
                              await Navigation.PushAsync(pagina);
                          }

                      }

                  }*/
                email = txtCorreo.Text;
                pass = txtContra.Text;
                

               //WebClient cliente = new WebClient();
                //var parametros = new System.Collections.Specialized.NameValueCollection();
                //parametros.Add("email", email);
                //parametros.Add("pass", pass);
                //var direc = new ruta();
                //String direccion = direc.ruta_();
                //direccion = direccion + "/login";

                using (WebClient wc = new WebClient())
                {
                    // var parametros = new System.Collections.Specialized.NameValueCollection();
                    var parametros = "email=" + email + "&pass=" + pass;
                    //parametros.Add("email", email);
                    //parametros.Add("pass", pass);
                    var direc = new ruta();
                    String direccion = direc.ruta_();
                    direccion = direccion + "/login";

                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string HtmlResult = wc.UploadString(direccion, parametros);
                    Console.WriteLine(HtmlResult);

                    if (HtmlResult.Equals("SI")) {
                        var pagina = new vMenu.home();
                        await Navigation.PushAsync(pagina);
                    }
                    else if (HtmlResult.Equals("NO"))
                    {
                        await DisplayAlert("Error de Datos", "Los Datos Ingresados No Coinciden", "Ok");
                    }
                    else if (HtmlResult.Equals("NO VERIFICADO"))
                    {
                        await DisplayAlert("Erro de Verificacion", "La Cuenta está pendiente de Verficación! Favor Revisa Tu Correo e ingresa tu Codigo de Verificacion", "Ok");
                    }
                }

//                cliente.UploadValues(direccion, "POST", parametros);

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



    }
}
