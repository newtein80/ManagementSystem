using ManagementSystem.Application.Assets.ViewModels;
using ManagementSystem.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Application.Assets.Commands
{
    public class CreateAssetCommand: IRequest<int>
    {
        public CreateAssetCommand()
        {
            this.AssetSubInfos = new List<AssetSubInfoVm>();
        }

        public string AssetName { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }
        public double RiskPoint { get; set; }
        public double AssetPoint { get; set; }
        public AssetType AssetType { get; set; }
        public AssetKind AssetKind { get; set; }
        public string Description { get; set; }
        public DateTime RegTime { get; set; }
        public DateTime? SetTime { get; set; }
        public DateTime? ModTime { get; set; }
        public IList<AssetSubInfoVm> AssetSubInfos { get; set; }
    }
}
