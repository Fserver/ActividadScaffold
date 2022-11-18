using ActividadScaffold.DTOs;
using ActividadScaffold.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActividadScaffold.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly ACT01Context _context;

        public MatriculaController(ACT01Context context)
        {
            _context = context;
        }



        // GET: api/<MatriculaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaDTO>>> Get()
        {
            var matriculas = await _context.Matriculas
                .Select(m => new MatriculaDTO
                {
                    Numero = m.Numero,
                    FechaExpedicion = m.FechaExpedicion,
                    ValidaHasta = m.ValidaHasta,
                    Activo = m.Activo
                }).ToListAsync();

            if (matriculas != null) { return Ok(matriculas); }
            else { return NotFound(); }
        }



        // GET api/<MatriculaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matricula>> Get(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);

            if (matricula != null) { return Ok(matricula); }
            else { return NotFound(); }
        }



        // POST api/<MatriculaController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(Matricula matricula)
        {
            try
            {
                _context.Matriculas.Add(matricula);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;
        }



        // PUT api/<MatriculaController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(Matricula matricula)
        {
            try
            {
                _context.Entry(matricula).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;
        }



        // DELETE api/<MatriculaController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var entity = await _context.Matriculas.FindAsync(id);

            _context.Matriculas.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
