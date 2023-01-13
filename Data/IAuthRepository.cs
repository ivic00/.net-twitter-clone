using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Properties.Models;

namespace API.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register (User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}