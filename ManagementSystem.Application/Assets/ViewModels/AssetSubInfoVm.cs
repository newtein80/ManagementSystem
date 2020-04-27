using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Application.Assets.ViewModels
{
    public class AssetSubInfoVm
    {
        public int Id { get; set; }
        public string OrgName { get; set; }
        public double RiskGrade { get; set; }
        public double AssetRiskGrade => RiskGrade * 0.1;
    }
}
