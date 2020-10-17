using Architecture.Core.Common.Extensions;
using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Architecture.Core.Repository.Extensions;
using Architecture.Core.Repository.Interfaces;
using Architecture.BLL.Services.Exceptions;
using Architecture.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements
{
    public class ExampleService : IExampleService
    {        
        private readonly IExampleUnitOfWork _exampleUnitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;


        public ExampleService(
            IExampleUnitOfWork exampleUnitOfWork,
            ICurrentUserService currentUserService,
            IDateTime dateTime
            )
        {
            _exampleUnitOfWork = exampleUnitOfWork;
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public async Task<QueryResult<Example>> GetAllAsync(ExampleQuery queryObj)
        {
            var queryResult = new QueryResult<Example>();

            var columnsMap = new Dictionary<string, Expression<Func<Example, object>>>()
            {
                ["name"] = v => v.Name,
            };

            var result = await _exampleUnitOfWork.ExampleRepository.GetWithFilterAsync(x => x,
                            x => (string.IsNullOrEmpty(queryObj.Name) || x.Name.Contains(queryObj.Name)),
                            x => x.ApplyOrdering(columnsMap, queryObj.SortBy, queryObj.IsSortAscending),
                            null, queryObj.Page, queryObj.PageSize);           

            queryResult.Items = result.Items;
            queryResult.Total = result.Total;
            queryResult.TotalFilter = result.TotalFilter;

            return queryResult;
        }

        public async Task<IList<Example>> GetAllActiveAsync()
        {
            return (await _exampleUnitOfWork.ExampleRepository.GetAsync(x => x,
                x => x.IsActive && !x.IsDeleted, x => x.OrderBy(o => o.Name), null, true));
        }

        public async Task<Example> GetByIdAsync(int id)
        {
            var entity = await _exampleUnitOfWork.ExampleRepository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Example), id);
            }

            return entity;
        }

        public async Task<int> AddAsync(Example entity)
        {
            //var isExist = await this.IsExistsNameAsync(entity.Name, entity.Id);
            //if (isExist)
            //    throw new DuplicationException(nameof(entity.Name));

            entity.Created = _dateTime.Now;
            entity.CreatedBy = _currentUserService.UserId;

            await _exampleUnitOfWork.ExampleRepository.AddAsync(entity);
            var result = await _exampleUnitOfWork.SaveChangesAsync();

            if (result == true)
            {
                return entity.Id;
            }
            else
            {
                throw new Exception("Failed to add Example");
            }
        }

        public async Task<int> UpdateAsync(Example entity)
        {
            //var isExist = await this.IsExistsNameAsync(entity.Name, entity.Id);
            //if (isExist)
            //    throw new DuplicationException(nameof(entity.Name));

            var existingEntity = await _exampleUnitOfWork.ExampleRepository.GetByIdAsync(entity.Id);
            if (existingEntity == null) throw new NotFoundException(nameof(Example), entity.Id);

            existingEntity.Name = entity.Name;
            existingEntity.Description = entity.Description;
            existingEntity.Sequence = entity.Sequence;
            existingEntity.IsActive = entity.IsActive;
            existingEntity.ImageUrl = string.IsNullOrWhiteSpace(entity.ImageUrl) ? existingEntity.ImageUrl : entity.ImageUrl;

            existingEntity.Modified = _dateTime.Now;
            existingEntity.ModifiedBy = _currentUserService.UserId;

            await _exampleUnitOfWork.ExampleRepository.UpdateAsync(existingEntity);
            var result = await _exampleUnitOfWork.SaveChangesAsync();

            if (result == true)
            {
                return entity.Id;
            }
            else
            {
                throw new Exception("Failed to update Example");
            }
        }

        public Task<bool> ActiveInactiveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _exampleUnitOfWork.ExampleRepository.DeleteAsync(id);
            var result = await _exampleUnitOfWork.SaveChangesAsync();

            if (result == true)
            {
                return true;
            }
            else
            {
                throw new Exception("Failed to delete Example");
            }
        }

        public async Task<bool> IsExistsNameAsync(string name, int id)
        {
            var result = await _exampleUnitOfWork.ExampleRepository.IsExistsAsync(x =>
                            (x.Name.ToLower() == name.ToLower()) && x.Id != id && !x.IsDeleted);
            return result;
        }

        public void Dispose()
        {
            _exampleUnitOfWork.Dispose();
        }
    }
}
