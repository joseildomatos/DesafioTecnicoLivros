using Desafio.Spassu.TJRJ.Domain.Interfaces.Service;
using Desafio.Spassu.TJRJ.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Spassu.TJRJ.Infrastructure.Repository;

public class GenericRepository<T> : IGenericService<T>, IDisposable where T : class
{
    private readonly DbContextOptions<AppDbContext> _OptionsBuilder; 

    public GenericRepository()
    {
        _OptionsBuilder = new DbContextOptions<AppDbContext>();
    }

    public async Task<int> Add(T Objeto)
    {
        using (var data = new AppDbContext(_OptionsBuilder))
        {
            await data.Set<T>().AddAsync(Objeto);
            await data.SaveChangesAsync();

            var Id = Objeto.GetType().GetProperty("Id").GetValue(Objeto, null);
            return (int)Id;

        }
    }

    public async Task Delete(T Objeto)
    {
        using (var data = new AppDbContext(_OptionsBuilder))
        {
            data.Set<T>().Remove(Objeto);
            await data.SaveChangesAsync();
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetEntityById(int Id)
    {
        using (var data = new AppDbContext(_OptionsBuilder))
        {
            return await data.Set<T>().FindAsync(Id);
        }
    }

    public async Task<List<T>> List()
    {
        using (var data = new AppDbContext(_OptionsBuilder))
        {
            return await data.Set<T>().AsNoTracking().ToListAsync();
        }
    }

    public async Task Update(T Objeto)
    {
        using (var data = new AppDbContext(_OptionsBuilder))
        {
            data.Set<T>().Update(Objeto);
            await data.SaveChangesAsync();
        }
    }


}

