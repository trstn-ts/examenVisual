using ExamenAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ExamenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly BdRegistrosContext _baseDatos;
        public RegistrosController(BdRegistrosContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        // GET: api/Registros
        [HttpGet]
        [Route("ListaRegistros")]
        public async Task<IActionResult> Lista()
        {
            var listaRegistros = await _baseDatos.Registros.ToListAsync();            
            return Ok(listaRegistros);
        }
        
        // GET: api/Registros/FiltrarPorGenero/{genero}
        [HttpGet]
        [Route("FiltrarPorGenero/{genero}")]
        public async Task<IActionResult> FiltrarPorGenero(string genero)
        {
            if (string.IsNullOrWhiteSpace(genero))
            {
                return BadRequest("El parámetro 'genero' no puede estar vacío.");
            }

            var registrosFiltrados = await _baseDatos.Registros
                .Where(r => r.Genero.ToLower() == genero.ToLower())
                .ToListAsync();

            return Ok(registrosFiltrados);
        }

        // GET: api/Registros/FiltrarPorTitulo/{titulo}
        [HttpGet]
        [Route("FiltrarPorTitulo/{titulo}")]
        public async Task<IActionResult> FiltrarPorTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                return BadRequest("El parámetro 'titulo' no puede estar vacío.");
            }

            var registrosFiltrados = await _baseDatos.Registros
                .Where(r => r.Titulo.ToLower().Contains(titulo.ToLower()))
                .ToListAsync();

            return Ok(registrosFiltrados);
        }
    }
}
