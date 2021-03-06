﻿using ManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Domain.Entities
{
    public class AssetSubInfo: AuditEntity
    {
        public int Id { get; set; } // PK
        public int SubInfoId { get; set; } // 불필요
        public string OrgName { get; set; }
        public double RiskGrade { get; set; }
        public AssetPrimaryInfo AssetPrimaryInfo { get; set; } // FK
    }
}
