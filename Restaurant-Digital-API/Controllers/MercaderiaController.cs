using Application;
using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpPost]
        public IActionResult Post(MercaderiaDTO mercaderia)
        {
            if (Validation.ValidarMercaderiaDTO(mercaderia))
            {
                try
                {
                    MercaderiaResponse mercaderiaResponse = _service.CreateMercaderia(mercaderia);
                    return new JsonResult(mercaderiaResponse) { StatusCode = 201 };
                }
                catch (Exception e)
                {
                    return new JsonResult(e.Message) { StatusCode = 400 };
                }
            }
            else
            {
                return new JsonResult("No se ha podido crear la mercaderia.") { StatusCode = 400 };
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                MercaderiaResponse mercaderia = _service.GetMercaderiaById(Id);
                if (mercaderia != null)
                {
                    return new JsonResult(mercaderia) { StatusCode = 200 };
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
        public IActionResult GetAll(string TipoMercaderia, int TipoMercaderiaId)
        {
            try
            {
                List<MercaderiaResponse> mercaderia = _service.GetAll(TipoMercaderia, TipoMercaderiaId);
                if (mercaderia != null)
                {
                    return new JsonResult(mercaderia) { StatusCode = 200 };
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

        [HttpDelete("{Id}")]
        public IActionResult DeleteById([FromRoute] int Id)
        {
            try
            {
                _service.DeleteMercaderiaById(Id);
                return new OkResult();
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message) { StatusCode = 404 };
            }
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateById([FromRoute] int Id, MercaderiaDTO mercaderia)
        {
            try
            {
                _service.UpdateMercaderia(Id, mercaderia);
                return new OkResult();
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message) { StatusCode = 404 };
            }
        }
    }
}