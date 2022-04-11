using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.Ingredient;
using NormativeApp.Core.Dtos.Sql;
using NormativeApp.Core.Entities;
using NormativeApp.Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NormativeApp.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public IngredientService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetIngredientDto>>> GetAllIngredients()
        {
            var dbIngredients = await _context.Ingredients.ToListAsync();

            var ingredients = dbIngredients.Select(i => _mapper.Map<GetIngredientDto>(i)).ToList();

            return new ServiceResponse<List<GetIngredientDto>>() { Data = ingredients, Count = ingredients.Count() };
        }

        public async Task<ServiceResponse<List<GetIngredientDto>>> DeleteIngredient(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetIngredientDto>>();
            try
            {
                Ingredient ingredient = await _context.Ingredients
                    .FirstOrDefaultAsync(c => c.Id == id);
                if (ingredient != null)
                {
                    _context.Ingredients.Remove(ingredient);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _context.Ingredients
                        .Select(c => _mapper.Map<GetIngredientDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Ingredient not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            serviceResponse.Count = serviceResponse.Data.Count();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetIngredientDto>>> AddIngredient(AddIngredientDto newIngredient)
        {
            var serviceResponse = new ServiceResponse<List<GetIngredientDto>>();
            Ingredient ingredient = _mapper.Map<Ingredient>(newIngredient);

            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Ingredients
                .Select(c => _mapper.Map<GetIngredientDto>(c)).ToListAsync();
            serviceResponse.Count = serviceResponse.Data.Count();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetIngredientDto>> UpdateIngredient(UpdateIngredientDto updateIngredient)
        {
            var serviceResponse = new ServiceResponse<GetIngredientDto>();
            try
            {
                Ingredient ingredient = await _context.Ingredients
                    .FirstOrDefaultAsync(c => c.Id == updateIngredient.Id);

                ingredient.Name = updateIngredient.Name;
                ingredient.PurchasePrice = updateIngredient.PurchasePrice;
                ingredient.PurchaseQuantity = updateIngredient.PurchaseQuantity;
                ingredient.PurchaseUnitMeasure = updateIngredient.PurchaseUnitMeasure;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetIngredientDto>(ingredient);

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