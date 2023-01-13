using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Post;
using API.Properties.Models.PostServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [Controller]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;

        }

        [HttpPost]
        [Route("UploadPost")]
        public async Task<IActionResult> UploadPost([FromBody] AddPostDto newPost)
        {
            return Ok(await _postService.AddPost(newPost));
        }

        [HttpGet]
        [Route("GetAllPostsByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            return Ok(await _postService.GetAllPostsByUser());
        }

        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await _postService.GetAllPostsByUser());
        }
    }
}