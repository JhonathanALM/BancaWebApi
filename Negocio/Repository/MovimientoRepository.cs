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
using System.Threading;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class MovimientoRepository : GeneralRepository<Movimiento>, IMovimientoRepository
    {
        public MovimientoRepository(ContextoBD context) : base(context)
        {
        }

        public override async Task<Response<string>> Create(Movimiento mov)
        {
            Response<string> response = new();
            try
            {
                var valorMonetario = Math.Abs(mov.Monto);
                var cuenta = _context.Cuentas.FirstOrDefault(x => x.Id == mov.Cuenta.Id);
                if (cuenta != null)
                {
                    mov.Saldo = cuenta.Saldo;
                    mov.Fecha = DateTime.Now;
                    var movimientosCuenta = await _dbSet
                    .Include(ac => ac.Cuenta)
                    .ToListAsync();

                    decimal acumulado = 0;
                   
                    foreach (var item in movimientosCuenta.Where(x => x.Cuenta.Id == mov.Cuenta.Id && mov.Tipo.Equals(General.Debito) && x.Tipo.Equals(General.Debito) && (DateTime.Now - x.Fecha).Days <= 1 ))
                    {
                        acumulado += item.Monto;
                    }
                    if (acumulado >= General.MontoMaximo)
                    {
                        throw new Exception(General.ValorDiarioExcedido);
                    }
                    if (valorMonetario>mov.Saldo&& mov.Tipo.Equals(General.Debito))
                        throw new Exception(General.SaldoInsuficiente);
                    if (mov.Tipo.Equals(General.Debito))
                        valorMonetario = valorMonetario * -1;
                    cuenta.Saldo = cuenta.Saldo + valorMonetario;
                    mov.Saldo = cuenta.Saldo;
                    mov.Cuenta = cuenta;
                    await _dbSet.AddAsync(mov);
                    await _context.SaveChangesAsync();
                    response.Data = String.Empty;
                    response.Respuesta = HttpStatusCode.Created.ToString();
                }
                else
                {
                    throw new Exception(General.Cuenta404);
                }
            }
            catch (Exception e)
            {
                response.Respuesta = e.ToString();
            }
            return response;
        }
    }
}
