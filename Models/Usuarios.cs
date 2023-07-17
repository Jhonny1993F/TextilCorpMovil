using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextilCorpMovil.Models
{
    public class Usuarios
    {
        public int usuariosId { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
    }
}
