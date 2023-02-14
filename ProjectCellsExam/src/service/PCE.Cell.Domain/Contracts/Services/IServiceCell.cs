using PCE.Cells.Domain.Entities;

namespace PCE.Cells.Domain.Contracts.Services
{
    public interface IServiceCell
    {
        Task Insert(Cell obj);

        Task Update(Cell obj);

        Task Delete(Cell obj);

        List<Cell> FindAll();

        Cell FindById(int id);
    }
}
