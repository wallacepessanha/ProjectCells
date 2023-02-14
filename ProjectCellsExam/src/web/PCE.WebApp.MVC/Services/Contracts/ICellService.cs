using PCE.WebApp.MVC.Models;

namespace PCE.WebApp.MVC.Services.Contracts
{
    public interface ICellService
    {
        Task<CellViewModel?> FindById(int Id);
        Task<IEnumerable<CellViewModel>>? FindAll();
        Task InsertCell(CellViewModel cellViewModel);
        Task UpdateCell(int id, CellViewModel cellViewModel);
        Task DeleteCell(int id);
    }
}
