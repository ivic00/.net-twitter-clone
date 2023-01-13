using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs.Post;
using API.DTOs.User;
using API.Properties.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Properties.Models.PostServices
{
    public class PostService : IPostService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PostService(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto newPost)
        {
            ServiceResponse<List<GetPostDto>> serviceResponse = new ServiceResponse<List<GetPostDto>>();

            Post post = _mapper.Map<Post>(newPost);
            post.User = _mapper.Map<User>(await _context.Users.FirstOrDefaultAsync(x => x.Id == GetUserId()));
            post.UploadDateTime = DateTime.Now;

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Posts.Where(x => x.User.Id == GetUserId()).Select(x => _mapper.Map<GetPostDto>(x)).ToListAsync();
            serviceResponse.Message = "Post uploaded successfully";

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPostDto>>> GetAllPostsByUser()
        {
            ServiceResponse<List<GetPostDto>> serviceResponse = new ServiceResponse<List<GetPostDto>>();
            serviceResponse.Data = await _context.Posts.Include(x => x.User)
            .Where(x => x.User.Id == GetUserId())
            .Select(x => _mapper.Map<GetPostDto>(x))
            .ToListAsync();

            return serviceResponse;
        }

        public Task<ServiceResponse<GetPostDto>> LikePost(int postId)
        {
            throw new NotImplementedException();
        }

        public int GetUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

    }
}