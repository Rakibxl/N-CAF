using Architecture.Core.Entities.Core;
using Architecture.Core.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Repository.Core
{
    public abstract class Repository<TEntity>
        : IRepository<TEntity>
        where TEntity : class
    {
        #region CONFIG
        protected ApplicationDbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        #endregion

        #region LINQ Async
        public virtual async Task<IList<TResult>> GetAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            bool disableTracking = true)
        {
            //using (_dbContext)
            //{
                IQueryable<TEntity> query = _dbSet.AsQueryable();
                if (include != null)
                    query = include(query);

                if (predicate != null)
                    query = query.Where(predicate);

                if (orderBy != null)
                    query = orderBy(query);

                if (disableTracking)
                    query = query.AsNoTracking();

                return await query.Select(selector).ToListAsync();
            //}

        }

        public virtual async Task<(IList<TResult> Items, int Total, int TotalFilter)> GetWithFilterAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            int pageIndex = 1, int pageSize = 10,
                            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            int total = await query.CountAsync();
            int totalFilter = total;

            if (include != null)
                query = include(query);

            if (predicate != null)
            {
                query = query.Where(predicate);
                totalFilter = await query.CountAsync();
            }

            if (orderBy != null)
                query = orderBy(query);

            if (disableTracking)
                query = query.AsNoTracking();

            var result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(selector).ToListAsync();

            return (result, total, totalFilter);
        }

        public virtual async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (disableTracking)
                query = query.AsNoTracking();

            var result = await query.Select(selector).FirstOrDefaultAsync();

            return result;
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = _dbSet.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.CountAsync();
        }

        public virtual async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _dbSet.AsQueryable();

            return await query.AnyAsync(predicate);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
           // entity.GetType().GetProperty("CreatedBy") = DateTime.UtcNow;
            //entity.CreatedBy = DateTime.UtcNow;
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IList<TEntity>> AddRangeAsync(IList<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IList<TEntity>> UpdateRangeAsync(IList<TEntity> entities)
        {
            _dbContext.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public virtual async Task DeleteAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);

            await DeleteAsync(entity);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public virtual async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _dbSet.AsQueryable().Where(predicate);

            if (query.Any())
            {
                _dbSet.RemoveRange(query);
            }

            return 1;
        }

        public virtual async Task<bool> DeleteRangeAsync(IList<TEntity> entities)
        {
            _dbContext.RemoveRange(entities);
            return true;
        }
        #endregion

        #region LINQ
        public virtual IList<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (disableTracking)
                query = query.AsNoTracking();

            var result = query.Select(selector).ToList();

            return result;
        }

        public virtual (IList<TResult> Items, int Total, int TotalFilter) Get<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            int pageIndex = 1, int pageSize = 10,
                            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            int total = query.Count();
            int totalFilter = total;

            if (include != null)
                query = include(query);

            if (predicate != null)
            {
                query = query.Where(predicate);
                totalFilter = query.Count();
            }

            if (orderBy != null)
                query = orderBy(query);

            if (disableTracking)
                query = query.AsNoTracking();

            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(selector).ToList();

            return (result, total, totalFilter);
        }

        public virtual TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (disableTracking)
                query = query.AsNoTracking();

            var result = query.Select(selector).FirstOrDefault();

            return result;
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual int GetCount(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = _dbSet.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.Count();
        }

        public virtual bool IsExists(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _dbSet.AsQueryable();

            return query.Any(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void AddRange(IList<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IList<TEntity> entities)
        {
            _dbContext.UpdateRange(entities);
        }

        public virtual void Delete(object id)
        {
            var entity = _dbSet.Find(id);

            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _dbSet.AsQueryable().Where(predicate);

            if (query.Any())
            {
                _dbSet.RemoveRange(query);
            }
        }

        public virtual void DeleteRange(IList<TEntity> entities)
        {
            _dbContext.RemoveRange(entities);
        }
        #endregion

        #region SQL
        public IList<TEntity> ExecuteSqlQuery(string sql, params object[] parameters)
        {
            return (IList<TEntity>)_dbSet.FromSqlRaw(sql, parameters).ToListAsync();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public IList<dynamic> GetFromSql(string sql, Dictionary<string, object> parameters, bool isStoredProcedure = false)
        {
            var items = new List<dynamic>();

            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                if (isStoredProcedure) { command.CommandType = CommandType.StoredProcedure; }
                if (command.Connection.State != ConnectionState.Open) { command.Connection.Open(); }

                foreach (var param in parameters)
                {
                    DbParameter dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = param.Key;
                    dbParameter.Value = param.Value;
                    command.Parameters.Add(dbParameter);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new ExpandoObject() as IDictionary<string, object>;
                        for (var count = 0; count < reader.FieldCount; count++)
                        {
                            item.Add(reader.GetName(count), reader[count]);
                        }
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        public DataSet GetDataSetFromSql(string sql, Dictionary<string, object> parameters, bool isStoredProcedure = false)
        {
            var dataSet = new DataSet();
            DbConnection connection = _dbContext.Database.GetDbConnection();
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);

            using (var command = dbFactory.CreateCommand())
            {
                command.Connection = connection;
                command.CommandText = sql;
                if (isStoredProcedure) { command.CommandType = CommandType.StoredProcedure; }
                if (command.Connection.State != ConnectionState.Open) { command.Connection.Open(); }

                foreach (var param in parameters)
                {
                    DbParameter dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = param.Key;
                    dbParameter.Value = param.Value;
                    command.Parameters.Add(dbParameter);
                }

                using (var adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(dataSet);
                }
            }

            return dataSet;
        }

        public (IList<TEntity> Items, int Total, int TotalFilter) GetFromSql(string sql, IList<(string Key, object Value, bool IsOut)> parameters, bool isStoredProcedure = true)
        {
            var items = new List<TEntity>();
            int? totalCount = 0;
            int? filteredCount = 0;

            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                if (isStoredProcedure) { command.CommandType = CommandType.StoredProcedure; }
                if (command.Connection.State != ConnectionState.Open) { command.Connection.Open(); }

                foreach (var param in parameters)
                {
                    DbParameter dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = param.Key;
                    if (!param.IsOut)
                    {
                        dbParameter.Value = param.Value;
                    }
                    else
                    {
                        dbParameter.Direction = ParameterDirection.Output;
                        dbParameter.DbType = DbType.Int32;
                    }
                    command.Parameters.Add(dbParameter);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var itemType = typeof(TEntity);
                        var constructor = itemType.GetConstructor(new Type[] { });
                        var instance = constructor.Invoke(new object[] { });
                        var properties = itemType.GetProperties();

                        foreach (var property in properties)
                        {
                            if (!reader.IsDBNull(property.Name))
                                property.SetValue(instance, reader[property.Name]);
                        }

                        items.Add((TEntity)instance);
                    }
                }

                totalCount = (int?)command.Parameters["TotalCount"].Value;
                filteredCount = (int?)command.Parameters["FilteredCount"].Value;
            }

            return (items, totalCount ?? 0, filteredCount ?? 0);
        }
        #endregion
    }
}