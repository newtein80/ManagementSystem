using ManagementSystem.Application.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITestTableRepository testTableRepository)
        {
            Tests = testTableRepository;
        }
        public ITestTableRepository Tests { get; }
    }
}
