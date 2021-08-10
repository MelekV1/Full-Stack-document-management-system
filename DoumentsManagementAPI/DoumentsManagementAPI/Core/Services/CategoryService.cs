using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Domain.Repositories;
using DoumentsManagementAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }

        public async Task DeleteCategory(Category category)
        {
            _unitOfWork.Categories.Remove(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Category> CreateCategory(Category newCategory)
        {
            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.CommitAsync();
            return newCategory;
        }
    }
}
