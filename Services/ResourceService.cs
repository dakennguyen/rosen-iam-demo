using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Models.Dtos;
using Demo.Models.Entities;
using Demo.Repositories;

namespace Demo.Services
{
    public interface IResourceService
    {
        List<int> GetResources(Guid userId);
        List<int> AdminGetResources(Guid userId);
    }

    public class ResourceService : IResourceService
    {
        private readonly IGenericRepository<UserRoleMap> userRoleMapRepository;
        private readonly IGenericRepository<ApplicationResourceMap> applicationResourceMapRepository;

        public ResourceService(
            IGenericRepository<UserRoleMap> userRoleMapRepository,
            IGenericRepository<ApplicationResourceMap> applicationResourceMapRepository)
        {
            this.userRoleMapRepository = userRoleMapRepository;
            this.applicationResourceMapRepository = applicationResourceMapRepository;
        }

        public List<int> GetResources(Guid userId)
        {
            var allowedApps = this.userRoleMapRepository.Get()
                .Where(urm => urm.UserId == userId)
                .Select(urm => urm.Role.ApplicationId)
                .ToList();

            var allowedResources = this.applicationResourceMapRepository.Get()
                .Where(arm => allowedApps.Contains(arm.ApplicationId))
                .Select(arm => arm.ResourceId)
                .ToList();
            return allowedResources;
        }

        public List<int> AdminGetResources(Guid userId)
        {
            var allowedApps = this.userRoleMapRepository.Get()
                .Where(urm => urm.UserId == userId && urm.Role.Name == "Admin")
                .Select(urm => urm.Role.ApplicationId)
                .ToList();
            var allowedResources = this.applicationResourceMapRepository.Get()
                .Where(arm => allowedApps.Contains(arm.ApplicationId))
                .Select(arm => arm.ResourceId)
                .ToList();
            return allowedResources;
        }
    }
}