using MongoDB.Bson;
using MongoDB.Driver;
using MsEmployee.Infrastrucuture.Base.MongoDb;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace MsEmployee.Infrastrucuture.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext _context;
        protected readonly IMongoCollection<TEntity> _collection;

        protected BaseRepository(IMongoContext context)
        {
            _context = context;
            _collection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task Create(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            await _collection.InsertOneAsync(obj);
        }

        public async Task<TEntity> Get(string id)
        {
            var objectId = new ObjectId(id);
            return await _collection.FindAsync(Builders<TEntity>.Filter.Eq("_id", objectId)).Result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var all = await _collection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }
        public virtual void Update(TEntity obj)
        {
           _context.AddCommand(async () =>
            {
                await _collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj);
            });
        }

        public void Delete(string id)
        {
            var objectId = new ObjectId(id);
            _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
