using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Post;

namespace API.Properties.Models.PostServices
{
    public interface IPostService
    {
        Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto newPost);
        Task<ServiceResponse<List<GetPostDto>>> GetAllPostsByUser();
        Task<ServiceResponse<GetPostDto>> LikePost(int postId);
    }
}