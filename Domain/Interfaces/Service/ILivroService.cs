using Desafio.Spassu.TJRJ.Domain.Entities;
using Desafio.Spassu.TJRJ.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Spassu.TJRJ.Domain.Interfaces.Service
{
    public interface ILivroService : IGenericService<Livro>
    {
        Task<List<LivroAssuntosResponse>> GetLivroAssuntosByLivroId(int livroId);
        Task DeleteAndAddLivroAssuntosByLivroId(int livroId, List<LivroAssuntosResponse> assuntos);

        Task<List<LivroAutoresResponse>> GetLivroAutoresByLivroId(int autorId);
        Task DeleteAndAddLivroAutoresByLivroId(int autorId, List<LivroAutoresResponse> autores);

        Task<List<RelatorioLivros>> ReportLivros();
    }
}
