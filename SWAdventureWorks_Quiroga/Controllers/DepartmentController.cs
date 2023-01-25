using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAdventureWorks_Quiroga.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SWAdventureWorks_Quiroga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly AdventureWorks2019Context context;

        public DepartmentController(AdventureWorks2019Context context)
        {
            this.context = context;
        }

        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return context.Department.ToList();
        }

        //GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Department> Get(int id)
        {
            
            Department department = (from dep in context.Department where dep.DepartmentId == id select dep).SingleOrDefault();

            return department;

        }

        //GET BY NAME
        [HttpGet("byname/{depName}")]
        public ActionResult<Department> GetByName(string depName)
        {
            Department department = (from dep in context.Department where dep.Name == depName select dep).SingleOrDefault();

            return department;
        }

        //POST

        [HttpPost]
        public ActionResult<Department> Post(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Department.Add(department);

            context.SaveChanges();

            return Ok();
        }
    }
}
