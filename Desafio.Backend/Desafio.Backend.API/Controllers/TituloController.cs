using Desafio.Backend.Domain;
using Desafio.Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TituloController : ControllerBase
    {
        private readonly ITituloService _tituloService;
        public TituloController(ITituloService tituloService)
        {
            _tituloService = tituloService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Titulo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Titulo>> ObterTitulos()
        {
            try
            {
                var titulos = _tituloService.ObterTitulos();

                if (titulos == null || !titulos.Any())
                    return NoContent();

                return Ok(titulos);
            }
            catch (Exception ex)
            {     
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Titulo), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Titulo> CadastrarTitulo([FromBody] Titulo titulo)
        {
            try
            {
                if (titulo == null)
                    return BadRequest("Título inválido");

                _tituloService.AdicionarTitulo(titulo);

                return CreatedAtAction(nameof(ObterTitulos), new { numero = titulo.Numero }, titulo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }
    }
}
