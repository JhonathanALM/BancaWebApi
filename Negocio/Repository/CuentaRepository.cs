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
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public class CuentaRepository : GeneralRepository<Cuenta>, ICuentaRepository
    {
        public CuentaRepository(ContextoBD context) : base(context)
        {
        }

        public override async Task<Response<List<Cuenta>>> GetAll()
        {
            Response<List<Cuenta>> response = new();
            try
            {
                var result = await _dbSet
                    .Include(c => c.Cliente)
                    .Include(mv => mv.Movimientos)
                    .ToListAsync();

                response.Data = result;
            }
            catch (Exception e)
            {
                response.Respuesta = e.ToString();
            }
            return response;
        }

        public override async Task<Response<string>> Create(Cuenta cta)
        {
            Response<string> response = new();
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(x => x.Id == cta.Cliente.Id);
                if (cliente != null)
                {
                    cta.Cliente = cliente;
                    await _dbSet.AddAsync(cta);
                    await _context.SaveChangesAsync();
                    response.Data = String.Empty;
                    response.Respuesta = HttpStatusCode.Created.ToString();
                }
                else
                {
                    throw new Exception(General.Cliente404);
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
