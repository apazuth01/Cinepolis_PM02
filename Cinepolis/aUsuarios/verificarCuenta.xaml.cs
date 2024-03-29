﻿using Cinepolis.Clases;
using Cinepolis.Models;
using System;
using System.Diagnostics;
using System.Net;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;




namespace Cinepolis.aUsuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class verificarCuenta : ContentPage
    {
        String a = "", nombre, apellido, correo, pass, ciudad, nombret, numerot, fechat, codigot, verificadot, token_datos;
        public verificarCuenta(String nombre_, String apellido_, String correo_, String pass_, String ciudad_, String nombreT_, String numerot_, String fechat_, String codigot_, String verificado)
        {
            InitializeComponent();
            generarCodigo(correo_);
            nombre = nombre_;
            apellido = apellido_;
            correo = correo_;
            pass = pass_;
            ciudad = ciudad_;
            nombret = nombreT_;
            numerot = numerot_;
            fechat = fechat_;
            codigot = codigot_;
            verificadot = verificado;
            token_datos=  Preferences.Get("TokenFirebase", "");
            Console.WriteLine("Este es el Token verificado " + token_datos);
            //token_datos = contructorCompra.tok.token_dato.ToString();
        }

        private async void btnVerificar_Clicked(object sender, EventArgs e)
        {
            if (txtCodigo.Text == a)
            {
                verificadot = "True";
                Debug.WriteLine("Codigo " + verificadot.ToString());
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", nombre);
                parametros.Add("apellidos", apellido);
                parametros.Add("correo", correo);
                parametros.Add("pass", pass);
                parametros.Add("ubicacion", ciudad);
                parametros.Add("nombreT", nombret);
                parametros.Add("numeroT", numerot);
                parametros.Add("fechaT", fechat);
                parametros.Add("codigo", codigot);
                parametros.Add("verificado", verificadot);
                parametros.Add("token", token_datos);

                Preferences.Set("Correo", correo);
                Preferences.Set("Tarjeta", numerot);
                var direc = new ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "/usuarios";
                cliente.UploadValues(direccion, "PUT", parametros);

                var emple = new constructorLogin
                {
                    nombre_completo = nombre + " " + apellido,
                    nombre = nombre,
                    correo = correo,
                    apellidos = apellido,
                    clave = pass,
                    ubicacion = ciudad,
                    tarjeta = numerot,
                    proveedor = nombret,
                    fecha_tarjeta = fechat,
                    cod_seguridad = codigot

                };
                await App.BaseDatos.EmpleadoGuardar(emple);

                await DisplayAlert("¡Cuenta Verificada Exitosamente!", "Bienvenido a la Familia Xinepolis.", "OK");

                var pagina = new MainPage();

                await Navigation.PushAsync(pagina);
                
            }
            else
            {
                await DisplayAlert("Error", "Codigo Incorrecto.", "OK");
            }

        }


        async void generarCodigo(String correo)
        {
            Random rnd = new Random();



            for (uint ctr = 1; ctr <= 1; ctr++)
            {

                a = Convert.ToString(rnd.Next(9999));
                Debug.WriteLine("Codigo " + a.ToString());
            }


            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("correo_", correo);
            parametros.Add("codigo_", a);
            var direc = new ruta();
            String direccion = direc.ruta_();
            direccion = direccion + "/usuarios";

            cliente.UploadValues(direccion, "POST", parametros);

            //var respuesta = await cliente.OpenReadAsync(direccion, parametros);

        }

    }
}