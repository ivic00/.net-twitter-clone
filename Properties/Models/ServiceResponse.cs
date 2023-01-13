using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.User;

namespace API.Properties.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool success { get; set; } = true;
        public string? Message { get; set; } = null;

        public static implicit operator ServiceResponse<T>(ServiceResponse<GetUserDto> v)
        {
            throw new NotImplementedException();
        }
    }
}