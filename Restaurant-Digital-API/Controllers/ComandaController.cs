using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Restaurant_Digital_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController
    {
        private readonly IComandaService _service;

        public ComandaController(IComandaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(ComandaDTO comanda)
        {
            try
            {
                return new JsonResult(_service.CreateComanda(comanda)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message) { StatusCode = 401 };
            }

        }
    }
}
