using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.Dtos;
using Demo.Policies;
using Demo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetManagementController : ControllerBase
    {
        private readonly IAuthorizationService authorizationService;
        private readonly IItemRepository itemRepository;

        public AssetManagementController(IAuthorizationService authorizationService, IItemRepository itemRepository)
        {
            this.authorizationService = authorizationService;
            this.itemRepository = itemRepository;
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<string>>> GetAdminAsync([FromBody]BodyData user)
        {
            var requirement = new MinimumExpRequirement(5);
            var resource = user;

            var authorizationResult = await this.authorizationService.AuthorizeAsync(User, resource, requirement);

            if (authorizationResult.Succeeded)
            {
                return Ok($"posted this data [{user.ResourceId.ToString()}] using the body");
            }
            else
            {
                return new ForbidResult();
            }
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<string>>> GetUserAsync([FromBody]RequestBody data)
        {
            var requirement = new MinimumExpRequirement(5);
            var resource = data;

            var authorizationResult = await this.authorizationService.AuthorizeAsync(User, resource, requirement);

            if (authorizationResult.Succeeded)
            {
                return this.Ok(this.itemRepository.GetItems(data.ResourceId));
            }
            else
            {
                return new ForbidResult();
            }
        }
    }
}