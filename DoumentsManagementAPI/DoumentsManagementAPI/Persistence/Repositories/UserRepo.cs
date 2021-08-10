using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Domain.Repositories;
using DoumentsManagementAPI.Persistence.Contexts;
using DoumentsManagementAPI.Security.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Persistence.Repositories
{
    public class UserRepo : Repository<User>, IUserRepo
    {
        public UserRepo(DocManagementAPIDBContext context) : base(context)
        {

        }
        private DocManagementAPIDBContext DocManagementAPIDBContext
        {
            get { return Context as DocManagementAPIDBContext; }
        }

        public async Task<User> findByUserCred(UserCred user)
        {
            User userR = null;
            userR = await DocManagementAPIDBContext
                .Users
                .Where(u => u.EmailAddress == user.Username
                && u.Password == user.Password)
                .FirstOrDefaultAsync();
            return userR;
        }
    }
}
