using ComboApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComboApp.Services
{
    public class BusinessAssociateOfflineService
        : IBusinessAssociateService
    {
        private List<BusinessAssociate> db;

        public BusinessAssociateOfflineService()
        {
            db = new List<BusinessAssociate>();
            for (int i = 0; i < 20; i++)
            {
                db.Add(new BusinessAssociate
                {
                    BusinessAssociateId = i,
                    Number = $"{i.ToString().PadLeft(3, '0')}",
                    Matchcode = $"MATCH{i.ToString().PadLeft(3, '0')}",
                    Name1 = $"Name1_{i.ToString().PadLeft(3, '0')}",
                    Name2 = $"Name2_{i.ToString().PadLeft(3, '0')}",
                    Street = $"Street{i.ToString().PadLeft(3, '0')}",
                    Zip = $"Zip{i.ToString().PadLeft(3, '0')}",
                    City = $"City{i.ToString().PadLeft(3, '0')}",
                    Country = $"Country{i.ToString().PadLeft(3, '0')}",
                    Blocked = false,
                    Information = $"Information{i.ToString().PadLeft(3, '0')}"
                });
            }
        }

        public Task<(bool IsSuccessful, PageResult<BusinessAssociate> Result, HttpError Error)> GetNextPageAsync(int? skip = null, int? top = null)
        {
            return Task.FromResult<(bool, PageResult<BusinessAssociate>, HttpError)>((true, new PageResult<BusinessAssociate>
            {
                Count = db.Count,
                Items = db
            }, null));
        }
    }
}
