using Application;
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
            if (Validation.ValidarComandaDTO(comanda))
            {
                try
                {
                    ComandaResponseCreated comandaCreated = _service.CreateComanda(comanda);
                    return new JsonResult(comandaCreated) { StatusCode = 201 };
                }
                catch (Exception)
                {
                    return new BadRequestResult();
                }
            }
            else
            {
                return new BadRequestResult();
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                ComandaConMercaderiaList comanda = _service.GetComandaById(Id);
                if (comanda != null)
                {
                    return new JsonResult(comanda) { StatusCode = 200 };
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message) { StatusCode = 404 };
            }
        }

        [HttpGet]
        public IActionResult Getall(DateTime? Fecha)
        {
            try
            {
                return new JsonResult(_service.GetAll(Fecha)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message) { StatusCode = 400 };
            }
        }
    }
}