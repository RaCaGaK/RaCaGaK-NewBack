using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Layer.Architecture.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private IBaseService<Post> _baseUserService;    
    }
}
