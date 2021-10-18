using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchandisingManagement.Domain.Entities;
using MerchandisingManagement.Domain.Repositories;
using MerchandisingManagement.Domain.Specifications;
using MerchandisingManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MerchandisingManagement.Infrastructure.Repository.Base
{
	public class BaseRepository<T> :IBaseRepository<T> where T: BaseEntity
	{
		protected readonly MerchandisingManagementContext _merchandisingManagementContext;

		public BaseRepository(MerchandisingManagementContext merchandisingManagementContext)
		{
			_merchandisingManagementContext = merchandisingManagementContext;
		}

		public async Task<T> AddAsync(T entity)
		{
			await _merchandisingManagementContext.Set<T>().AddAsync(entity);
			await _merchandisingManagementContext.SaveChangesAsync();
			return entity;
		}

		public async Task DeleteAsync(T entity)
		{
			_merchandisingManagementContext.Set<T>().Remove(entity);
			await _merchandisingManagementContext.SaveChangesAsync();
		}


		public async Task<IReadOnlyList<T>> GetAllAsync()
		{
			return await _merchandisingManagementContext.Set<T>().ToListAsync();
		}

		public async Task<IReadOnlyList<T>> GetAsync(IBaseSpecification<T> spec)
		{
			return await ApplySpecification(spec).ToListAsync();

		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _merchandisingManagementContext.Set<T>().FindAsync(id);
		}

		public async Task UpdateAsync(T entity)
		{
			 _merchandisingManagementContext.Entry(entity).State = EntityState.Modified;
			 await _merchandisingManagementContext.SaveChangesAsync();
		}

		private IQueryable<T> ApplySpecification(IBaseSpecification<T> spec)
		{
			return SpecificationEvaluator<T>.GetQuery(_merchandisingManagementContext.Set<T>().AsQueryable(), spec);
		}

	}
}
