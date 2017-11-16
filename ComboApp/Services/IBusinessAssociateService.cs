using ComboApp.Models;
using System.Threading.Tasks;

namespace ComboApp.Services
{
    public interface IBusinessAssociateService
    {
        Task<(bool IsSuccessful, PageResult<BusinessAssociate> Result, HttpError Error)> GetNextPageAsync(int? skip = null, int? top = null);
    }
}
