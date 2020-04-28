using ManagementSystem.Domain.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Application.Dapper.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Delete(int id);
        Task<int> Update(T entity);
    }
}
