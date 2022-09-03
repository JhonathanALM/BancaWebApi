using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Transaccion.Response
{
    public class Response <T>
    {
        public T Data { get; set; }

        public string Respuesta { get; set; }
    }
}
