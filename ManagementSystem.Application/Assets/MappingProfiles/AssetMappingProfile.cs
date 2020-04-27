using AutoMapper;
using ManagementSystem.Application.Assets.Commands;
using ManagementSystem.Application.Assets.ViewModels;
using ManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Application.Assets.MappingProfiles
{
    public class AssetMappingProfile: Profile
    {
        public AssetMappingProfile()
        {
            CreateMap<AssetPrimaryInfo, AssetPrimaryInfoVm>();
            CreateMap<AssetSubInfo, AssetSubInfoVm>().ConstructUsing(i => new AssetSubInfoVm
            {
                Id = i.Id,
                OrgName = i.OrgName,
                RiskGrade = i.RiskGrade
            });

            CreateMap<AssetPrimaryInfoVm, AssetPrimaryInfo>();
            CreateMap<AssetSubInfoVm, AssetSubInfo>();

            CreateMap<CreateAssetCommand, AssetPrimaryInfo>();
        }
    }
}
