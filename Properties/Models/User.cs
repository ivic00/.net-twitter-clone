using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Properties.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Post> Posts { get; set; }
    }
}