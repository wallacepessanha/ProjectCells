using Microsoft.AspNetCore.Mvc;
using PCE.WebApp.MVC.Models;
using PCE.WebApp.MVC.Services.Contracts;
using System.Buffers;
using System.Diagnostics;

namespace PCE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {        
        private readonly ICellService _cellService;

        public HomeController(ICellService cellService)
        {            
            _cellService = cellService;
        }

        [Route("lista-de-celulas")]
        public async Task<IActionResult> Index()
        {
            var listCell = await _cellService.FindAll();
            return View(listCell);
        }

        [Route("nova-celula")]
        public IActionResult Create()
        {
            var viewModel = new CellViewModel();
            SetOperations(viewModel);
            SetStatus(viewModel);

            return View(viewModel);           
        }

        [Route("detail/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var cellViewModel = await _cellService.FindById(id);

            if (cellViewModel == null)
            {
                return NotFound();
            }

            return View(cellViewModel);
        }

        [Route("nova-celula")]
        [HttpPost]
        public async Task<IActionResult> Create(CellViewModel cellViewModel)
        {
            if (!ModelState.IsValid) return View(cellViewModel);
            
            await _cellService.InsertCell(cellViewModel);            

            return RedirectToAction("Index");
        }

        [Route("update-cell/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var cellViewModel = await _cellService.FindById(id);

            if (cellViewModel == null)
            {
                return NotFound();
            }

            SetOperations(cellViewModel);
            SetStatus(cellViewModel);

            return View(cellViewModel);
        }
                
        [Route("update-cell/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CellViewModel cellViewModel)
        {
            if (id != cellViewModel.Id) return NotFound();

            var cellAtualizacao = await _cellService.FindById(id);
            
            if (!ModelState.IsValid) return View(cellViewModel);            

            cellAtualizacao.Name = cellViewModel.Name;
            cellAtualizacao.IdStatus = cellViewModel.IdStatus;
            cellAtualizacao.IdOperation = cellViewModel.IdOperation;
            cellAtualizacao.CodOperation = cellViewModel.CodOperation;

            await _cellService.UpdateCell(id, cellAtualizacao);            

            return RedirectToAction("Index");
        }


        [Route("delete-cell/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cell = await _cellService.FindById(id);

            if (cell == null)
            {
                return NotFound();
            }

            return View(cell);
        }
        
        [Route("delete-cell/{id:int}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cell = await _cellService.FindById(id);

            if (cell == null)
            {
                return NotFound();
            }

            await _cellService.DeleteCell(id);            

            //TempData["Sucesso"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private CellViewModel SetOperations(CellViewModel model)
        {
            model.Operations = Operation.ListComboOperation();
            return model;
        }

        private CellViewModel SetStatus(CellViewModel model)
        {
            model.listStatus = Status.ListComboStatus();
            return model;
        }
    }
}