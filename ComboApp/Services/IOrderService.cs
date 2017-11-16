using ComboApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComboApp.Services
{
    public interface IOrderService
    {
        Task<(bool IsSuccessful, IEnumerable<Order> Result, HttpError Error)> GetAsync();
    }
}
