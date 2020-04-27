using AutoMapper;
using ManagementSystem.Application.Assets.Queries;
using ManagementSystem.Application.Assets.ViewModels;
using ManagementSystem.Application.Common.Interface;
using ManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagementSystem.Application.Assets.Handlers
{
    public class GetUserAssetsQueryHandler: IRequestHandler<GetUserAssetsQuery, IList<AssetPrimaryInfoVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserAssetsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<AssetPrimaryInfoVm>> Handle(GetUserAssetsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<AssetPrimaryInfoVm>();
            var assets = await _context.AssetPrimaryInfos.Include(i => i.AssetSubInfos)
                .Where(i => i.CreatedBy == request.User).ToListAsync();

            if (assets != null)
            {
                /*result = assets.Select(i => new AssetPrimaryInfoVm
                {
                    Id = i.Id,
                    AssetName = i.AssetName,
                    HostName = i.HostName,
                    IpAddress = i.IpAddress,
                    RiskPoint = i.RiskPoint,
                    AssetPoint = i.AssetPoint,
                    AssetType = i.AssetType,
                    AssetKind = i.AssetKind,
                    Description = i.Description,
                    RegTime = i.RegTime,
                    SetTime = i.SetTime,
                    ModTime = i.ModTime,
                    AssetSubInfos = i.AssetSubInfos.Select(item => new AssetSubInfoVm
                    {
                        Id = item.Id,
                        OrgName = item.OrgName,
                        RiskGrade = item.RiskGrade
                    }).ToList()
                }).ToList();*/
                result = _mapper.Map<List<AssetPrimaryInfoVm>>(assets);
            }

            return result;
        }
    }
}
