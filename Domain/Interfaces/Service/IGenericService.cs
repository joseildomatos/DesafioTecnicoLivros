using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Spassu.TJRJ.Domain.Interfaces.Service
{
    public interface IGenericService<T> where T : class
    {
        Task<int> Add(T Objeto);
        Task Update(T Objeto);
        Task Delete(T Objeto);
        Task<T> GetEntityById(int Id);
        Task<List<T>> List();
    }
}
