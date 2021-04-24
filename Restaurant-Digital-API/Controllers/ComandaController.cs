using Application.Services;
using Domain.DTOs;
using Domain.Models;
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

        [HttpGet("{Id?}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                 ComandaResponse comanda = _service.GetComandaById(Id);
                if (comanda != null)
                {
                    return new JsonResult(comanda) { StatusCode = 200 };
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpGet]
        public IActionResult Getall(string? Fecha)
        {
            try
            {
                return new JsonResult(_service.GetAll(Fecha)) { StatusCode = 200 };
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}
