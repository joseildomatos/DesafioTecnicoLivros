using Desafio.Spassu.TJRJ.Application.Interfaces;
using Desafio.Spassu.TJRJ.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Desafio.Spassu.TJRJ.MVC.Controllers
{

    public class AutorController : Controller
    {
        private readonly IAutorApp _autorApp;

        public AutorController(IAutorApp autorApp)
        {
            _autorApp = autorApp;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            return View(await _autorApp.List());
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _autorApp.GetEntityById((int)id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Ativo")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                await _autorApp.Add(autor);

                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _autorApp.GetEntityById((int)id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Autores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ativo,Id,Nome")] Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _autorApp.Update(autor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AutorExists(autor.Id))
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
            return View(autor);
        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _autorApp.GetEntityById((int)id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autor = await _autorApp.GetEntityById(id);
            await _autorApp.Delete(autor);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AutorExists(int id)
        {

            var objeto = await _autorApp.GetEntityById(id);

            return objeto != null;
        }
    }
}
