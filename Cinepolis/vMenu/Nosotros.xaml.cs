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
    public partial class Nosotros : ContentPage
    {
        public Nosotros()
        {
            InitializeComponent();
            string txt = "Xinépolis es una aplicación movil desarrollada por estudiantes de la carrera de ingenieria en computacion con el fin de ofrecer a los clientes una experiencia agradable y dandoles la facilidad de llevar la cartelara del cine a sus manos. " +
                "\nDesarrollada en lenguaje C# en entorno de desarrollo de aplicaciones moviles para Xamarin Android, del paquete de Visual Estudio 2019, con conexion a una base de datos firebase. \n" +
                "Las API desarrolladas con lenguaje de Visual Studio Code, apoyada con las potentes herramientas de comunicacion Firebase, provee a los usuarios la facilidad de consultar la cartelera cinematografica desde su celular. \n" +
                "Brindando los estrenos del cine, asi como los Trailers de sus peliculas favoritas con la opcion de reservar sus asientos y Golosinas desde su celular para evitar contratiempos y filas. \n" +
                "Para que tú te preocupes de solo disfrutar tu pelicula.";
            lblTexto.Text = txt;

           
        }
    }
}