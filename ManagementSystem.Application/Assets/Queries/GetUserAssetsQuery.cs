using ManagementSystem.Application.Assets.ViewModels;
using ManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Application.Assets.Queries
{
    public class GetUserAssetsQuery: IRequest<IList<AssetPrimaryInfoVm>>
    {
        public string User { get; set; }
    }
}
