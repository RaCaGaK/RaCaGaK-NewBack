using Layer.Architecture.Application.Models;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Layer.Architecture.Application.Controllers
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
            if (template == null)
                return NotFound();

            return Execute(() => _baseService.Add<CreateTemplateModel, TemplateModel, TemplateValidator>(template));
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseService.GetById<TemplateModel>(id));
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
