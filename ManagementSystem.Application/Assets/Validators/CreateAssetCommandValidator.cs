using FluentValidation;
using ManagementSystem.Application.Assets.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Application.Assets.Validators
{
    public class CreateAssetCommandValidator: AbstractValidator<CreateAssetCommand>
    {
        public CreateAssetCommandValidator()
        {
            RuleFor(v => v.AssetName).NotNull();
            RuleFor(v => v.AssetType).NotNull();
            RuleFor(v => v.AssetKind).NotNull();
            //RuleFor(v => v.From).NotEmpty().MinimumLength(3);
            //RuleFor(v => v.To).NotEmpty().MinimumLength(3);
            RuleFor(v => v.AssetSubInfos).SetValidator(new MustHaveAssetSubInfoPropertyValidator());
        }
    }
}
