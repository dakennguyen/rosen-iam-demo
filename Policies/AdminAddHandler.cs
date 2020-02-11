using System;
using System.Threading.Tasks;
using Demo.Models.Dtos;
using Demo.Services;
using Microsoft.AspNetCore.Authorization;

namespace Demo.Policies
{
    public class AdminAddHandler : AuthorizationHandler<MinimumExpRequirement, BodyData>
    {
        private readonly IResourceService resourceService;

        public AdminAddHandler(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumExpRequirement requirement, BodyData bodyData)
        {
            var user = context.User;
            var claim = context.User.FindFirst("https://rosen-iam-demo.com/userId");
            if (claim != null)
            {
                var userId = Guid.Parse(claim?.Value);

                var allowedResources = this.resourceService.AdminGetResources(userId);
                if (allowedResources.Contains(bodyData.ResourceId)) context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}