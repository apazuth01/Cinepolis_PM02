using Cinepolis.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.aUsuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarUsuario : ContentPage
    {

        String nombre = "", apellido = "", correo = "", contraseña = "", ciudad = "", nombreT = "", numeroT = "", fechaT = "", codigoT = "", verificado = "False";

        private void txtCorreo_Unfocused(object sender, FocusEventArgs e)
        {
            persistencia();
        }

        private void txtPass_Unfocused(object sender, FocusEventArgs e)
        {
            persistencia();
        }

        private void txtCiudad_Unfocused(object sender, FocusEventArgs e)
        {
            persistencia();
        }

        private void txtNombreT_Unfocused(object sender, FocusEventArgs e)
        {
            persistencia();
        }

    

        private void txtFechaEx_Unfocused(object sender, FocusEventArgs e)
        {
            persistencia();
        }

        private void txtCodigo_Unfocused(object sender, FocusEventArgs e)
        {
            persistencia();
        }

        private void txtNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
          //  persistencia();
        }

        private void txtApellidos_Unfocused(object sender, FocusEventArgs e)
        {
            persistencia();
        }

        private void txtNombre_Unfocused(object sender, FocusEventArgs e)
        {
            persistencia();
        }

     

        DateTime ultima;
        private void txtFechaN_DateSelected(object sender, DateChangedEventArgs e)
        {
            ultima = e.NewDate;
        }

        public RegistrarUsuario()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Application.Current.Properties.ContainsKey("nombre"))
            {
                txtNombre.Text = Application.Current.Properties["nombre"] as string;
            }
            if (Application.Current.Properties.ContainsKey("apellidos"))
            {
                txtApellidos.Text = Application.Current.Properties["apellidos"] as string;
            }
            if (Application.Current.Properties.ContainsKey("correo"))
            {
                txtCorreo.Text = Application.Current.Properties["correo"] as string;
            }
            if (Application.Current.Properties.ContainsKey("clave"))
            {
                txtPass.Text = Application.Current.Properties["clave"] as string;
            }
            if (Application.Current.Properties.ContainsKey("ciudad"))
            {
                ciudad = Application.Current.Properties["ciudad"] as string;
            }
            if (Application.Current.Properties.ContainsKey("proveedor_tarjeta"))
            {
                txtNombreT.Text = Application.Current.Properties["proveedor_tarjeta"] as string;
            }
            if (Application.Current.Properties.ContainsKey("tarjeta"))
            {
                txtNumero.Text = Application.Current.Properties["tarjeta"] as string ;
            }
            if (Application.Current.Properties.ContainsKey("fecha_tarjeta"))
            {
                txtFechaEx.Text = Application.Current.Properties["fecha_tarjeta"] as string;
            }
            if (Application.Current.Properties.ContainsKey("codigo_tarjeta"))
            {
                txtNumero.Text = Application.Current.Properties["codigo_tarjeta"] as string;
            }
        }

        private async void btnContinuar_Clicked(object sender, EventArgs e)
        {
            obtener();
            if (txtCorreo.Text.Contains("@"))
            {

            }
            else
            {
                await DisplayAlert("Correo Incorrecto", "La Direccion de Correo Proporcionada no es Valida verifica Nuevamente", "OK");
                return;
            }

            int cant = numeroT.Length;
            if (cant != 16)
            {
                await DisplayAlert("Faltan Caracteres", "El Numero de Tarjeta debe contener los 16 caracteres Estandard", "OK");
                return;
            }

            if (String.IsNullOrWhiteSpace(nombre) || String.IsNullOrWhiteSpace(apellido) || String.IsNullOrWhiteSpace(correo) || String.IsNullOrWhiteSpace(contraseña) || String.IsNullOrWhiteSpace(nombreT) || String.IsNullOrWhiteSpace(numeroT) || String.IsNullOrWhiteSpace(fechaT) || String.IsNullOrWhiteSpace(codigoT) || cant != 16)
            {
                await DisplayAlert("Error", "Es necesario llenar todos los campos correctamente.", "OK");
                return;
            }
            else
            {
                var pagina = new verificarCuenta(nombre, apellido, correo, contraseña, ciudad, nombreT, numeroT, fechaT, codigoT, verificado);
                await Navigation.PushAsync(pagina);
            }

        }
       async void persistencia()
            {
            Application.Current.Properties["nombre"] = txtNombre.Text;
            Application.Current.Properties["apellidos"] = txtApellidos.Text;
            Application.Current.Properties["correo"] = txtCorreo.Text;
            Application.Current.Properties["clave"] = txtPass.Text;
            Application.Current.Properties["ciudad"] = ciudad;
            Application.Current.Properties["proveedor_tarjeta"] = txtNombreT.Text;
            Application.Current.Properties["Tarjeta"] = txtNumero.Text;
            Application.Current.Properties["Fecha_tarjeta"] = txtFechaEx.Text;
            Application.Current.Properties["codigo_tarjeta"] = txtCodigo.Text;

            await Application.Current.SavePropertiesAsync();

        }

        void obtener()
        {
            nombre = txtNombre.Text;
            apellido = txtApellidos.Text;
            correo = txtCorreo.Text;
            contraseña = txtPass.Text;


            try
            {
                ciudad = txtCiudad.SelectedItem.ToString();
            }
            catch (Exception)
            {

                ciudad = "San Pedro Sula";
            }

            nombreT = txtNombreT.Text;
            numeroT = txtNumero.Text;
            fechaT = txtFechaEx.Text;
            codigoT = txtCodigo.Text;
            verificado = "False";

            Console.WriteLine("Datos Obtenidos " + nombreT + numeroT + fechaT + codigoT + verificado);
        }


    }
}