using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

using AzureWeb.Models;

namespace AzureWeb.Services
{
    public class CosmosDbService : ICosmosDbService
    {

        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(CidadaoModel item)
        {            
            await this._container.CreateItemAsync<CidadaoModel>(item, new PartitionKey(item.id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<CidadaoModel>(id, new PartitionKey(id));
        }

        public async Task<CidadaoModel> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<CidadaoModel> response = await this._container.ReadItemAsync<CidadaoModel>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<CidadaoModel>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<CidadaoModel>(new QueryDefinition(queryString));
            List<CidadaoModel> results = new List<CidadaoModel>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, CidadaoModel item)
        {
            await this._container.UpsertItemAsync<CidadaoModel>(item, new PartitionKey(id));
        }

    }
}
