using Desafio.Spassu.TJRJ.Application.Interfaces;
using Desafio.Spassu.TJRJ.Domain.Entities;
using Desafio.Spassu.TJRJ.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Spassu.TJRJ.Application.Application
{
    public class AppAssunto : IAssuntoApp
    {
        IAssuntoService _assunto;
        public AppAssunto(IAssuntoService assunto)
        {
            _assunto = assunto;
        }

        public async Task<int> Add(Assunto Objeto)
        {
            return await _assunto.Add(Objeto);
        }

        public async Task Delete(Assunto Objeto)
        {
            await _assunto.Delete(Objeto);
        }

        public async Task<Assunto> GetEntityById(int Id)
        {
            return await _assunto.GetEntityById(Id);
        }

        public async Task<List<Assunto>> List()
        {
            return await _assunto.List();
        }

        public async Task Update(Assunto Objeto)
        {
            await _assunto.Update(Objeto);
        }
    }
}
