using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Requisiciones.DTO;
using Requisiciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requisiciones.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class RequisitionController : ControllerBase
    {
        private static ILogger<RequisitionController> _logger;
        private Requisitions_DTO _requisitionsDTO;

        public RequisitionController(ILogger<RequisitionController> logger, RequisitionsDbContext dbContext)
        {
            _logger = logger;
            _requisitionsDTO = new Requisitions_DTO(dbContext);
        }

        [HttpGet]
        [Route("api/[controller]/MyRequisitions/{id}")]
        public IEnumerable<Requisitions> GetMyRequisitions(int id)
        {
            return _requisitionsDTO.GetRequisitions(id);
        }

        [HttpGet]
        [Route("api/[controller]/RequisitionDetail/{idRequisition}/{idEmployee}")]
        public IActionResult GetRequisitionDetail(int idRequisition, int idEmployee)
        {
            return Ok(_requisitionsDTO.GetRequisition(idRequisition, idEmployee));
        }
    }
}
