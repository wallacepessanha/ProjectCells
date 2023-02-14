using PCE.Cells.Domain.Entities;

namespace PCE.Cells.Domain.Contracts.Repositories
{
    public interface IRepositoryCell
    {
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
        Task Insert(Cell obj);
        Task Update(Cell obj);
        Task Delete(Cell obj);
        List<Cell> FindAll();
        Cell? FindById(int id);
    }
}
