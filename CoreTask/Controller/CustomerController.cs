using CoreTask.Application.InterFaces;
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
    public class CustomerController : ControllerBase
    {
        ICustomer _Interface;

        public CustomerController(ICustomer Interface)
        {
            _Interface = Interface;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> get()
        {
            return Ok(await _Interface.GetAll());
        }

    }
}
