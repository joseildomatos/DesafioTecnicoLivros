using Desafio.Spassu.TJRJ.Application.Interfaces;
using Desafio.Spassu.TJRJ.Domain.Entities;
using Desafio.Spassu.TJRJ.Domain.Interfaces.Service;
using Desafio.Spassu.TJRJ.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Spassu.TJRJ.Application.Application
{
    public class AppLivro : ILivroApp
    {
        private ILivroService _livro;
        public AppLivro(ILivroService livro)
        {
            _livro = livro;
        }

        public async Task<int> Add(Livro Objeto)
        {
            return await _livro.Add(Objeto);
        }

        public async Task Delete(Livro Objeto)
        {
            await _livro.Delete(Objeto);
        }

        public async Task DeleteAndAddLivroAssuntosByLivroId(int livroId, List<LivroAssuntosResponse> assuntos)
        {
            await _livro.DeleteAndAddLivroAssuntosByLivroId(livroId, assuntos);
        }

        public async Task DeleteAndAddLivroAutoresByLivroId(int autorId, List<LivroAutoresResponse> autores)
        {
            await _livro.DeleteAndAddLivroAutoresByLivroId(autorId, autores);
        }

        public async Task<List<RelatorioLivros>> ReportLivros()
        {
            return await _livro.ReportLivros();
        }

        public async Task<Livro> GetEntityById(int Id)
        {
            return await _livro.GetEntityById(Id);
        }

        public async Task<List<LivroAssuntosResponse>> GetLivroAssuntosByLivroId(int livroId)
        {
          return await _livro.GetLivroAssuntosByLivroId(livroId);
        }

        public async Task<List<LivroAutoresResponse>> GetLivroAutoresByLivroId(int autorId)
        {
            return await _livro.GetLivroAutoresByLivroId(autorId);
        }

        public async Task<List<Livro>> List()
        {
            return await _livro.List();
        }

        public async Task Update(Livro Objeto)
        {
            await _livro.Update(Objeto);
        }
    }
}
