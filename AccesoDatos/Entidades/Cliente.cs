using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class Cliente:Persona
    {
        public string Clave { get; set; }
        public string Estado { get; set; }
        public List<Cuenta> Cuentas { get; set; }
    }
}
