using System;
using System.Linq;
using System.Threading.Tasks;
using Demo.Data;
using Demo.Models.Dtos;
using Demo.Models.Entities;
using Demo.Repositories;
using Demo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace Demo.Policies
{
    public class UserViewHandler : AuthorizationHandler<MinimumExpRequirement, RequestBody>
    {
        private readonly IResourceService resourceService;

        public UserViewHandler(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumExpRequirement requirement, RequestBody bodyData)
        {
            var user = context.User;
            var claim = context.User.FindFirst("https://rosen-iam-demo.com/userId");
            if (claim != null)
            {
                var userId = Guid.Parse(claim?.Value);

                var allowedResources = this.resourceService.GetResources(userId);
                if (allowedResources.Contains(bodyData.ResourceId)) context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}