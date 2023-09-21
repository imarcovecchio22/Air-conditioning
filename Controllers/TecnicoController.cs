using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto2.Data;

namespace Proyecto2.Controllers
{
    public class TecnicoController : Controller
    {
        private ITecnicoServices _tecnicoServices;
        public TecnicoController(ITecnicoServices tecnicoServices)
        {
            _tecnicoServices =tecnicoServices;
        }

        // GET: Tecnico
        public async Task<IActionResult> Index(string nameFilter)
        {
            var model = new TecnicoViewModel();
            model.Tecnicos=_tecnicoServices.QuerySearch(nameFilter);
            return View(model);
        }

        // GET: Tecnico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnico = _tecnicoServices.GetById(id.Value);
            if (tecnico == null)
            {
                return NotFound();
            }

            return View(tecnico);
        }

        // GET: Tecnico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tecnico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Edad,Genero,Especializacion,Ubicacion")] TecnicoCreateViewModel tecnicoCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var tecnico = new Tecnico{
                    Id=tecnicoCreateViewModel.Id,
                    Nombre=tecnicoCreateViewModel.Nombre,
                    Apellido=tecnicoCreateViewModel.Apellido,
                    Edad=tecnicoCreateViewModel.Edad,
                    Genero=tecnicoCreateViewModel.Genero,
                    Especializacion=tecnicoCreateViewModel.Especializacion,
                    Ubicacion=tecnicoCreateViewModel.Ubicacion
                };
                _tecnicoServices.Create(tecnico);
                return RedirectToAction(nameof(Index));
            }
            return View(tecnicoCreateViewModel);
        }

        // GET: Tecnico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnico = _tecnicoServices.GetById(id.Value);
            if (tecnico == null)
            {
                return NotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Edad,Genero,Especializacion,Ubicacion")] TecnicoCreateViewModel tecnicoViewModel)
        {
            if (id != tecnicoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var tecnico = new Tecnico{
                    Id=tecnicoViewModel.Id,
                    Nombre=tecnicoViewModel.Nombre,
                    Apellido=tecnicoViewModel.Apellido,
                    Edad=tecnicoViewModel.Edad,
                    Genero=tecnicoViewModel.Genero,
                    Especializacion=tecnicoViewModel.Especializacion,
                    Ubicacion=tecnicoViewModel.Ubicacion
                };
                _tecnicoServices.Update(tecnico);
                return RedirectToAction(nameof(Index));
            }
            return View(tecnicoViewModel);
        }

        // GET: Tecnico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var tecnico = _tecnicoServices.GetById(id.Value);
            if (tecnico == null)
            {
                return NotFound();
            }

            return View(tecnico);
        }

        // POST: Tecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var tecnico = _tecnicoServices.GetById(id);
            if (tecnico != null)
            {
                _tecnicoServices.Delete(tecnico);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicoExists(int id)
        {
            return _tecnicoServices.GetById(id) != null;
        }
    }
}
