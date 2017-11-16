using ComboApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComboApp.Services
{
    public class OrderOfflineService
        : IOrderService
    {
        private List<Order> db;

        public OrderOfflineService()
        {
            double rnd;
            var random = new Random();

            string transactionType;
            rnd = random.NextDouble();
            if (rnd < 0.4)
                transactionType = "I";
            else if (rnd < 0.8)
                transactionType = "O";
            else
                transactionType = "T";

            string orderType;
            rnd = random.NextDouble();
            if (rnd < 0.5)
                orderType = "M";
            else if (rnd < 0.8)
                orderType = "A";
            else
                orderType = "S";

            db = new List<Order>();
            for (int i = 0; i < 20; i++)
            {
                db.Add(new Order
                {
                    OrderId = i,
                    ExternalId = $"ORDER{i.ToString().PadLeft(5, '0')}",
                    TransactionType = transactionType,
                    BusinessAssociateId = i,
                    DeliveryDate = DateTime.Now,
                    Priority = random.Next(1, 11),
                    OrderType = orderType,
                    Status = "F",
                    Information = $"Information{i}",
                    BusinessAssociateName = $"Name1_{i.ToString().PadLeft(3, '0')}"
                });
            }
        }

        public Task<(bool IsSuccessful, IEnumerable<Order> Result, HttpError Error)> GetAsync()
        {
            return Task.FromResult<(bool, IEnumerable<Order>, HttpError)>((true, db, null));
        }
    }
}
