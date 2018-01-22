using System.Threading.Tasks;
using Manaccountingapp.Models;

namespace Manaccountingapp.Services
{
    public interface IRestService
    {
        Task<Product> GetDataAsync(string url);
        Task<LoginResponse> LoginUserAsync(string url, LoginInfo loginInfo);
    }
}