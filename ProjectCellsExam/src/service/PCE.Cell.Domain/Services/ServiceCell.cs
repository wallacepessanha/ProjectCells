using PCE.Cells.Domain.Contracts.Repositories;
using PCE.Cells.Domain.Contracts.Services;
using PCE.Cells.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cells.Domain.Services
{
    public class ServiceCell
        : IServiceCell
    {
        private readonly IRepositoryCell repository;

        //construtor para injeção de dependencia..
        public ServiceCell(IRepositoryCell repository)
        {
            this.repository = repository;
        }

        public async Task Insert(Cell obj)
        {
            try
            {                
                await repository.Insert(obj);                
            }
            catch (Exception e)
            {                
                throw new Exception(e.Message);
            }
        }

        public async Task Update(Cell obj)
        {
            try
            {                
                await repository.Update(obj);                
            }
            catch (Exception e)
            {               
                throw new Exception(e.Message);
            }
        }

        public async Task Delete(Cell obj)
        {
            try
            {
                
                await repository.Delete(obj);
                
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public Cell FindById(int id)
        {
            try
            {
                return repository.FindById(id)!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Cell> FindAll()
        {
            try
            {
                return repository.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
