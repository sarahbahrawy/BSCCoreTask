using CoreTask.Application.InterFaces;
using CoreTask.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTask.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class VisitsController : ControllerBase
    {
        IVisits _Interface;

        public VisitsController(IVisits Interface)
        {
            _Interface = Interface;
        }

        [HttpPost("SaveVisit")]
        public async Task<IActionResult> SaveVisit([FromBody] Visits obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _Interface.SaveVisit(obj));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _Interface.GetAll());
        }

        [HttpPut("UpdateVisit")]
        public async Task<IActionResult> UpdateVisit([FromBody] Visits obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _Interface.UpdateVisit(obj));
        }

        [HttpDelete("DeleteVisit/{id}")]
        public async Task<IActionResult> DeleteVisit([FromRoute] int id)
        {
            return Ok(await _Interface.DeleteVisit(id));
        }

        [HttpGet("GetSalesVisits/{id}")]
        public async Task<IActionResult> GetSalesVisits([FromRoute] int id)
        {
            return Ok(await _Interface.GetSalesVisits(id));
        }
    }
}
