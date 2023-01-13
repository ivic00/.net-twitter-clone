using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.User;
using API.Properties.Models;
namespace API.DTOs.Post
{
    public class GetPostDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public uint Likes { get; set; }
        public uint Dislikes { get; set; }
        public DateTime UploadDateTime { get; set; }
        public GetUserDto User { get; set; }
    }
}