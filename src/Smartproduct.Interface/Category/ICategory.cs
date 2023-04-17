using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartproduct.Model.Category;

namespace Smartproduct.Interface.Category
{
    public interface ICategory
    {
        Task<bool> Post(Smartproduct.Model.Category.Category category);
        Task<bool> Put(Smartproduct.Model.Category.Category category);
        Task<Smartproduct.Model.Category.Category> GetCategoryById(int Id);
        Task<List<Smartproduct.Model.Category.Category>> GetAllCategories();
        Task<bool> Delete(Smartproduct.Model.Category.Category category);
        Task<bool> CheckIfCategoryExist(string Name);
        Task<bool> CheckIfCategoryCodeExist(string Name);
    }
}
