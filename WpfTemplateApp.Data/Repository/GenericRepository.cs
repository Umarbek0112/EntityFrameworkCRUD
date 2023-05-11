using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfTemplateApp.Data.DbContexs;
using WpfTemplateApp.Data.IRepository;
using WpfTemplateApp.Domain.Commons;

namespace WpfTemplateApp.Data.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
{
    private readonly WpfTemplateAppDbContex _dbContex;
    private readonly DbSet<T> _dbSet;
    
    public GenericRepository()
    {
        _dbContex = new WpfTemplateAppDbContex();
        _dbSet = _dbContex.Set<T>();
    }
  public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isTracking = true)
  {
        var entity = expression is null ? _dbSet : _dbSet.Where(expression);
        
        if (!isTracking)
            _dbSet.AsNoTracking();

        return entity;
    }
    public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool isTracking = true)
        => await GetAll(expression, isTracking).FirstOrDefaultAsync();

    public async Task<T> CreateAsync(T entity) 
        => (await _dbSet.AddAsync(entity)).Entity;

    public async Task<bool> DeleteAsync(int id)
    {
         var entity = await GetAsync(x => x.Id == id);
         if (entity == null)
             return false;

         _dbSet.Remove(entity);
         return true;
    }

    public T Update(T entity)
        => _dbSet.Update(entity).Entity;

    public async Task SaveChangesAsync()
        => await _dbContex.SaveChangesAsync();
}

