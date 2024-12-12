using Desafio.Spassu.TJRJ.Application.Interfaces;
using Desafio.Spassu.TJRJ.Domain.Entities;
using Desafio.Spassu.TJRJ.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Spassu.TJRJ.Application.Application
{
    public class AppAutor : IAutorApp
    {
        IAutorService _autor;
        public AppAutor(IAutorService autor)
        {
            _autor = autor;
        }

        public async Task<int> Add(Autor Objeto)
        {
            return await _autor.Add(Objeto);
        }

        public async Task Delete(Autor Objeto)
        {
            await _autor.Delete(Objeto);
        }

        public async Task<Autor> GetEntityById(int Id)
        {
            return await _autor.GetEntityById(Id);
        }

        public async Task<List<Autor>> List()
        {
            return await _autor.List();
        }

        public async Task Update(Autor Objeto)
        {
            await _autor.Update(Objeto);
        }
    }
}
