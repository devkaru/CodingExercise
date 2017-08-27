using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Norm;
using System.Threading.Tasks;
using System.Configuration;
using CodingExercise.DAL.Interface;
using CodingExercise.DAL.Helpers;

namespace CodingExercise.DAL.Concret
{
   public class MongoRepository : IRepository
    {
    
        private IMongo _provider;
        private IMongoDatabase _db { get { return this._provider.Database; } }

        public MongoRepository()
        {
            _provider = Mongo.Create(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }

        //Genric Method to Add IEumerable object in Genric Collection
        public void Add<T>(IEnumerable<T> items) where T : class, new()
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        //Genric Method to Add Record in Genric Collection
        public void Add<T>(T item) where T : class, new()
        {
            _db.GetCollection<T>().Save(item);
        }

        //Genric Method to GetAll Record as Queryable
        public IQueryable<T> All<T>() where T : class, new()
        {
           return _db.GetCollection<T>().AsQueryable();
        }

        //Genric Method to GetAll Record as Queryable with Paging
        public IQueryable<T> All<T>(int page, int pageSize) where T : class, new()
        {
            return PagingExtension.Page(All<T>(),page,pageSize);
        }

        //Genric Method To Delete Records From Collection
        public void Delete<T>(T item) where T : class, new()
        {
            _db.GetCollection<T>().Delete(item);
        }

        //Genric Method To Delete Records From Collection with condition
        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            var items = All<T>().Where(expression);
            foreach (var item in items)
            {
                Delete(item);
            }
        }

        //Genric Method To Delete All Records 
        public void DeleteAll<T>() where T : class, new()
        {
            _db.DropCollection(typeof(T).Name);
        }

        public void Dispose()
        {
            _provider.Dispose();
        }

        //Genric Method to Get a Sigle records from Database
        public T Single<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            return All<T>().Where(expression).SingleOrDefault();
        }
    }
}
