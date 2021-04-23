using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Restaurant_Digital_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercaderiaController
    {
        private readonly IMercaderiaService _service;

        public MercaderiaController(IMercaderiaService service)
        {
            _service = service;
        }


        // POST: api/Alquileres       
        [HttpPost]
        public IActionResult Post(MercaderiaDTO mercaderia)
        {
            try
            {
                return new JsonResult(_service.CreateMercaderia(mercaderia)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message) {StatusCode = 401};
            }

        }
    }
}
