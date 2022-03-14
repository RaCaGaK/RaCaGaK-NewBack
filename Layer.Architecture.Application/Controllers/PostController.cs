﻿using Layer.Architecture.Application.Models;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Layer.Architecture.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IBaseService<Post> _baseService;

        public PostController(IBaseService<Post> basePostService)
        {
            _baseService = basePostService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePostModel post)
        {
            if (post == null)
                return NotFound();

            return Execute(() => _baseService.Add<CreatePostModel, PostModel, PostValidator>(post));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdatePostModel post)
        {
            if (post == null)
                return NotFound();

            return Execute(() => _baseService.Update<UpdatePostModel, PostModel, PostValidator>(post));
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
            return Execute(() => _baseService.Get<PostModel>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseService.GetById<PostModel>(id));
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