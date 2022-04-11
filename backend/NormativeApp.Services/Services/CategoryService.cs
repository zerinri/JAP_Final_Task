using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.Category;
using NormativeApp.Core.Entities;
using NormativeApp.Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NormativeApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCategoryDto>>> GetCategoriesLimit(int limit)
        {
            var dbCategories = await _context.Categories.ToListAsync();

            var categories = dbCategories
                .Select(c => _mapper.Map<GetCategoryDto>(c))
                .Skip(limit)
                .Take(5)
                .ToList();

            return new ServiceResponse<List<GetCategoryDto>>() { Data = categories, Count = categories.Count() };
        }

        public async Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategories()
        {
            var dbCategories = await _context.Categories.ToListAsync();

            var categories = dbCategories
                .Select(c => _mapper.Map<GetCategoryDto>(c))
                .ToList();

            return new ServiceResponse<List<GetCategoryDto>>() { Data = categories, Count = categories.Count() };
        }

        public async Task<ServiceResponse<List<GetCategoryDto>>> DeleteCategory(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();
            try
            {
                Category category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Id == id);
                if (category != null)
                {
                    _context.Categories.Remove(category);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _context.Categories
                        .Select(c => _mapper.Map<GetCategoryDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Category not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCategoryDto>>> AddCategory(AddCategoryDto newCategory)
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();
            Category category = _mapper.Map<Category>(newCategory);

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Categories
                .Select(c => _mapper.Map<GetCategoryDto>(c)).ToListAsync();
            serviceResponse.Count = serviceResponse.Data.Count();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetCategoryDto>> UpdateCategory(UpdateCategoryDto updateCategory)
        {
            var serviceResponse = new ServiceResponse<GetCategoryDto>();
            try
            {
                Category category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Id == updateCategory.Id);

                    category.Name = updateCategory.Name;
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _mapper.Map<GetCategoryDto>(category);
 
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}