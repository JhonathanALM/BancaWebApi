using AccesoDatos.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Modelo.Transaccion.Response;
using Negocio.IRepository;
using System.Net;

namespace Negocio.Repository
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        protected ContextoBD _context;
        protected DbSet<T> _dbSet;

        public GeneralRepository(ContextoBD context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<Response<List<T>>> GetAll()
        {
            Response<List<T>> response = new();
            try
            {
                var result = await _dbSet.ToListAsync();
                response.Data = result;
                response.Respuesta = HttpStatusCode.OK.ToString();
            }
            catch (Exception e)
            {
                response.Respuesta = e.ToString();
            }
            return response;
        }

        public async Task<Response<T>> GetById(int id)
        {
            Response<T> response = new();
            try
            {
                var result = await _dbSet.FindAsync(id);
                response.Data = result;
                response.Respuesta = HttpStatusCode.OK.ToString();
            }
            catch (Exception e)
            {
                response.Respuesta = e.ToString();
            }
            return response;
        }

        public virtual async Task<Response<string>> Create(T dto)
        {
            Response<string> response = new();
            try
            {
                await _dbSet.AddAsync(dto);
                await _context.SaveChangesAsync();
                response.Data = String.Empty;
                response.Respuesta = HttpStatusCode.Created.ToString();
            }
            catch (Exception e)
            {
                response.Respuesta = e.ToString();
            }
            return response;
        }

        public async Task<Response<string>> Update(T dto)
        {
            Response<string> response = new();
            try
            {
                _dbSet.Update(dto);
                await _context.SaveChangesAsync();
                response.Data = null;
                response.Respuesta = HttpStatusCode.OK.ToString();
            }
            catch (Exception e)
            {
                response.Respuesta = e.ToString();
            }
            return response;
        }

        public async Task<Response<string>> DeleteById(int id)
        {
            Response<string> response = new();
            try
            {
                var result = await _dbSet.FindAsync(id);
                _dbSet.Remove(result);
                await _context.SaveChangesAsync();
                response.Data = null;
                response.Respuesta = HttpStatusCode.OK.ToString();

            }
            catch (Exception e)
            {
                response.Respuesta = e.ToString();
            }
            return response;
        }
    }
}
