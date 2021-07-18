using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Requisiciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Requisiciones.DTO;

namespace Requisiciones.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private Employees_DTO _employees;

        public EmployeesController(ILogger<EmployeesController> logger, RequisitionsDbContext dbContext)
        {
            this._logger = logger;
            this._employees = new Employees_DTO(dbContext);
        }

        #region GETRegion
        [HttpGet]
        [Route("api/[controller]/Authentication/{userName}/{userPass}")]
        public IActionResult GetAutentication(string userName, string userPass)
        {
            var employee = _employees.Authentication(userName, userPass);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var employees = _employees.GetAllEmployees();

            if (employees == null || employees.Count() == 0)
                return BadRequest();

            return Ok(employees);
        }
        #endregion

        [HttpPost]
        [Route("api/[controller]/save")]
        public IActionResult Post([FromBody] Employees employes)
        {
            var saveEmpoloyee = _employees.SaveEmployee(employes);

            if (saveEmpoloyee)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("api/[controller]/update/{id}")]
        public IActionResult Put(int id, [FromBody] Employees employees)
        {
            bool isModified = _employees.UpdateEmployee(id, employees);

            if (isModified)
                return Ok();

            return BadRequest();
        }

        [HttpDelete]
        [Route("api/[controller]/Delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            bool isDeleted = _employees.DeleteEmployee(id);

            if (isDeleted)
                return Ok();

            return BadRequest();
        }
    }
}
