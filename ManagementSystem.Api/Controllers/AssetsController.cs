using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementSystem.Application.Assets.Commands;
using ManagementSystem.Application.Assets.Queries;
using ManagementSystem.Application.Assets.ViewModels;
using ManagementSystem.Application.Common.Interface;
using ManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Api.Controllers
{
    [Authorize]
    public class AssetsController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public AssetsController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> create(CreateAssetCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<IList<AssetPrimaryInfoVm>> Get()
        {
            return await Mediator.Send(new GetUserAssetsQuery { User = _currentUserService.UserId });
        }
    }
}