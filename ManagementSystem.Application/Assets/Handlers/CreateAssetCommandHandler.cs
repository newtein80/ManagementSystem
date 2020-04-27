using AutoMapper;
using ManagementSystem.Application.Assets.Commands;
using ManagementSystem.Application.Common.Interface;
using ManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagementSystem.Application.Assets.Handlers
{
    public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateAssetCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            /*var entity = new AssetPrimaryInfo
            {
                AssetName = request.AssetName,
                HostName = request.HostName,
                IpAddress = request.IpAddress,
                RiskPoint = request.RiskPoint,
                AssetPoint = request.AssetPoint,
                AssetType = request.AssetType,
                AssetKind = request.AssetKind,
                Description = request.Description,
                RegTime = request.RegTime,
                SetTime = request.SetTime,
                ModTime = request.ModTime,
                AssetSubInfos = request.AssetSubInfos.Select(i => new AssetSubInfo
                {
                    OrgName = i.OrgName,
                    RiskGrade = i.RiskGrade
                }).ToList()
            };*/
            var entity = _mapper.Map<AssetPrimaryInfo>(request);

            _context.AssetPrimaryInfos.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
