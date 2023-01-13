using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Post;
using API.DTOs.User;
using API.Properties.Models;
using AutoMapper;

namespace API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, GetUserDto>();
            CreateMap<AddPostDto, Post>();
            CreateMap<Post, GetPostDto>();
        }
    }
}