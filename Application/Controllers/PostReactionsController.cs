using System;
using Application.Models.PostReactions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Validators;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostReactionsController : ControllerBase
    {
        private readonly IBaseService<PostReaction> _baseService;

        public PostReactionsController(IBaseService<PostReaction> basePostReactionsService)
        {
            _baseService = basePostReactionsService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePostReactionsModel postReaction)
        {
            if (postReaction == null)
                return NotFound();

            return Execute(() =>
                _baseService.Add<CreatePostReactionsModel, PostReactionsModel, PostReactionsValidator>(postReaction));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdatePostReactionsModel postReaction)
        {
            if (postReaction == null)
                return NotFound();

            return Execute(() =>
                _baseService
                    .Update<UpdatePostReactionsModel, PostReactionsModel, PostReactionsValidator>(postReaction));
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
            return Execute(() => _baseService.Get<PostReactionsModel>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseService.GetById<PostReactionsModel>(id));
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