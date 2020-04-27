using FluentValidation.Validators;
using ManagementSystem.Application.Assets.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystem.Application.Assets.Validators
{
    public class MustHaveAssetSubInfoPropertyValidator: PropertyValidator
    {
        public MustHaveAssetSubInfoPropertyValidator()
            :base("Property {PropertyName} should not be an empty list.")
        {

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IList<AssetSubInfoVm>;
            return list != null && list.Any();
        }
    }
}
