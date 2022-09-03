using AccesoDatos.Entidades;
using Modelo.Transaccion.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepository
{
    public interface IClienteRepository : IGeneralRepository<Cliente>
    {
        Task<Response<List<DetalleMovimientoResponse>>> Reporte(int id, DateTime inicio, DateTime fin);
    }
}
