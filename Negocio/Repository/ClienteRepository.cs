using AccesoDatos.Contexto;
using AccesoDatos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Modelo.Constantes;
using Modelo.Transaccion.Response;
using Negocio.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class ClienteRepository : GeneralRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ContextoBD context) : base(context)
        {

        }
        public async Task<Response<List<DetalleMovimientoResponse>>> Reporte(int id, DateTime inicio, DateTime fin)
        {
            Response<List<DetalleMovimientoResponse>> response = new();
            try
            {
                var result = await _dbSet
                   .Include(ac => ac.Cuentas)
                   .ThenInclude(mv => mv.Movimientos)
                   .FirstOrDefaultAsync(x => x.Id == id);

                if (result != null)
                {
                    List<DetalleMovimientoResponse> movimientos = new();
                    DetalleMovimientoResponse movimiento = new();
                    foreach (var cuenta in result.Cuentas)
                    {
                        foreach (var mov in cuenta.Movimientos.Where(x => x.Fecha >= inicio && x.Fecha <= fin))
                        {
                            var valorMonetario = Math.Abs(mov.Monto);
                            if (mov.Tipo.Equals(General.Debito))
                                valorMonetario = valorMonetario * -1;
                            movimiento = new();
                            movimiento.Fecha = mov.Fecha;
                            movimiento.Cliente = cuenta.Cliente.Nombre;
                            movimiento.NumeroCuenta = cuenta.Numero;
                            movimiento.Tipo = mov.Tipo;
                            movimiento.SaldoInicial = mov.Saldo - valorMonetario;
                            movimiento.Estado = cuenta.Estado;                           
                            movimiento.Movimiento = valorMonetario;
                            movimiento.SaldoDisponible = mov.Saldo;
                            movimientos.Add(movimiento);
                        }
                    }
                    response.Data = movimientos;
                    response.Respuesta = HttpStatusCode.Created.ToString();
                }
                else
                {
                      throw new Exception(General.Cliente404);
                }
            }
            catch (Exception e)
            {
                response.Respuesta = e.Message;
            }
            return response;
        }
    }
}
