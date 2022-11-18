using ActividadScaffold.DTOs;
using ActividadScaffold.Entities;
using ActividadScaffold.utils;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActividadScaffold.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SancionController : ControllerBase
    {
        #region Propiedades
        private readonly ACT01Context _context;
        SancionesValidator validator = new SancionesValidator();
        SancionesValidator2 validator2 = new SancionesValidator2();
        #endregion

        #region Constructor
        public SancionController(ACT01Context context)
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
        public async Task<ActionResult<IEnumerable<SancionesDTO>>> Get()
        {
            var sanciones = await _context.Sanciones
                .Select(s => new SancionesDTO
                {
                    Sancion = s.Sancion,
                    Valor = s.Valor
                }).ToListAsync();

            if (sanciones != null) { return Ok(sanciones); }
            else { return NotFound(); }
        }



        // GET api/<MatriculaController>/5
        /// <summary>
        /// <method="GetById"></method>
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Sancione>> Get(int id)
        {
            var sanciones = await _context.Sanciones.FindAsync(id);

            if (sanciones != null) { return Ok(sanciones); }
            else { return NotFound(); }
        }



        // POST api/<MatriculaController>
        /// <summary>
        /// <method="Post"></method>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //public async Task<HttpStatusCode> Post(Conductor conductor)
        public async Task<HttpStatusCode> Post(SancionesDTO sanciones)
        {
            try
            {
                ValidationResult result = validator.Validate(sanciones);

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
                else
                {
                    var entity = new Sancione()
                    {
                        Sancion = sanciones.Sancion,
                        Valor = sanciones.Valor
                    };

                    _context.Sanciones.Add(entity);
                    await _context.SaveChangesAsync();
                    return HttpStatusCode.Created;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return HttpStatusCode.UnprocessableEntity;
        }



        // PUT api/<MatriculaController>/5
        /// <summary>
        /// <method="Put"></method>
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(Sancione sanciones)
        {
            try
            {
                ValidationResult result = validator2.Validate(sanciones);

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
                else
                {
                    _context.Entry(sanciones).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return HttpStatusCode.Accepted;
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
            var entity = await _context.Sanciones.FindAsync(id);

            _context.Sanciones.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion
    }
}
