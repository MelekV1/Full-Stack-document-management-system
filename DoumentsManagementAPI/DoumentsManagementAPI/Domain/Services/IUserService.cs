using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Security.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Domain.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task<User> findByUserCred(UserCred userCred);

    }
}
