using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Application.Dapper.Interface
{
    public interface IUnitOfWork
    {
        ITestTableRepository Tests { get; }
    }
}
