using ComboApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace ComboApp.Services
{
    public class OrderService
        : IOrderService
    {
        public async Task<(bool IsSuccessful, IEnumerable<Order> Result, HttpError Error)> GetAsync()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", Constants.AccessToken);
                var response = await client.GetAsync(new Uri($"{Constants.ApiUrl}api/orders"));
                var (result, error) = response.IsSuccessStatusCode
                    ? (JsonConvert.DeserializeObject<IEnumerable<Order>>(await response.Content.ReadAsStringAsync()), (HttpError)null)
                    : ((IEnumerable<Order>)null, JsonConvert.DeserializeObject<HttpError>(await response.Content.ReadAsStringAsync()));
                return (response.IsSuccessStatusCode, result, error);
            }
        }
    }
}
