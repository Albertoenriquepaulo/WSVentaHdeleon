using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSVentaHdeleon.Models;
using WSVentaHdeleon.Models.Response;
using WSVentaHdeleon.Models.ViewModels;
using WSVentaHdeleon.Repository.IRepository;

namespace WSVentaHdeleon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientRepository _rpClient;

        public ClientesController(IClientRepository rpClient)
        {
            _rpClient = rpClient;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rpClient.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            Respuesta respuesta = new Respuesta();
            if (id == null)
            {
                respuesta.Bad("Debe especificar un Id");
                return NotFound(respuesta);
            }

            respuesta = _rpClient.GetOne((int)id);

            if (respuesta.Exito == 0)
            {
                return BadRequest(respuesta);
            }

            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteVM oModel)
        {
            Respuesta respuesta = _rpClient.Create(oModel);

            if (respuesta.Exito == 0)
            {
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        [HttpPut]
        public IActionResult Update(ClienteVM oModel)
        {
            Respuesta respuesta = _rpClient.Update(oModel);

            if (respuesta.Exito == 0)
            {
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            Respuesta respuesta = new Respuesta();

            if (id == null)
            {
                respuesta.Bad("Debe especificar un Id");
                return NotFound(respuesta);
            }

            respuesta = _rpClient.Delete((int)id);

            if (respuesta.Exito == 0)
            {
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }
    }
}