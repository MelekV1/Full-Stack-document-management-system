using DoumentsManagementAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Security.Models
{
    public class UserWithToken : User
    {
        public string AccessToken { get; set; }
        //public string RefreshToken { get; set; }

        public UserWithToken(User user)
        {
            this.UserId = user.UserId;
            this.EmailAddress = user.EmailAddress;
            this.FullName = user.FullName;
            this.Password = user.Password;
            this.Phone = user.Phone;
            this.Role = user.Role;
        }
    }
}
