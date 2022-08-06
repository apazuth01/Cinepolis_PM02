using Cinepolis.Clases;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.vMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class silla : ContentPage
    {
        int cbtn1 = 0, cbtn2 = 0, cbtn3 = 0, cbtn4 = 0, cbtn5 = 0;
        int cbtn6 = 0, cbtn7 = 0, cbtn8 = 0, cbtn9 = 0, cbtn10 = 0;
        int cbtn11 = 0, cbtn12 = 0, cbtn13 = 0, cbtn14 = 0, cbtn15 = 0;
        int cbtn16 = 0, cbtn17 = 0, cbtn18 = 0, cbtn19 = 0, cbtn20 = 0;
        int cbtn21 = 0, cbtn22 = 0, cbtn23 = 0, cbtn24 = 0, cbtn25 = 0;
        int cbtn26 = 0, cbtn27 = 0, cbtn28 = 0, cbtn29 = 0, cbtn30 = 0;
        int cbtn31 = 0, cbtn32 = 0, cbtn33 = 0, cbtn34 = 0, cbtn35 = 0;
        int cbtn36 = 0, cbtn37 = 0, cbtn38 = 0, cbtn39 = 0, cbtn40 = 0;

        int contador = 0;
        string id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, banner__, video__, hora__,Fechas__;
        string arreglo;
        string FechaVerPelicula;
        public silla(string id_, string nombre_, string synopsis_, string anio_, string clasificacion_, string genero_, string director_, string duracion_, string video_, string banner_, string hora_, string Fechas, string Fecha_Pelicula)
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
            hora__ = hora_;
            Fechas__ = Fechas;
            FechaVerPelicula = Fecha_Pelicula;
            consulta_oupadas();
     
        }
     
        private void btn1_Clicked(object sender, EventArgs e)
        {
            if (cbtn1 == 0)
            {
                
                btn1.BackgroundColor = Color.Green;
                cbtn1 = 1;
                contador++;
            }
            else
            {
                btn1.BackgroundColor = Color.FromHex("#005eff");
                btn1.TextColor = Color.White;
                btn1.FontAttributes = FontAttributes.Bold;
                cbtn1 = 0;
                contador--;
            }

            contadorF();
        }

        private void btn2_Clicked(object sender, EventArgs e)
        {
            if (cbtn2 == 0)
            {
                btn2.BackgroundColor = Color.Green;
                cbtn2 = 1;
                contador++;
            }
            else
            {
                btn2.BackgroundColor = Color.FromHex("#005eff");
                btn2.TextColor = Color.White;
                btn2.FontAttributes = FontAttributes.Bold;
                cbtn2 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn3_Clicked(object sender, EventArgs e)
        {
            if (cbtn3 == 0)
            {
                btn3.BackgroundColor = Color.Green;
                cbtn3 = 1;
                contador++;
            }
            else
            {
                btn3.BackgroundColor = Color.FromHex("#005eff");
                btn3.TextColor = Color.White;
                btn3.FontAttributes = FontAttributes.Bold;
                cbtn3 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn4_Clicked(object sender, EventArgs e)
        {
            if (cbtn4 == 0)
            {
                btn4.BackgroundColor = Color.Green;
                cbtn4 = 1;
                contador++;
            }
            else
            {
                btn4.BackgroundColor = Color.FromHex("#005eff");
                btn4.TextColor = Color.White;
                btn4.FontAttributes = FontAttributes.Bold;
                cbtn4 = 0;
                contador--;
            }
            contadorF();
        }


        private void btn5_Clicked(object sender, EventArgs e)
        {
            if (cbtn5 == 0)
            {
                btn5.BackgroundColor = Color.Green;
                cbtn5 = 1;
                contador++;
            }
            else
            {
                btn5.BackgroundColor = Color.FromHex("#005eff");
                btn5.TextColor = Color.White;
                btn5.FontAttributes = FontAttributes.Bold;
                cbtn5 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn6_Clicked(object sender, EventArgs e)
        {
            if (cbtn6 == 0)
            {
                btn6.BackgroundColor = Color.Green;
                cbtn6 = 1;
                contador++;
            }
            else
            {
                btn6.BackgroundColor = Color.FromHex("#005eff");
                btn6.TextColor = Color.White;
                btn6.FontAttributes = FontAttributes.Bold;
                cbtn6 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn7_Clicked(object sender, EventArgs e)
        {
            if (cbtn7 == 0)
            {
                btn7.BackgroundColor = Color.Green;
                cbtn7 = 1;
                contador++;
            }
            else
            {
                btn7.BackgroundColor = Color.FromHex("#005eff");
                btn7.TextColor = Color.White;
                btn7.FontAttributes = FontAttributes.Bold;
                cbtn7 = 0;
                contador--;
            }
            contadorF();
        }


        private void btn8_Clicked(object sender, EventArgs e)
        {
            if (cbtn8 == 0)
            {
                btn8.BackgroundColor = Color.Green;
                cbtn8 = 1;
                contador++;
            }
            else
            {
                btn8.BackgroundColor = Color.FromHex("#005eff");
                btn8.TextColor = Color.White;
                btn8.FontAttributes = FontAttributes.Bold;
                cbtn8 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn9_Clicked(object sender, EventArgs e)
        {
            if (cbtn9 == 0)
            {
                btn9.BackgroundColor = Color.Green;
                cbtn9 = 1;
                contador++;
            }
            else
            {
                btn9.BackgroundColor = Color.FromHex("#005eff");
                btn9.TextColor = Color.White;
                btn9.FontAttributes = FontAttributes.Bold;
                cbtn9 = 0;
                contador--;
            }
            contadorF();
        }


        private void btn10_Clicked(object sender, EventArgs e)
        {
            if (cbtn10 == 0)
            {
                btn10.BackgroundColor = Color.Green;
                cbtn10 = 1;
                contador++;
            }
            else
            {
                btn10.BackgroundColor = Color.FromHex("#005eff");
                btn10.TextColor = Color.White;
                btn10.FontAttributes = FontAttributes.Bold;
                cbtn10 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn11_Clicked(object sender, EventArgs e)
        {
            if (cbtn11 == 0)
            {
                btn11.BackgroundColor = Color.Green;
                cbtn11 = 1;
                contador++;
            }
            else
            {
                btn11.BackgroundColor = Color.FromHex("#005eff");
                btn11.TextColor = Color.White;
                btn11.FontAttributes = FontAttributes.Bold;
                cbtn11 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn12_Clicked(object sender, EventArgs e)
        {
            if (cbtn12 == 0)
            {
                btn12.BackgroundColor = Color.Green;
                cbtn12 = 1;
                contador++;
            }
            else
            {
                btn12.BackgroundColor = Color.FromHex("#005eff");
                btn12.TextColor = Color.White;
                btn12.FontAttributes = FontAttributes.Bold; ;
                cbtn12 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn13_Clicked(object sender, EventArgs e)
        {
            if (cbtn13 == 0)
            {
                btn13.BackgroundColor = Color.Green;
                cbtn13 = 1;
                contador++;
            }
            else
            {
                btn13.BackgroundColor = Color.FromHex("#005eff");
                btn13.TextColor = Color.White;
                btn13.FontAttributes = FontAttributes.Bold;
                cbtn13 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn14_Clicked(object sender, EventArgs e)
        {
            if (cbtn14 == 0)
            {
                btn14.BackgroundColor = Color.Green;
                cbtn14 = 1;
                contador++;
            }
            else
            {
                btn14.BackgroundColor = Color.FromHex("#005eff");
                btn14.TextColor = Color.White;
                btn14.FontAttributes = FontAttributes.Bold;
                cbtn14 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn15_Clicked(object sender, EventArgs e)
        {
            if (cbtn15 == 0)
            {
                btn15.BackgroundColor = Color.Green;
                cbtn15 = 1;
                contador++;
            }
            else
            {
                btn15.BackgroundColor = Color.FromHex("#005eff");
                btn15.TextColor = Color.White;
                btn15.FontAttributes = FontAttributes.Bold;
                cbtn15 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn16_Clicked(object sender, EventArgs e)
        {
            if (cbtn16 == 0)
            {
                btn16.BackgroundColor = Color.Green;
                cbtn16 = 1;
                contador++;
            }
            else
            {
                btn16.BackgroundColor = Color.FromHex("#005eff");
                btn16.TextColor = Color.White;
                btn16.FontAttributes = FontAttributes.Bold;
                cbtn16 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn17_Clicked(object sender, EventArgs e)
        {
            if (cbtn17 == 0)
            {
                btn17.BackgroundColor = Color.Green;
                cbtn17 = 1;
                contador++;
            }
            else
            {
                btn17.BackgroundColor = Color.FromHex("#005eff");
                btn17.TextColor = Color.White;
                btn17.FontAttributes = FontAttributes.Bold;
                cbtn17 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn18_Clicked(object sender, EventArgs e)
        {
            if (cbtn18 == 0)
            {
                btn18.BackgroundColor = Color.Green;
                cbtn18 = 1;
                contador++;
            }
            else
            {
                btn18.BackgroundColor = Color.FromHex("#005eff");
                btn18.TextColor = Color.White;
                btn18.FontAttributes = FontAttributes.Bold;
                cbtn18 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn19_Clicked(object sender, EventArgs e)
        {
            if (cbtn19 == 0)
            {
                btn19.BackgroundColor = Color.Green;
                cbtn19 = 1;
                contador++;
            }
            else
            {
                btn19.BackgroundColor = Color.FromHex("#005eff");
                btn19.TextColor = Color.White;
                btn19.FontAttributes = FontAttributes.Bold;
                cbtn19 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn20_Clicked(object sender, EventArgs e)
        {
            if (cbtn20 == 0)
            {
                btn20.BackgroundColor = Color.Green;
                cbtn20 = 1;
                contador++;
            }
            else
            {
                btn20.BackgroundColor = Color.FromHex("#005eff");
                btn20.TextColor = Color.White;
                btn20.FontAttributes = FontAttributes.Bold;
                cbtn20 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn21_Clicked(object sender, EventArgs e)
        {
            if (cbtn21 == 0)
            {
                btn21.BackgroundColor = Color.Green;
                cbtn21 = 1;
                contador++;
            }
            else
            {
                btn21.BackgroundColor = Color.FromHex("#005eff");
                btn21.TextColor = Color.White;
                btn21.FontAttributes = FontAttributes.Bold;
                cbtn21 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn22_Clicked(object sender, EventArgs e)
        {
            if (cbtn22 == 0)
            {
                btn22.BackgroundColor = Color.Green;
                cbtn22 = 1;
                contador++;
            }
            else
            {
                btn22.BackgroundColor = Color.FromHex("#005eff");
                btn22.TextColor = Color.White;
                btn22.FontAttributes = FontAttributes.Bold;
                cbtn22 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn23_Clicked(object sender, EventArgs e)
        {
            if (cbtn23 == 0)
            {
                btn23.BackgroundColor = Color.Green;
                cbtn23 = 1;
                contador++;
            }
            else
            {
                btn23.BackgroundColor = Color.FromHex("#005eff");
                btn23.TextColor = Color.White;
                btn23.FontAttributes = FontAttributes.Bold;
                cbtn23 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn24_Clicked(object sender, EventArgs e)
        {
            if (cbtn24 == 0)
            {
                btn24.BackgroundColor = Color.Green;
                cbtn24 = 1;
                contador++;
            }
            else
            {
                btn24.BackgroundColor = Color.FromHex("#005eff");
                btn24.TextColor = Color.White;
                btn24.FontAttributes = FontAttributes.Bold;
                cbtn24 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn25_Clicked(object sender, EventArgs e)
        {
            if (cbtn25 == 0)
            {
                btn25.BackgroundColor = Color.Green;
                cbtn25 = 1;
                contador++;
            }
            else
            {
                btn25.BackgroundColor = Color.FromHex("#005eff");
                btn25.TextColor = Color.White;
                btn25.FontAttributes = FontAttributes.Bold;
                cbtn25 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn26_Clicked(object sender, EventArgs e)
        {
            if (cbtn26 == 0)
            {
                btn26.BackgroundColor = Color.Green;
                cbtn26 = 1;
                contador++;
            }
            else
            {
                btn26.BackgroundColor = Color.FromHex("#005eff");
                btn26.TextColor = Color.White;
                btn26.FontAttributes = FontAttributes.Bold;
                cbtn26 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn27_Clicked(object sender, EventArgs e)
        {
            if (cbtn27 == 0)
            {
                btn27.BackgroundColor = Color.Green;
                cbtn27 = 1;
                contador++;
            }
            else
            {
                btn27.BackgroundColor = Color.FromHex("#005eff");
                btn27.TextColor = Color.White;
                btn27.FontAttributes = FontAttributes.Bold;
                cbtn27 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn28_Clicked(object sender, EventArgs e)
        {
            if (cbtn28 == 0)
            {
                btn28.BackgroundColor = Color.Green;
                cbtn28 = 1;
                contador++;
            }
            else
            {
                btn28.BackgroundColor = Color.FromHex("#005eff");
                btn28.TextColor = Color.White;
                btn28.FontAttributes = FontAttributes.Bold;
                cbtn28 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn29_Clicked(object sender, EventArgs e)
        {
            if (cbtn29 == 0)
            {
                btn29.BackgroundColor = Color.Green;
                cbtn29 = 1;
                contador++;
            }
            else
            {
                btn29.BackgroundColor = Color.FromHex("#005eff");
                btn29.TextColor = Color.White;
                btn29.FontAttributes = FontAttributes.Bold;
                cbtn29 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn30_Clicked(object sender, EventArgs e)
        {
            if (cbtn30 == 0)
            {
                btn30.BackgroundColor = Color.Green;
                cbtn30 = 1;
                contador++;
            }
            else
            {
                btn30.BackgroundColor = Color.FromHex("#005eff");
                btn30.TextColor = Color.White;
                btn30.FontAttributes = FontAttributes.Bold;
                cbtn30 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn31_Clicked(object sender, EventArgs e)
        {
            if (cbtn31 == 0)
            {
                btn31.BackgroundColor = Color.Green;
                cbtn31 = 1;
                contador++;
            }
            else
            {
                btn31.BackgroundColor = Color.FromHex("#005eff");
                btn31.TextColor = Color.White;
                btn31.FontAttributes = FontAttributes.Bold;
                cbtn31 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn32_Clicked(object sender, EventArgs e)
        {
            if (cbtn32 == 0)
            {
                btn32.BackgroundColor = Color.Green;
                cbtn32 = 1;
                contador++;
            }
            else
            {
                btn32.BackgroundColor = Color.FromHex("#005eff");
                btn32.TextColor = Color.White;
                btn32.FontAttributes = FontAttributes.Bold;
                cbtn32 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn33_Clicked(object sender, EventArgs e)
        {
            if (cbtn33 == 0)
            {
                btn33.BackgroundColor = Color.Green;
                cbtn33 = 1;
                contador++;
            }
            else
            {
                btn33.BackgroundColor = Color.FromHex("#005eff");
                btn33.TextColor = Color.White;
                btn33.FontAttributes = FontAttributes.Bold;
                cbtn33 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn34_Clicked(object sender, EventArgs e)
        {
            if (cbtn34 == 0)
            {
                btn34.BackgroundColor = Color.Green;
                cbtn34 = 1;
                contador++;
            }
            else
            {
                btn34.BackgroundColor = Color.FromHex("#005eff");
                btn34.TextColor = Color.White;
                btn34.FontAttributes = FontAttributes.Bold;
                cbtn34 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn35_Clicked(object sender, EventArgs e)
        {
            if (cbtn35 == 0)
            {
                btn35.BackgroundColor = Color.Green;
                cbtn35 = 1;
                contador++;
            }
            else
            {
                btn35.BackgroundColor = Color.FromHex("#005eff");
                btn35.TextColor = Color.White;
                btn35.FontAttributes = FontAttributes.Bold;
                cbtn35 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn36_Clicked(object sender, EventArgs e)
        {
            if (cbtn36 == 0)
            {
                btn36.BackgroundColor = Color.Green;
                cbtn36 = 1;
                contador++;
            }
            else
            {
                btn36.BackgroundColor = Color.FromHex("#005eff");
                btn36.TextColor = Color.White;
                btn36.FontAttributes = FontAttributes.Bold;
                cbtn36 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn37_Clicked(object sender, EventArgs e)
        {
            if (cbtn37 == 0)
            {
                btn37.BackgroundColor = Color.Green;
                cbtn37 = 1;
                contador++;
            }
            else
            {
                btn37.BackgroundColor = Color.FromHex("#005eff");
                btn37.TextColor = Color.White;
                btn37.FontAttributes = FontAttributes.Bold;
                cbtn37 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn38_Clicked(object sender, EventArgs e)
        {
            if (cbtn38 == 0)
            {
                btn38.BackgroundColor = Color.Green;
                cbtn38 = 1;
                contador++;
            }
            else
            {
                btn38.BackgroundColor = Color.FromHex("#005eff");
                btn38.TextColor = Color.White;
                btn38.FontAttributes = FontAttributes.Bold;
                cbtn38 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn39_Clicked(object sender, EventArgs e)
        {
            if (cbtn39 == 0)
            {
                btn39.BackgroundColor = Color.Green;
                cbtn39 = 1;
                contador++;
            }
            else
            {
                btn39.BackgroundColor = Color.FromHex("#005eff");
                btn39.TextColor = Color.White;
                btn39.FontAttributes = FontAttributes.Bold;
                cbtn39 = 0;
                contador--;
            }
            contadorF();
        }

        private void btn40_Clicked(object sender, EventArgs e)
        {
            if (cbtn40 == 0)
            {
                btn40.BackgroundColor = Color.Green;
                cbtn40 = 1;
                contador++;
            }
            else
            {
                btn40.BackgroundColor = Color.FromHex("#005eff");
                btn40.TextColor = Color.White;
                btn40.FontAttributes = FontAttributes.Bold;
                cbtn40 = 0;
                contador--;
            }
            contadorF();
        }

        void contadorF()
        {
            lblCantidad.Text = "Asientos Seleccionados: " + contador;
            lbltotalsillas.Text = "Total: " + (contador * Convert.ToInt32(lblPrecios.Text));
        }


        async void consulta_oupadas()
        {

      
            using (WebClient wc = new WebClient())
            {
                string idc = id__;
                string hora = hora__;

                if (hora__.Contains("15:00"))
                {
                    hora = "1";
                }
                else if (hora__.Contains("17:00"))
                {
                    hora = "2";
                }
                else if (hora__.Contains("19:00"))
                {
                    hora = "3";
                }

                var resp = "";
                

                var parametros =  "id=" + idc + "&hora=" + hora;



                var direc = new ruta();
                String direccion = direc.ruta_();
                direccion = direccion + "/ocupadas";

                Console.WriteLine(parametros.ToString());

                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                string HtmlResult = wc.UploadString(direccion, "POST", parametros);
                

                resp = HtmlResult;
                string s = HtmlResult;
                for (int i = 0; i < 41; i++)
                {
                    // _ = i;
                    string este = Convert.ToString("\"" + i + "\"");
                    bool valor = s.Contains(este);
                    Console.WriteLine(Convert.ToString("Convertido " + HtmlResult + " sillitas"));
                   Console.WriteLine("Aca Esta " + este);
                        
                    if (Convert.ToString(i) == "1" && (valor == true))
                        {
                        btn1.IsEnabled = false;
                        btn1.BackgroundColor = Color.LightGray;
                        btn1.TextColor = Color.Black;
                        btn1.BorderColor = Color.DarkGray;
                    }

                   else if (Convert.ToString(i) == "2" && (valor == true))
                    {
                        btn2.IsEnabled = false;
                        btn2.BackgroundColor = Color.LightGray;
                        btn2.TextColor = Color.Black;
                        btn2.BorderColor = Color.DarkGray;
                    }
                    else if (Convert.ToString(i) == "3" && (valor == true))
                    {
                        btn3.IsEnabled = false;
                        btn3.BackgroundColor = Color.LightGray;
                        btn3.TextColor = Color.Black;
                        btn3.BorderColor = Color.DarkGray;
                    }
                    else if (Convert.ToString(i) == "4" && (valor == true))
                    {
                        btn4.IsEnabled = false;
                        btn4.BackgroundColor = Color.LightGray;
                        btn4.TextColor = Color.Black;
                        btn4.BorderColor = Color.DarkGray;
                    }
                    else if (Convert.ToString(i) == "5" && (valor == true))
                    {
                        btn5.IsEnabled = false;
                        btn5.BackgroundColor = Color.LightGray;
                        btn5.TextColor = Color.Black;
                        btn5.BorderColor = Color.DarkGray;
                    }
                    else if (Convert.ToString(i) == "6" && (valor == true))
                    {
                        btn6.IsEnabled = false;
                        btn6.BackgroundColor = Color.LightGray;
                        btn6.TextColor = Color.Black;
                        btn6.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "7" && (valor == true))
                    {
                        btn7.IsEnabled = false;
                        btn7.BackgroundColor = Color.LightGray;
                        btn7.TextColor = Color.Black;
                        btn7.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "8" && (valor == true))
                    {
                        btn8.IsEnabled = false;
                        btn8.BackgroundColor = Color.LightGray;
                        btn8.TextColor = Color.Black;
                        btn8.BorderColor = Color.DarkGray;
                    }
                    else if (Convert.ToString(i) == "9" && (valor == true))
                    {
                        btn9.IsEnabled = false;
                        btn9.BackgroundColor = Color.LightGray;
                        btn9.TextColor = Color.Black;
                        btn9.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "10" && (valor == true))
                    {
                        btn10.IsEnabled = false;
                        btn10.BackgroundColor = Color.LightGray;
                        btn10.TextColor = Color.Black;
                        btn10.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "11" && (valor == true))
                    {
                        btn11.IsEnabled = false;
                        btn11.BackgroundColor = Color.LightGray;
                        btn11.TextColor = Color.Black;
                        btn11.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "12" && (valor == true))
                    {
                        btn12.IsEnabled = false;
                        btn12.BackgroundColor = Color.LightGray;
                        btn12.TextColor = Color.Black;
                        btn12.BorderColor = Color.DarkGray;
                    }
                    else if (Convert.ToString(i) == "13" && (valor == true))
                    {
                        btn13.IsEnabled = false;
                        btn13.BackgroundColor = Color.LightGray;
                        btn13.TextColor = Color.Black;
                        btn13.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "14" && (valor == true))
                    {
                        btn14.IsEnabled = false;
                        btn14.BackgroundColor = Color.LightGray;
                        btn14.TextColor = Color.Black;
                        btn14.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "15" && (valor == true))
                    {
                        btn15.IsEnabled = false;
                        btn15.BackgroundColor = Color.LightGray;
                        btn15.TextColor = Color.Black;
                        btn15.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "16" && (valor == true))
                    {
                        btn16.IsEnabled = false;
                        btn16.BackgroundColor = Color.LightGray;
                        btn16.TextColor = Color.Black;
                        btn16.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "17" && (valor == true))
                    {
                        btn17.IsEnabled = false;
                        btn17.BackgroundColor = Color.LightGray;
                        btn17.TextColor = Color.Black;
                        btn17.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "18" && (valor == true))
                    {
                        btn18.IsEnabled = false;
                        btn18.BackgroundColor = Color.LightGray;
                        btn18.TextColor = Color.Black;
                        btn18.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "19" && (valor == true))
                    {
                        btn19.IsEnabled = false;
                        btn19.BackgroundColor = Color.LightGray;
                        btn19.TextColor = Color.Black;
                        btn19.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "20" && (valor == true))
                    {
                        btn20.IsEnabled = false;
                        btn20.BackgroundColor = Color.LightGray;
                        btn20.TextColor = Color.Black;
                        btn20.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "21" && (valor == true))
                    {
                        btn21.IsEnabled = false;
                        btn21.BackgroundColor = Color.LightGray;
                        btn21.TextColor = Color.Black;
                        btn21.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "22" && (valor == true))
                    {
                        btn22.IsEnabled = false;
                        btn22.BackgroundColor = Color.LightGray;
                        btn22.TextColor = Color.Black;
                        btn22.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "23" && (valor == true))
                    {
                        btn23.IsEnabled = false;
                        btn23.BackgroundColor = Color.LightGray;
                        btn23.TextColor = Color.Black;
                        btn23.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "24" && (valor == true))
                    {
                        btn24.IsEnabled = false;
                        btn24.BackgroundColor = Color.LightGray;
                        btn24.TextColor = Color.Black;
                        btn24.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "25" && (valor == true))
                    {
                        btn25.IsEnabled = false;
                        btn25.BackgroundColor = Color.LightGray;
                        btn25.TextColor = Color.Black;
                        btn25.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "26" && (valor == true))
                    {
                        btn26.IsEnabled = false;
                        btn26.BackgroundColor = Color.LightGray;
                        btn26.TextColor = Color.Black;
                        btn26.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "27" && (valor == true))
                    {
                        btn27.IsEnabled = false;
                        btn27.BackgroundColor = Color.LightGray;
                        btn27.TextColor = Color.Black;
                        btn27.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "28" && (valor == true))
                    {
                        btn28.IsEnabled = false;
                        btn28.BackgroundColor = Color.LightGray;
                        btn28.TextColor = Color.Black;
                        btn28.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "29" && (valor == true))
                    {
                        btn29.IsEnabled = false;
                        btn29.BackgroundColor = Color.LightGray;
                        btn29.TextColor = Color.Black;
                        btn29.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "30" && (valor == true))
                    {
                        btn30.IsEnabled = false;
                        btn30.BackgroundColor = Color.LightGray;
                        btn30.TextColor = Color.Black;
                        btn30.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "31" && (valor == true))
                    {
                        btn31.IsEnabled = false;
                        btn31.BackgroundColor = Color.LightGray;
                        btn31.TextColor = Color.Black;
                        btn31.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "32" && (valor == true))
                    {
                        btn32.IsEnabled = false;
                        btn32.BackgroundColor = Color.LightGray;
                        btn32.TextColor = Color.Black;
                        btn32.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "33" && (valor == true))
                    {
                        btn33.IsEnabled = false;
                        btn33.BackgroundColor = Color.LightGray;
                        btn33.TextColor = Color.Black;
                        btn33.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "34" && (valor == true))
                    {
                        btn34.IsEnabled = false;
                        btn34.BackgroundColor = Color.LightGray;
                        btn34.TextColor = Color.Black;
                        btn34.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "35" && (valor == true))
                    {
                        btn35.IsEnabled = false;
                        btn35.BackgroundColor = Color.LightGray;
                        btn35.TextColor = Color.Black;
                        btn35.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "36" && (valor == true))
                    {
                        btn36.IsEnabled = false;
                        btn36.BackgroundColor = Color.LightGray;
                        btn36.TextColor = Color.Black;
                        btn36.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "37" && (valor == true))
                    {
                        btn37.IsEnabled = false;
                        btn37.BackgroundColor = Color.LightGray;
                        btn37.TextColor = Color.Black;
                        btn37.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "38" && (valor == true))
                    {
                        btn38.IsEnabled = false;
                        btn38.BackgroundColor = Color.LightGray;
                        btn38.TextColor = Color.Black;
                        btn38.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "39" && (valor == true))
                    {
                        btn39.IsEnabled = false;
                        btn39.BackgroundColor = Color.LightGray;
                        btn39.TextColor = Color.Black;
                        btn39.BorderColor = Color.DarkGray;
                    }

                    else if (Convert.ToString(i) == "40" && (valor == true))
                    {
                        btn40.IsEnabled = false;
                        btn40.BackgroundColor = Color.LightGray;
                        btn40.TextColor = Color.Black;
                        btn40.BorderColor = Color.DarkGray;
                    }

                


                }
                // int location = s.IndexOf("13"); // location = 1
                
                Console.WriteLine("Lista " + HtmlResult);

            }
        }

      





        async private void btnContinuar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (contador == 0)
                {
                    await DisplayAlert("Alerta", "No Tiene asientos Seleccionados", "ok");
                }
                else
                {
                                       
                    int[] a; 
                    arreglo = "";
                   
                    a = new int[40];
                    a[0] = cbtn1;
                    a[1] = cbtn2;
                    a[2] = cbtn3;
                    a[3] = cbtn4;
                    a[4] = cbtn5;
                    a[5] = cbtn6;
                    a[6] = cbtn7;
                    a[7] = cbtn8;
                    a[8] = cbtn9;
                    a[9] = cbtn10;
                    a[10] = cbtn11;
                    a[11] = cbtn12;
                    a[12] = cbtn13;
                    a[13] = cbtn14;
                    a[14] = cbtn15;
                    a[15] = cbtn16;
                    a[16] = cbtn17;
                    a[17] = cbtn18;
                    a[18] = cbtn19;
                    a[19] = cbtn20;
                    a[20] = cbtn21;
                    a[21] = cbtn22;
                    a[22] = cbtn23;
                    a[23] = cbtn24;
                    a[24] = cbtn25;
                    a[25] = cbtn26;
                    a[26] = cbtn27;
                    a[27] = cbtn28;
                    a[28] = cbtn29;
                    a[29] = cbtn30;
                    a[30] = cbtn31;
                    a[31] = cbtn32;
                    a[32] = cbtn33;
                    a[33] = cbtn34;
                    a[34] = cbtn35;
                    a[35] = cbtn36;
                    a[36] = cbtn37;
                    a[37] = cbtn38;
                    a[38] = cbtn39;
                    a[39] = cbtn40;

                    for (int i = 0; i < 40; i++)
                    {
                        if (a[i] == 1)
                        {
                            a[i] = i + 1;
                            if (i > 1)
                            {
                                arreglo = arreglo + ",\"" + a[i] + "\"";
                            }
                            else
                            {
                                arreglo = arreglo + "\"" + a[i] + "\"";
                            }
                         
                        }
                    }
                   Console.WriteLine("Sillas " + arreglo.ToString());
                    var pagina = new pagarEntrada(id__, nombre__, synopsis__, anio__, clasificacion__, genero__, director__, duracion__, video__, banner__, hora__, a,Fechas__, FechaVerPelicula);
                    await Navigation.PushAsync(pagina);
                }

            }
            catch (Exception ex) { }
        }


        async private void btnAtras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}