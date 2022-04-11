using NormativeApp.Common.Entities;
using NormativeApp.Core.Entities;
using System.Threading.Tasks;

namespace NormativeApp.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);

        Task<ServiceResponse<string>> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}