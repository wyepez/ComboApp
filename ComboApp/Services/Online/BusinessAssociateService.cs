using ComboApp.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace ComboApp.Services
{
    public class BusinessAssociateService
        : IBusinessAssociateService
    {
        public async Task<(bool IsSuccessful, PageResult<BusinessAssociate> Result, HttpError Error)> GetNextPageAsync(int? skip = null, int? top = null)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", Constants.AccessToken);
                var response = await client.GetAsync(new Uri($"{Constants.ApiUrl}api/business-associates"));
                var (result, error) = response.IsSuccessStatusCode
                    ? (JsonConvert.DeserializeObject<PageResult<BusinessAssociate>>(await response.Content.ReadAsStringAsync()), (HttpError)null)
                    : ((PageResult<BusinessAssociate>)null, JsonConvert.DeserializeObject<HttpError>(await response.Content.ReadAsStringAsync()));
                return (response.IsSuccessStatusCode, result, error);
            }
        }
    }
}
