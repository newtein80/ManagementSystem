using ManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagementSystem.Application.Common.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<AssetPrimaryInfo> AssetPrimaryInfos { get; set; }
        DbSet<AssetSubInfo> AssetSubInfos { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
