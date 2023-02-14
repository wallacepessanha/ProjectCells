using Microsoft.AspNetCore.Mvc;
using PCE.Cells.API.Models;
using PCE.Cells.Domain.Contracts.Services;
using PCE.Cells.Domain.Entities;

namespace PCE.Cells.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CellsController : Controller
    {
        private readonly IServiceCell _serviceCell;
        public CellsController(IServiceCell serviceCell)
        {
            _serviceCell = serviceCell;
        }

        [HttpGet("find-all")]
        public IActionResult FindAll()
        {
            var resultado = _serviceCell.FindAll();
            return Ok(resultado);
        }

        [HttpGet("find-by-id/{id}")]
        public IActionResult FindById(int id)
        {
            var resultado = _serviceCell.FindById(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CellModel model)
        {
            var cell = new Cell
            {
                CodOperation = model.CodOperation,
                Name = model.Name,
                IdOperation = model.IdOperation,
                IdStatus = model.IdStatus,
            };

            if (ModelState.IsValid)
            {
                await _serviceCell.Insert(cell);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("update-cell/{id}")]
        public async Task<ActionResult> Update(int id, CellModel model)
        {
            var cell = new Cell
            {
                CodOperation= model.CodOperation,
                Name = model.Name, 
                Id= id,
                IdStatus = model.IdStatus,
                IdOperation = model.IdOperation,
            };

            if (ModelState.IsValid)
            {
                await _serviceCell.Update(cell);
                return Ok();
            }

            return BadRequest();
        }
        [HttpDelete("delete-cell/{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            if(id == 0)
            {
                return BadRequest("Id não informado.");
            }
            var cell = _serviceCell.FindById(id);

            if(cell != null)
            {
                await _serviceCell.Delete(cell);
                return Ok();
            }

            return BadRequest("Cell not found.");
        }
    }
}
