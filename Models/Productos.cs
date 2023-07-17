using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextilCorpMovil.Models
{
    public class Productos
    {
        public int productosId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int cantidad { get; set; }
        public bool stock { get; set; }
        public string imagen { get; set; }
        public int marcasId { get; set; }
        public int categoriasId { get; set; }
        public object[] carritos { get; set; }
        public object categorias { get; set; }
        public object marcas { get; set; }
        public object[] venta { get; set; }
    }
}
