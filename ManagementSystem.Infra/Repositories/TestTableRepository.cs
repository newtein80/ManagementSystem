using ManagementSystem.Application.Dapper.Interface;
using ManagementSystem.Domain.Dapper.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Infra.Repositories
{
    public class TestTableRepository : ITestTableRepository
    {
        private readonly IConfiguration _configuration;

        public TestTableRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<int> Add(TestTableModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TestTableModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TestTableModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(TestTableModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
