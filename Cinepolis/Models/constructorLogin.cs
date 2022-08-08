using SQLite;
namespace Cinepolis.Models
{
    public class constructorLogin
    {
        [PrimaryKey]
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string nombre_completo { get; set; }
        public string correo { get; set; }


        public string apellidos { get; set; }
        public string tarjeta { get; set; }
        public string ubicacion { get; set; }
        public string proveedor { get; set; }
        public string clave { get; set; }
        public string fecha_tarjeta { get; set; }
        public string cod_seguridad { get; set; }
    }
}
