using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CQRSApi.Helper;
using CQRSApi.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CQRSApi.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseClass
    {
        private readonly IConfiguration configuration;
        protected readonly IMongoCollection<T> Collection;
        public BaseRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
            var MongoDbDatabase = configuration.GetSection("MainDb").GetSection("DatabaseName").Value;
            var MongoDbConnection = configuration.GetSection("MainDb").GetSection("ConnectionStringLocal").Value;
            var db = new MongoClient(MongoDbConnection).GetDatabase(MongoDbDatabase);
            this.Collection = db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }
        public async Task<T> Add(T entity)
        {
            var firstEntity = GetAll().OrderByDescending(x => x.Id).FirstOrDefault();
            if(firstEntity!=null)
                entity.Id = firstEntity.Id + 1;

            var options = new InsertOneOptions { BypassDocumentValidation = false };

            Collection.InsertOne(entity, options);

            return entity;
        }

        public  async Task<bool> AddRange(IEnumerable<T> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            return (await Collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options)).IsAcknowledged;
        }

        public Task<T> Get(int id)
        {
             return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate=null)
        {
            return predicate == null
    ? Collection.AsQueryable()
    : Collection.AsQueryable().Where(predicate);
        }
        public async Task<List<T>> GetAllList(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
    ? Collection.AsQueryable().ToList()
    : Collection.AsQueryable().Where(predicate).ToList();
        }
        public async Task<T> Remove(int id)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == id);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(int id, T entity)
        {
            return await Collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }

    }
}
