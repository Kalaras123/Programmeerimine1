using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;
using KooliProjekt.Models;
using KooliProjekt.Services;
using KooliProjekt.Search;

namespace KooliProjekt.Controllers
{
    public class OperationsController : Controller
    {
        private readonly IOperationService _operationService;

        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        // GET: Operations
        public async Task<IActionResult> Index(OperationsIndexModel model = null)
        {
            model = model ?? new OperationsIndexModel();
            model.Data = await _operationService.AllOperations(model.Search);
            return View(model);
        }

        // GET: Operations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operation = await _operationService.GetWithIncludes(id.Value);
            if (operation == null)
            {
                return NotFound();
            }

            return View(operation);
        }

        // GET: Operations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Action,OperationDate,Cost,WorkerId,StatusId,CarId")] Operation operation)
        {
            ModelState.Remove("Worker");
            ModelState.Remove("Status");
            ModelState.Remove("Car");
            if (ModelState.IsValid)
            {
                await _operationService.Save(operation);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(await _operationService.GetCars(), "Id", "Mark", operation?.CarId);
            ViewData["StatusId"] = new SelectList(await _operationService.GetStatuses(), "Id", "StatusType", operation?.StatusId);
            ViewData["WorkerId"] = new SelectList(await _operationService.GetWorkers(), "Id", "WorkerName", operation?.WorkerId);
            return View(operation);
        }

        // GET: Operations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operation = await _operationService.GetWithIncludes(id.Value);
            if (operation == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(await _operationService.GetCars(), "Id", "Mark", operation?.CarId);
            ViewData["StatusId"] = new SelectList(await _operationService.GetStatuses(), "Id", "StatusType", operation?.StatusId);
            ViewData["WorkerId"] = new SelectList(await _operationService.GetWorkers(), "Id", "WorkerName", operation?.WorkerId);
            return View(operation);
        }

        // POST: Operations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Action,OperationDate,Cost,WorkerId,StatusId,CarId")] Operation operation)
        {
            if (id != operation.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Worker");
            ModelState.Remove("Status");
            ModelState.Remove("Car");
            if (ModelState.IsValid)
            {
                await _operationService.Save(operation);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(await _operationService.GetCars(), "Id", "Mark", operation?.CarId);
            ViewData["StatusId"] = new SelectList(await _operationService.GetStatuses(), "Id", "StatusType", operation?.StatusId);
            ViewData["WorkerId"] = new SelectList(await _operationService.GetWorkers(), "Id", "WorkerName", operation?.WorkerId);
            return View(operation);
        }

        // GET: Operations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operation = await _operationService.GetWithIncludes(id.Value);
            if (operation == null)
            {
                return NotFound();
            }

            return View(operation);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _operationService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
