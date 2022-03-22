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
    public class CommentController : ControllerBase
    {
        private readonly IBaseService<Comment> _baseService;

        public CommentController(IBaseService<Comment> baseCommentService)
        {
            _baseService = baseCommentService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCommentModel comment)
        {
            if (comment == null)
                return NotFound();

            return Execute(() => _baseService.Add<CreateCommentModel, CommentModel, CommentValidator>(comment));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateCommentModel comment)
        {
            if (comment == null)
                return NotFound();

            return Execute(() => _baseService.Update<UpdateCommentModel, CommentModel, CommentValidator>(comment));
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
            return Execute(() => _baseService.Get<CommentModel>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseService.GetById<CommentModel>(id));
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