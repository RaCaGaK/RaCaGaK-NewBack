using System;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Validators;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MsgsController : ControllerBase
    {
        private readonly IBaseService<Msg> _baseService;

        public MsgsController(IBaseService<Msg> baseMsgService)
        {
            _baseService = baseMsgService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMsgsModel msg)
        {
            if (msg == null)
                return NotFound();

            return Execute(() => _baseService.Add<CreateMsgsModel, MsgsModel, MsgsValidator>(msg));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateMsgsModel msg)
        {
            if (msg == null)
                return NotFound();

            return Execute(() => _baseService.Update<UpdateMsgsModel, MsgsModel, MsgsValidator>(msg));
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
            return Execute(() => _baseService.Get<MsgsModel>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseService.GetById<MsgsModel>(id));
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