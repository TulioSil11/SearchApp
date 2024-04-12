using Microsoft.EntityFrameworkCore;
using SearchApp.Interfaces.Repositories;
using SearchApp.Models;
using SearchApp.Models.Context;
using System;
using System.Linq.Expressions;

namespace SearchApp.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
{
    private MyContext m_Context = null;
    DbSet<T> m_DbSet;

    public RepositoryBase(MyContext context)
    {
        m_Context = context;
        m_DbSet = m_Context.Set<T>();
    }

    public void Commit()
    {
        m_Context.SaveChanges();
    }

    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null)
    {
        IEnumerable<T> data = null;
        try
        {
            data = predicate is not null ? await m_DbSet.Where(predicate).ToListAsync() :
                                 await m_DbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return data;
    }

    public T GetById(Guid id)
    {
        T product = null;
        try
        {
            product = m_DbSet.FirstOrDefault(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return product;
    }

    public void Post(T entity)
    {
        try
        {
            m_DbSet.Add(entity);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    public void Put(T entity)
    {
        try
        {
            m_DbSet.Update(entity);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var product = await m_DbSet.FirstOrDefaultAsync(x  => x.Id == id);
            if (product is not null)
            {
                m_DbSet.Remove(product);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
