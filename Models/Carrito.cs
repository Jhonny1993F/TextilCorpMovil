using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextilCorpMovil.Models
{
    public class Carrito
    {
        public int carritoId { get; set; }
        public string cantidad { get; set; }
        public string clientesId { get; set; }
        public string productosId { get; set; }
        public object clientes { get; set; }
        public object productos { get; set; }
    }
}
