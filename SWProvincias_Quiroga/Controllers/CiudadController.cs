using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Quiroga.Data;
using SWProvincias_Quiroga.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Quiroga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {

        private readonly DbPaisFinalContext context;

        public CiudadController(DbPaisFinalContext context)
        {
            this.context = context;
        }

        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {
            return context.Ciudades.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<Ciudad> Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Ciudades.Add(ciudad);

            context.SaveChanges();

            return Ok();
        }

        //PUT
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }

            context.Entry(ciudad).State = EntityState.Modified;

            context.SaveChanges();

            return Ok();
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            var ciudad = (from cdad in context.Ciudades where cdad.IdCiudad == id select cdad).SingleOrDefault();

            if (ciudad == null)
            {
                return NotFound();
            }

            context.Ciudades.Remove(ciudad);

            context.SaveChanges();

            return ciudad;
        }

    }
}
