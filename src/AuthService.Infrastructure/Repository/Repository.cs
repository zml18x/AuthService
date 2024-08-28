using Microsoft.EntityFrameworkCore;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Data.Context;
using AuthService.Application.Exceptions;

namespace AuthService.Infrastructure.Repository;

public class Repository<TEntity>(AppDbContext context) : IRepository<TEntity> where TEntity : class
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await context.Set<TEntity>().ToListAsync();
    
    public async Task<TEntity> GetByIdAsync(Guid entityId)
    {
        var entity = await context.Set<TEntity>().FindAsync(entityId);
        if(entity == null)
            throw new NotFoundException($"{typeof(TEntity).Name} with ID {entityId} was not found.");
    
        return entity;
    }
    
    public async Task CreateAsync(TEntity entity)
    {
        CheckEntityIsNull(entity);
        await context.Set<TEntity>().AddAsync(entity);
    }
    
    public void Update(TEntity entity)
    {
        CheckEntityIsNull(entity);
        context.Update(entity);
    }
    
    public void Delete(TEntity entity)
    {
        CheckEntityIsNull(entity);
        context.Remove(entity);
    }
    
    public async Task SaveChangesAsync()
        => await context.SaveChangesAsync();
    
    private void CheckEntityIsNull(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), $"{nameof(entity)} cannot be null");
    }
}