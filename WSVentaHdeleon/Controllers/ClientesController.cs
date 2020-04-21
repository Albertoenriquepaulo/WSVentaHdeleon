using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVentaHdeleon.Models;

namespace WSVentaHdeleon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                var result = db.Cliente.ToList();
                return Ok(result);
            }
        }
    }
}