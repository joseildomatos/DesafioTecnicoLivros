using Desafio.Spassu.TJRJ.Application.Interfaces;
using Desafio.Spassu.TJRJ.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Desafio.Spassu.TJRJ.MVC.Controllers
{

    public class AssuntoController : Controller
    {
        private readonly IAssuntoApp _assuntoApp;

        public AssuntoController(IAssuntoApp assuntoApp)
        {
            _assuntoApp = assuntoApp;
        }

        // GET: Assuntoes
        public async Task<IActionResult> Index()
        {
            return View(await _assuntoApp.List());
        }

        // GET: Assuntoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _assuntoApp.GetEntityById((int)id);
            if (assunto == null)
            {
                return NotFound();
            }

            return View(assunto);
        }

        // GET: Assuntoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assuntoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Ativo")] Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                await _assuntoApp.Add(assunto);

                return RedirectToAction(nameof(Index));
            }
            return View(assunto);
        }

        // GET: Assuntoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _assuntoApp.GetEntityById((int)id);
            if (assunto == null)
            {
                return NotFound();
            }
            return View(assunto);
        }

        // POST: Assuntoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ativo,Id,Descricao")] Assunto assunto)
        {
            if (id != assunto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _assuntoApp.Update(assunto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AssuntoExists(assunto.Id))
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
            return View(assunto);
        }

        // GET: Assuntoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _assuntoApp.GetEntityById((int)id);
            if (assunto == null)
            {
                return NotFound();
            }

            return View(assunto);
        }

        // POST: Assuntoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assunto = await _assuntoApp.GetEntityById(id);
            await _assuntoApp.Delete(assunto);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AssuntoExists(int id)
        {

            var objeto = await _assuntoApp.GetEntityById(id);

            return objeto != null;
        }
    }
}
