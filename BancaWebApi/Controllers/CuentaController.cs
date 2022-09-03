using AccesoDatos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio.IRepository;
using Negocio.Repository;

namespace BancaWebApi.Controllers
{
    [Route("api/cuentas")]
    [ApiController]
    public class CuentaController : Controller
    {
        private readonly ICuentaRepository _cuentaRepository;
        public CuentaController(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _cuentaRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await _cuentaRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                var result = await _cuentaRepository.Create(cuenta);
                return Ok(result);
            }
            return BadRequest(ModelState.ValidationState);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                var result = await _cuentaRepository.Update(cuenta);
                return Ok(result);
            }
            return BadRequest(ModelState.ValidationState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cuentaRepository.DeleteById(id);
            return Ok(result);
        }
    }
}
