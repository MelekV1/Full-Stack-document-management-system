using DoumentsManagementAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Domain.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task<Category> GetCategoryById(int id);
        public Task<Category> CreateCategory(Category newCategory);
        public Task DeleteCategory(Category category);
    }
}
