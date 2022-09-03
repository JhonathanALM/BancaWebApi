using Modelo.Transaccion.Response;
namespace Negocio.IRepository
{
    public interface IGeneralRepository <T> where T : class
    {
        Task<Response<List<T>>> GetAll();
        Task<Response<T>> GetById(int id);
        Task<Response<string>> Create(T dto);
        Task<Response<string>> Update(T dto);
        Task<Response<string>> DeleteById(int id);
    }
}
