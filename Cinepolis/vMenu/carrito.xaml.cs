using Acr.UserDialogs;
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
    public partial class carrito : ContentPage
    {
        int cantidad4 = 0, cantidad1=0, cantidad2 = 0, cantidad3 = 0, cantidad5 = 0, cantidad6 = 0, cantidad7 = 0, cantidad8 = 0;
        public carrito()
        {
            InitializeComponent();
        }                     
       

        async private void compar_Clicked(object sender, EventArgs e)
        {
            string content = "Su Pedido es ";
            if (cantidad1 > 0 || cantidad2 > 0 || cantidad3 > 0 || cantidad4 > 0 || cantidad5 > 0 || cantidad6 > 0 || cantidad7 > 0 || cantidad8 > 0)
            {
                if (cantidad1 > 0)
                {
                    content = content + "\n" + cantidad1.ToString() + " " + Ele1.Text;
                }

                if (cantidad2 > 0)
                {
                    content = content + "\n" + cantidad2.ToString() + " " + Ele2.Text;
                }

                if (cantidad3 > 0)
                {
                    content = content + "\n" + cantidad3.ToString() + " " + Ele3.Text;
                }

                if (cantidad4 > 0)
                {
                    content = content + "\n" + cantidad4.ToString() + " " + Ele4.Text;
                }

                if (cantidad5 > 0)
                {
                    content = content + "\n" + cantidad5.ToString() + " " + Ele5.Text;
                }

                if (cantidad6 > 0)
                {
                    content = content + "\n" + cantidad6.ToString() + " " + Ele6.Text;
                }

                if (cantidad7 > 0)
                {
                    content = content + "\n" + cantidad7.ToString() + " " + Ele7.Text;
                }

                if (cantidad8 > 0)
                {
                    content = content + "\n" + cantidad8.ToString() + " " + Ele8.Text;
                }
                int tp = (cantidad1 * Convert.ToInt32(p1.Text)) +  (cantidad2 * Convert.ToInt32(p2.Text)) + (cantidad3 * Convert.ToInt32(p3.Text)) + (cantidad4 * Convert.ToInt32(p4.Text)) +
                  (cantidad5 * Convert.ToInt32(p5.Text)) + (cantidad6 * Convert.ToInt32(p6.Text)) + (cantidad7 * Convert.ToInt32(p7.Text)) + (cantidad8 * Convert.ToInt32(p8.Text));
                var pagina = new carritoCompra(content, tp);
                UserDialogs.Instance.ShowLoading("Cargando Lista", MaskType.Clear);
                await Navigation.PushAsync(pagina);
            }
            else
            {
                await DisplayAlert("Sin Productos Seleccionados", "No hay Productos Seleccionados!", "OK");
            }
        }

    

        async private void atras_Clicked(object sender, EventArgs e)
        {
            string content = "Su Pedido ";
            if (cantidad1 > 0 || cantidad2 > 0 || cantidad3 > 0 || cantidad4 > 0 || cantidad5 > 0 || cantidad6 > 0 || cantidad7 > 0 || cantidad8 > 0)
            {
                if (cantidad1 > 0)
                {
                   content = content + "\n" + cantidad1.ToString() + " " + Ele1.Text;
                   // content = content + cantidad1.ToString() + Ele1.Text;
                }

                if (cantidad2 > 0)
                {
                    content = content + "\n" + cantidad2.ToString() + " " + Ele2.Text;
                }

                if (cantidad3 > 0)
                {
                    content = content + "\n" + cantidad3.ToString() + " " + Ele3.Text;
                }

                if (cantidad4 > 0)
                {
                    content = content + "\n" + cantidad4.ToString() + " " + Ele4.Text;
                }

                if (cantidad5 > 0)
                {
                    content = content + "\n" + cantidad5.ToString() + " " + Ele5.Text;
                }

                if (cantidad6 > 0)
                {
                    content = content + "\n" + cantidad6.ToString() + " " + Ele6.Text;
                }

                if (cantidad7 > 0)
                {
                    content = content + "\n" + cantidad7.ToString() + " " + Ele7.Text;
                }

                if (cantidad8 > 0)
                {
                    content = content + "\n" + cantidad8.ToString() + " " + Ele8.Text;
                }
                int tp = (cantidad1 * Convert.ToInt32(p1.Text)) + (cantidad2 * Convert.ToInt32(p2.Text)) + (cantidad3 * Convert.ToInt32(p3.Text)) + (cantidad4 * Convert.ToInt32(p4.Text)) +
                  (cantidad5 * Convert.ToInt32(p5.Text)) + (cantidad6 * Convert.ToInt32(p6.Text)) + (cantidad7 * Convert.ToInt32(p7.Text)) + (cantidad8 * Convert.ToInt32(p8.Text));
                Console.WriteLine("Valores " + content.ToString() + tp.ToString());

             //   int tp = (cantidad1 * 120) + (cantidad2 * 95) + (cantidad3 * 100) + (cantidad4 * 35);
               await DisplayAlert("Mi Compra", content + "\n\n" + "Su Total en Factura es "+ tp.ToString(),"OK");
              //  var pagina = new carritoCompra(content, tp);
              //  await Navigation.PushAsync(pagina);
            }
            else
            {
                await DisplayAlert("Sin Productos Seleccionados", "No hay Productos Seleccionados!", "OK");
            }

            //if (cantidad1 > 0 || cantidad2 > 0 || cantidad3 > 0 || cantidad4 > 0) { 
            //    if (cantidad1 > 0)
            //    {
            //        content =content+ cantidad1.ToString() + " Combos. Palomitas de maíz + dos refrescos (L. 120 C/u), ";
            //    }

            //    if (cantidad2 > 0)
            //    {
            //        content = content + cantidad2.ToString() + " Combos. palomitas de maíz + un regreso (L. 95), ";
            //    }

            //    if (cantidad3 > 0)
            //    {
            //        content = content + cantidad3.ToString() + " Combos.  nachos + un refresco (L. 100), ";
            //    }

            //    if (cantidad4 > 0)
            //    {
            //        content = content + cantidad4.ToString() + " Refrescos adicionales tiene un costo de 35, ";
            //    }
            //    int tp= (cantidad1 * 120) + (cantidad2 * 95) + (cantidad3 * 100) + (cantidad4 * 35);
            //    await DisplayAlert("Carrito", content+"Su total a pagar es "+tp.ToString(),"OK");
            //}
            //else
            //{
            //    await DisplayAlert("Error", "Debe seleccionar algun producto", "ok");
            //}
        }

    

        private void sliderCb1_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            cantidad1 = Convert.ToInt32(sliderCb1.Value);
            cantidadCb1.Text = "Cantidad: " + cantidad1.ToString();
        }            

        private void sliderCb2_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            cantidad2 = Convert.ToInt32(sliderCb2.Value);
            cantidadCb2.Text = "Cantidad: " + cantidad2.ToString();
        }

        private void sliderCb3_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            cantidad3 = Convert.ToInt32(sliderCb3.Value);
            cantidadCb3.Text = "Cantidad: " + cantidad3.ToString();
        }
        private void sliderCb4_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            cantidad4 = Convert.ToInt32(sliderCb4.Value);
            cantidadCb4.Text = "Cantidad: " + cantidad4.ToString();
        }

        private void sliderCb5_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            cantidad5 = Convert.ToInt32(sliderCb5.Value);
            cantidadCb5.Text = "Cantidad: " + cantidad5.ToString();
        }
        private void sliderCb6_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            cantidad6 = Convert.ToInt32(sliderCb6.Value);
            cantidadCb6.Text = "Cantidad: " + cantidad6.ToString();
        }
       
        private void sliderCb7_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            cantidad7 = Convert.ToInt32(sliderCb7.Value);
            cantidadCb7.Text = "Cantidad: " + cantidad7.ToString();
        }
        private void sliderCb8_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            cantidad8 = Convert.ToInt32(sliderCb8.Value);
            cantidadCb8.Text = "Cantidad: " + cantidad8.ToString();
        }
    }
}