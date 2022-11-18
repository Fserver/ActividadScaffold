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
    public class ConductorController : ControllerBase
    {
        #region Propiedades
        private readonly ACT01Context _context;
        ConductorValidator validator = new ConductorValidator();
        ConductorValidator2 validator2 = new ConductorValidator2();
        #endregion

        #region Constructor
        public ConductorController(ACT01Context context)
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
        public async Task<ActionResult<IEnumerable<ConductorDTO>>> Get()
        {
            var conductores = await _context.Conductors
                .Select(c => new ConductorDTO
                {
                    Identificacion = c.Identificacion,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Telefono = c.Telefono,
                    Email = c.Email,
                    Activo = c.Activo,
                    MatriculaId = c.MatriculaId
                }).ToListAsync();

            if (conductores != null) { return Ok(conductores); }
            else { return NotFound(); }
        }



        // GET api/<MatriculaController>/5
        /// <summary>
        /// <method="GetById"></method>
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Conductor>> Get(int id)
        {
            var conductor = await _context.Conductors.FindAsync(id);

            if (conductor != null) { return Ok(conductor); }
            else { return NotFound(); }
        }



        // POST api/<MatriculaController>
        /// <summary>
        /// <method="Post"></method>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //public async Task<HttpStatusCode> Post(Conductor conductor)
        public async Task<HttpStatusCode> Post(ConductorDTO conductor)
        {
            try
            {
                ValidationResult result = validator.Validate(conductor);

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
                else
                {
                    var entity = new Conductor()
                    {
                        Identificacion = conductor.Identificacion,
                        Nombre = conductor.Nombre,
                        Apellido = conductor.Apellido,
                        Direccion = conductor.Direccion,
                        Telefono = conductor.Telefono,
                        Email = conductor.Email,
                        Activo = conductor.Activo,
                        MatriculaId = conductor.MatriculaId
                    };

                    _context.Conductors.Add(entity);
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
        public async Task<HttpStatusCode> Put(Conductor conductor)
        {
            try
            {
                ValidationResult result = validator2.Validate(conductor);

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
                else
                {
                    _context.Entry(conductor).State = EntityState.Modified;
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
            var entity = await _context.Conductors.FindAsync(id);

            _context.Conductors.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion
    }
}
