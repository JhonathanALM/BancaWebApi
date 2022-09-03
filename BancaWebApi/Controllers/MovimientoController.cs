using AccesoDatos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio.IRepository;
using Negocio.Repository;

namespace BancaWebApi.Controllers
{
    [Route("api/movimientos")]
    [ApiController]
    public class MovimientoController : Controller
    {
        private readonly IMovimientoRepository _movimientoRepository;
        public MovimientoController(IMovimientoRepository movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _movimientoRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await _movimientoRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                var result = await _movimientoRepository.Create(movimiento);
                return Ok(result);
            }
            return BadRequest(ModelState.ValidationState);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                var result = await _movimientoRepository.Update(movimiento);
                return Ok(result);
            }
            return BadRequest(ModelState.ValidationState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movimientoRepository.DeleteById(id);
            return Ok(result);
        }

    }
}
