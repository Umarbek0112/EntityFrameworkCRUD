using System;
using WpfTemplateApp.Domain.Commons;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WpfTemplateApp.Domain.Configurations;
using WpfTemplateApp.Domain.Entities.Teachers;

namespace WpfTemplateApp.Data.IRepository;

public interface IGenericRepository<T> where T : Auditable
{
    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isTracking = true);
    public Task<T> GetAsync(Expression<Func<T, bool>> expression, bool isTracking = true);
    public Task<T> CreateAsync(T entity);
    public Task<bool> DeleteAsync(int id);
    public T Update(T entity);
    public Task SaveChangesAsync();
}