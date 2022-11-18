using ActividadScaffold.DTOs;
using ActividadScaffold.Entities;
using ActividadScaffold.utils;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ActividadScaffold.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        #region Propiedades
        private readonly ACT01Context _context;
        MatriculaValidator validator = new MatriculaValidator();
        #endregion

        #region Constructor
        public MatriculaController(ACT01Context context)
        {
            _context = context;
        }
        #endregion

        #region Métodos
        // GET: api/<MatriculaController>
        /// <summary>
        /// <method="Get"></method>
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// <method="GetById"></method>
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Matricula>> Get(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);

            if (matricula != null) { return Ok(matricula); }
            else { return NotFound(); }
        }



        // POST api/<MatriculaController>
        /// <summary>
        /// <method="Post"></method>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpStatusCode> Post(Matricula matricula)
        {
            try
            {
                ValidationResult result = validator.Validate(matricula);

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
                else
                {
                    _context.Matriculas.Add(matricula);
                    await _context.SaveChangesAsync();
                    return HttpStatusCode.Created;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.UnprocessableEntity;
        }



        // PUT api/<MatriculaController>/5
        /// <summary>
        /// <method="Put"></method>
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(Matricula matricula)
        {
            try
            {
                ValidationResult result = validator.Validate(matricula);

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
                else
                {
                    _context.Entry(matricula).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return HttpStatusCode.OK;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NotModified;
        }



        // DELETE api/<MatriculaController>/5
        /// <summary>
        /// <method="Delete"></method>
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var entity = await _context.Matriculas.FindAsync(id);

            _context.Matriculas.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion
    }
}
