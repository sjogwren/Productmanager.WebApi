using Smartproduct.Data;
using Smartproduct.Interface.Category;
using Smartproduct.Repository.ExceptionHandler;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Smartproduct.Repository.Category
{
    public class CategoryRepository : ICategory
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfCategoryExist(string Name)
        {
            try
            {
                return await _context.Categories.AnyAsync(x => x.Name.Replace(" ","").Trim() == Name.ToLower().Replace(" ", "").Trim());
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }

        public async Task<bool> CheckIfCategoryCodeExist(string Name)
        {
            try
            {
                return await _context.Categories.AnyAsync(x => x.CategoryCode.Replace(" ", "").Trim() == Name.ToLower().Replace(" ", "").Trim());
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }


        public async Task<bool> Delete(Smartproduct.Model.Category.Category category)
        {
            try
            {
                _context.Entry(category).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }

        public async Task<List<Smartproduct.Model.Category.Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();

        }

        public async Task<Smartproduct.Model.Category.Category> GetCategoryById(int Id)
        {
            return await _context.Categories.FindAsync(Id);
        }

        public async Task<bool> Post(Smartproduct.Model.Category.Category category)
        {
            try
            {
                category.CreatedOn = DateTime.Now;
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }

        public async Task<bool> Put(Smartproduct.Model.Category.Category category)
        {
            try
            {
                category.CreatedOn = DateTime.Now;
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }
    }
}
