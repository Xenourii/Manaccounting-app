using System.Collections.Generic;
using System.Threading.Tasks;
using Manaccountingapp.Models;

namespace Manaccountingapp.Services
{
    public interface IRestService
    {
        Task<Product> GetProductDataAsync(string url, string token);
        Task<List<Product>> GetProductsDataAsync(string url, string token);
        Task<LoginResponse> LoginUserPostAsync(string url, LoginInfo loginInfo);
        Task<OrderResponse> OrderPostAsync(string url, OrderInfo orderInfo, string token);
    }
}