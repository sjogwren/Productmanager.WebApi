using Smartproduct.Data;
using Microsoft.Extensions.Configuration;
using Smartproduct.Interface.User;
using Smartproduct.Model.User;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartproduct.Repository.ExceptionHandler;
using Microsoft.EntityFrameworkCore;

namespace FruitSA.Repository.UserRepository
{
    public class ExternalUserRepository : IExternalUser
    {
        private readonly DataContext _dataContext;
        public ExternalUserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ExternalUser> FindByNameAsync(string username)
        {
            return await _dataContext.ApplicationUsers.Where(x => x.Email == username).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateAsync(ExternalUser user)
        {

            try
            {
                _dataContext.ApplicationUsers.Add(user);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }


        public async Task<bool> UpdateAsync(ExternalUser user)
        {
            try
            {
                _dataContext.ApplicationUsers.Update(user);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }

        public async Task<ExternalUser> FindByIdAsync(int UserID)
        {
            return await _dataContext.ApplicationUsers.Where(x => x.ExternalUserID == UserID).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckIfEmailExist(string email)
        {
            try
            {
                return await _dataContext.ApplicationUsers.AnyAsync(x => x.Email == email.ToLower());
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }
    }
}
