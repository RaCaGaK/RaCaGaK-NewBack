using System;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Validators;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly IBaseService<Template> _baseService;

        public TemplateController(IBaseService<Template> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTemplateModel template)
        {
            return template == null ? NotFound() : Execute(() => _baseService.Add<CreateTemplateModel, TemplateModel, TemplateValidator>(template));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateTemplateModel template)
        {
            if (template == null)
                return NotFound();

            return Execute(() => _baseService.Update<UpdateTemplateModel, TemplateModel, TemplateValidator>(template));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseService.Get<TemplateModel>());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return id == 0 ? NotFound() : Execute(() => _baseService.GetById<TemplateModel>(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}