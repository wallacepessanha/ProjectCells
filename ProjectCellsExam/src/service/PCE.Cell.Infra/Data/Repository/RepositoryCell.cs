using Dapper;
using PCE.Cells.Domain.Contracts.Repositories;
using PCE.Cells.Domain.Entities;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static Dapper.SqlMapper;

namespace PCE.Cells.Infra.Data.Repository
{
    public class RepositoryCell
        : IRepositoryCell
    {
        protected string ConnectionString { get; set; }
        protected DbTransaction Tr;
        protected SqlConnection Con;

        public RepositoryCell(string connectionString)
        {
            ConnectionString = connectionString;
            Con = new SqlConnection(ConnectionString);
        }

        public async Task BeginTransaction()
        {     
            if(Con.State == System.Data.ConnectionState.Closed) {
                Con = new SqlConnection(ConnectionString);
            }
            Tr = await Con.BeginTransactionAsync();
        }

        public async Task Commit()
        {            
            await Tr.CommitAsync();
        }

        public async Task Rollback()
        {            
            await Tr.RollbackAsync();
        }

        public async Task Insert(Cell obj)
        {
            var query = "insert into Cell(Name, IdOperation, IdStatus, CodOperation) "
                      + "values(@Name, @IdOperation, @IdStatus, @CodOperation)";
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(query, obj);
            }
        }

        public async Task Update(Cell obj)
        {
            var query = "update Cell set Name = @Name, IdOperation = @IdOperation, IdStatus = @IdStatus, CodOperation = @CodOperation "
                      + "where Id = @Id";

            await Con.ExecuteAsync(query, obj);
        }

        public async Task Delete(Cell obj)
        {
            var query = "delete from Cell where Id = @Id";

            await Con.ExecuteAsync(query, obj);
        }

        public List<Cell> FindAll()
        {
            var query = "select * from Cell";

            return Con.Query<Cell>(query).ToList();
        }

        public Cell? FindById(int id)
        {
            var query = "select * from cell where Id = @Id";

            return Con.Query<Cell>
            (query, new { Id = id }).FirstOrDefault();
        }
    }
}
