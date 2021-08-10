using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Domain.Repositories
{
    public interface IUserRepo : IRepository<User>
    {
        public Task<User> findByUserCred(UserCred userCred);
    }
}
