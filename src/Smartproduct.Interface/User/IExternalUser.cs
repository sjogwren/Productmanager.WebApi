using Smartproduct.Model.User;
using System.Threading.Tasks;

namespace Smartproduct.Interface.User
{
    public interface IExternalUser
    {
        Task<ExternalUser> FindByNameAsync(string username);
        Task<bool> CreateAsync(ExternalUser user);
        Task<bool> UpdateAsync(ExternalUser user);
        Task<ExternalUser> FindByIdAsync(int userId);
        Task<bool> CheckIfEmailExist(string email);
    }
}
