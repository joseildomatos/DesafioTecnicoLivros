using Desafio.Spassu.TJRJ.Application.Interfaces;
using Desafio.Spassu.TJRJ.Domain.Entities;
using Desafio.Spassu.TJRJ.Domain.Response;
using Desafio.Spassu.TJRJ.MVC.Models;
using FastReport;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace Desafio.Spassu.TJRJ.MVC.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroApp _livroApp;
        public readonly IWebHostEnvironment _webHostEnv;

        public LivroController(ILivroApp livroApp, IWebHostEnvironment webHostEnv)
        {
            _livroApp = livroApp;
            _webHostEnv = webHostEnv;
        }

        // GET: Livroes
        public async Task<IActionResult> Index()
        {
            return View(await _livroApp.List());
        }

        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _livroApp.GetEntityById((int)id);
            if (livro == null)
            {
                return NotFound();
            }

            var LivroAssuntoViewModel = new LivroAssuntosAutoresViewModel
            {
                LivroId = id.Value,
                Titulo = livro.Titulo,
                Editora = livro.Editora,
                Edicao = livro.Edicao,
                AnoPublicacao = livro.AnoPublicacao,
                Ativo = livro.Ativo,
                Preco = livro.Preco,
                Assuntos = await _livroApp.GetLivroAssuntosByLivroId((int)id),
                Autores = await _livroApp.GetLivroAutoresByLivroId((int)id)
            };

            return View(LivroAssuntoViewModel);
        }

        // GET: Livro/Create
        public async Task<IActionResult> Create()
        {
            var LivroAssuntoViewModel = new LivroAssuntosAutoresViewModel { 
                Assuntos = await  _livroApp.GetLivroAssuntosByLivroId(0),
                Autores = await _livroApp.GetLivroAutoresByLivroId(0)
            };

            return View(LivroAssuntoViewModel);
        }

        // POST: Livro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,LivroId, Assuntos, Autores, Editora,Edicao,Preco,AnoPublicacao,Ativo")] LivroAssuntosAutoresViewModel livro)
        {
            if (ModelState.IsValid)
            {
                var livroId = await _livroApp.Add(new Livro()
                {
                    Titulo = livro.Titulo,
                    Editora = livro.Editora,
                    Edicao = livro.Edicao,
                    AnoPublicacao = livro.AnoPublicacao,
                    Ativo = livro.Ativo,
                    Preco = livro.Preco
                });

                await _livroApp.DeleteAndAddLivroAssuntosByLivroId(livroId, livro.Assuntos);
                await _livroApp.DeleteAndAddLivroAutoresByLivroId(livroId, livro.Autores);

                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
        
            if (id == null)
            {
                return NotFound();
            }

            var livro  = await _livroApp.GetEntityById((int)id);
            if (livro == null)
            {
                return NotFound();
            }           

            var LivroAssuntoViewModel = new LivroAssuntosAutoresViewModel
            {
                LivroId = id.Value,
                Titulo = livro.Titulo,
                Editora = livro.Editora,
                Edicao = livro.Edicao,
                AnoPublicacao = livro.AnoPublicacao,
                Ativo = livro.Ativo,
                Preco = livro.Preco,
                Assuntos = await _livroApp.GetLivroAssuntosByLivroId((int)id),
                Autores = await _livroApp.GetLivroAutoresByLivroId((int)id)
            };

            return View(LivroAssuntoViewModel);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LivroId, Assuntos, Autores, Titulo,Editora,Edicao,Preco,AnoPublicacao,Ativo")] LivroAssuntosAutoresViewModel livro)
        {
            if (id != livro.LivroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                try
                {
                    var livroSelecionado = await _livroApp.GetEntityById(id);

                    livroSelecionado.Titulo = livro.Titulo;
                    livroSelecionado.Editora = livro.Editora;
                    livroSelecionado.Edicao = livro.Edicao;
                    livroSelecionado.AnoPublicacao = livro.AnoPublicacao;
                    livroSelecionado.Ativo = livro.Ativo;
                    livroSelecionado.Preco = livro.Preco;

                    await _livroApp.Update(livroSelecionado);

                    await _livroApp.DeleteAndAddLivroAssuntosByLivroId(id, livro.Assuntos);
                    await _livroApp.DeleteAndAddLivroAutoresByLivroId(id, livro.Autores);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LivroExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        // GET: Livroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _livroApp.GetEntityById((int)id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _livroApp.GetEntityById(id);
            await _livroApp.Delete(livro);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LivroExists(int id)
        {
            var objeto = await _livroApp.GetEntityById(id);

            return objeto != null;
        }

        //[Route("CreateReport")]
        public async Task<FileResult> CreateReport()
        {

            List<RelatorioLivros> livrosList = [];

            InstanceInitialReportToTJRJMvc(out string reportFile, out Report webReport, out string caminhoReport);
            if (!System.IO.File.Exists(caminhoReport))
            {
                livrosList = await _livroApp.ReportLivros();

                webReport.Report.RegisterData(livrosList, "livrosList");
                //webReport.Dictionary.RegisterBusinessObject(livrosList, "livrosList", 10, true);
                webReport.Report.Save(reportFile);
            }

            livrosList = await _livroApp.ReportLivros();

            webReport.Report.Load(reportFile);
            webReport.Report.RegisterData(livrosList, "Products");
            webReport.Report.Prepare();
          
            using MemoryStream stream = new();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Flush();

            return File(stream.ToArray(), "application/pdf","Relatorio de livros.pdf");

        }

        private void InstanceInitialReportToTJRJMvc(out string reportFile, out Report webReport, out string caminhoReport)
        {
            caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportLivrosTJRJMvc.frx");            
            reportFile = caminhoReport;
            webReport = new Report();
        }
    }
}
