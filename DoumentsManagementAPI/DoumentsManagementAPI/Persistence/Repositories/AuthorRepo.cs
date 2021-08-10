﻿using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Domain.Repositories;
using DoumentsManagementAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Persistence.Repositories
{
    public class AuthorRepo : Repository<Author>, IAuthorRepo
    {
        public AuthorRepo(DocManagementAPIDBContext context) : base(context)
        {

        }
        private DocManagementAPIDBContext DocManagementAPIDBContext
        {
            get { return Context as DocManagementAPIDBContext; }
        }
    }
}
