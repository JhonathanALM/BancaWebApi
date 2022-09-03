using AccesoDatos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Negocio.IRepository;
using System.ComponentModel.DataAnnotations;

namespace BancaWebApi.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clienteRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var result = await _clienteRepository.Create(cliente);
                return Ok(result);
            }
            return BadRequest(ModelState.ValidationState);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var result = await _clienteRepository.Update(cliente);
                return Ok(result);
            }
            return BadRequest(ModelState.ValidationState);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await _clienteRepository.GetById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clienteRepository.DeleteById(id);
            return Ok(result);
        }

        [HttpGet("reportes/{id}")]
        public async Task<IActionResult> Reporte(int id, [Required] DateTime inicio, [BindRequired] DateTime fin)
        {
            var result = await _clienteRepository.Reporte(id, inicio, fin);
            return Ok(result);
        }

    }
}
