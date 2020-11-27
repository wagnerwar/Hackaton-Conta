using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureWeb.Models;

namespace AzureWeb.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<CidadaoModel>> GetItemsAsync(string query);
        Task<CidadaoModel> GetItemAsync(string id);
        Task AddItemAsync(CidadaoModel item);
        Task UpdateItemAsync(string id, CidadaoModel item);
        Task DeleteItemAsync(string id);
    }
}
