using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Properties.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime UploadDateTime { get; set; }
        public uint Likes { get; set; }
        public uint Dislikes { get; set; }
        public User User { get; set; }
    }
}