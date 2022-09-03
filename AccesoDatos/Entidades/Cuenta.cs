using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class Cuenta: Entidad
    {
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public decimal Saldo { get; set; }
        public string Estado { get; set; }

        public Cliente Cliente { get; set; }
        public List<Movimiento> Movimientos { get; set; }
    }
}
