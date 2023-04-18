using Smartproduct.Data;
using Smartproduct.Interface.Product;
using Smartproduct.Model.Category;
using Smartproduct.Repository.ExceptionHandler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Smartproduct.Repository.Helper;
using Dapper;

namespace Smartproduct.Repository.Product
{
    public class ProductRepository : IProduct
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        public ProductRepository(DataContext context, IConfiguration configuration)
        {
            _config = configuration;
            _context = context;
        }

        public async Task<bool> CheckIfProductExist(string Name)
        {
            try
            {
                return await _context.Products.AnyAsync(x => x.Name.Replace(" ", "").Trim() == Name.ToLower().Replace(" ", "").Trim());
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }

        public async Task<bool> Delete(Model.Product.Product product)
        {
            try
            {
                _context.Entry(product).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }

        public async Task<List<Model.Product.Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Model.Product.Product> GetProductById(int Id)
        {
            return await _context.Products.FindAsync(Id);
        }

        public async Task<Model.Product.Product> Post(Model.Product.Product product)
        {
            try
            {
                product.CreatedOn = DateTime.Now;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return null;
            }
        }

        public async Task<bool> Bulkinsert(List<Model.Product.Product> p)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {

                    var Products = Converter.ToDataTableFromList(p, true);
                    await using var connection = Connection.GetOpenConnection(_config.GetConnectionString("Default"));
                    var data = connection.Query<bool>("TVP_products_Insert", new
                    {
                        Products = Products.AsTableValuedParameter("ProductTypeTVP")
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return true;
                }
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }

        public async Task<bool> Put(Model.Product.Product product)
        {
            try
            {
                product.CreatedOn = DateTime.Now;
                _context.Entry(product).State = EntityState.Modified;
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
