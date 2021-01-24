﻿using Architecture.Core.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Repository.Core
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        #region LINQ Async
        Task<IList<TResult>> GetAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            bool disableTracking = true);
        Task<(IList<TResult> Items, int Total, int TotalFilter)> GetWithFilterAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            int pageIndex = 1, int pageSize = 10,
                            bool disableTracking = true);
        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            bool disableTracking = true);
        Task<TEntity> GetByIdAsync(object id);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IList<TEntity>> AddRangeAsync(IList<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IList<TEntity>> UpdateRangeAsync(IList<TEntity> entities);
        Task DeleteAsync(object id);
        Task DeleteAsync(TEntity entity);
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> DeleteRangeAsync(IList<TEntity> entities);
        #endregion

        #region LINQ
        IList<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            bool disableTracking = true);
        (IList<TResult> Items, int Total, int TotalFilter) Get<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            int pageIndex = 1, int pageSize = 10,
                            bool disableTracking = true);
        TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
                            Expression<Func<TEntity, bool>> predicate = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            bool disableTracking = true);
        TEntity GetById(object id);
        int GetCount(Expression<Func<TEntity, bool>> predicate = null);
        bool IsExists(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IList<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IList<TEntity> entities);
        void Delete(object id);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        void DeleteRange(IList<TEntity> entities);
        #endregion

        #region SQL
        IList<TEntity> ExecuteSqlQuery(string sql, params object[] parameters);
        int ExecuteSqlCommand(string sql, params object[] parameters);
        IList<dynamic> GetFromSql(string sql, Dictionary<string, object> parameters, bool isStoredProcedure = false);
        DataSet GetDataSetFromSql(string sql, Dictionary<string, object> parameters, bool isStoredProcedure = false);
        (IList<TEntity> Items, int Total, int TotalFilter) GetFromSql(string sql, IList<(string Key, object Value, bool IsOut)> parameters, bool isStoredProcedure = true);
        #endregion
    }
}
