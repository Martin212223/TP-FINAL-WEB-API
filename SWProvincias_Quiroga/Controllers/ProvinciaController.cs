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
    public class ProvinciaController : ControllerBase
    {

        private readonly DbPaisFinalContext context;

        public ProvinciaController(DbPaisFinalContext context)
        {
            this.context = context;
        }

        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.ToList();
        }

        //POST
        [HttpPost]
        public ActionResult<Provincia> Post(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Provincias.Add(provincia);

            context.SaveChanges();

            return Ok();
        }

        //PUT
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }

            context.Entry(provincia).State = EntityState.Modified;

            context.SaveChanges();

            return Ok();
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id)
        {
            var provincia = (from prov in context.Provincias where prov.IdProvincia == id select prov).SingleOrDefault();

            if (provincia == null)
            {
                return NotFound();
            }

            context.Provincias.Remove(provincia);

            context.SaveChanges();

            return provincia;
        }

    }
}
