using System.Collections.Generic;
using System.Threading.Tasks;
using Manaccountingapp.Models;

namespace Manaccountingapp.Services
{
    public interface IRestService
    {
        Task<Product> GetProductDataAsync(string url);
        Task<List<Product>> GetProductsDataAsync(string url);
        Task<LoginResponse> LoginUserPostAsync(string url, LoginInfo loginInfo);
    }
}