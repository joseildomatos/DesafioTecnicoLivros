using Desafio.Spassu.TJRJ.Domain.Entities;
using Desafio.Spassu.TJRJ.Domain.Interfaces.Service;
using Desafio.Spassu.TJRJ.Domain.Response;
using Desafio.Spassu.TJRJ.Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Spassu.TJRJ.Infrastructure.Repository;

public class LivroRepository : GenericRepository<Livro>, ILivroService
{
    private readonly DbContextOptions<AppDbContext> _OptionsBuilder;

    public LivroRepository()
    {
        _OptionsBuilder = new DbContextOptions<AppDbContext>();
    }

    public async Task DeleteAndAddLivroAssuntosByLivroId(int livroId, List<LivroAssuntosResponse> assuntos)
    {
        using var context = new AppDbContext(_OptionsBuilder);
        context.LivroAssunto.RemoveRange(context.LivroAssunto.Where(b => b.LivroId == livroId).AsEnumerable());

        foreach (var item in assuntos.Where(x => x.Checked))                 
        context.LivroAssunto.Add(new LivroAssunto()
        {
            LivroId = livroId,
            AssuntoId = item.AssuntoId
        });

        await context.SaveChangesAsync();
    
    }

    public async Task<List<LivroAssuntosResponse>> GetLivroAssuntosByLivroId(int livroIdParam)
    {
        using var context = new AppDbContext(_OptionsBuilder);
        var assuntos = from assunto in context.Assunto
                       select new LivroAssuntosResponse
                       {
                           AssuntoId = assunto.Id,
                           Descricao = assunto.Descricao,
                           Checked = ((from la in context.LivroAssunto
                                       where (la.LivroId == livroIdParam) && (la.AssuntoId == assunto.Id)
                                       select la).Count() > 0)
                       };

        return assuntos.ToList();
    }


    public async Task DeleteAndAddLivroAutoresByLivroId(int autorId, List<LivroAutoresResponse> assuntos)
    {
        using var context = new AppDbContext(_OptionsBuilder);
        context.LivroAutor.RemoveRange(context.LivroAutor.Where(b => b.AutorId == autorId).AsEnumerable());

        foreach (var item in assuntos.Where(x => x.Checked))
            context.LivroAutor.Add(new LivroAutor()
            {
                LivroId = autorId,
                AutorId = item.AutorId
            });

        await context.SaveChangesAsync();

    }

    public async Task<List<LivroAutoresResponse>> GetLivroAutoresByLivroId(int livroIdParam)
    {
        using var context = new AppDbContext(_OptionsBuilder);
        var autores = from autor in context.Autor
                       select new LivroAutoresResponse
                       {
                           AutorId = autor.Id,
                           Nome = autor.Nome,
                           Checked = ((from la in context.LivroAutor
                                       where (la.LivroId == livroIdParam) && (la.AutorId == autor.Id)
                                       select la).Count() > 0)
                       };

        return autores.ToList();

    }

    public async Task<List<RelatorioLivros>> ReportLivros()
    {
        using var context = new AppDbContext(_OptionsBuilder);
        return await context.Set<RelatorioLivros>().AsNoTracking().ToListAsync();         
    }

}

