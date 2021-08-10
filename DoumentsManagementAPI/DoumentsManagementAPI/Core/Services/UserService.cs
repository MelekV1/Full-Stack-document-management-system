using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Domain.Repositories;
using DoumentsManagementAPI.Domain.Services;
using DoumentsManagementAPI.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<User> findByUserCred(UserCred userCred)
        {
            return await _unitOfWork.Users.findByUserCred(userCred);           
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }
    }
}
