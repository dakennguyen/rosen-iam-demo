using Microsoft.AspNetCore.Authorization;

namespace Demo.Policies
{
    public class MinimumExpRequirement : IAuthorizationRequirement
    {
        public int MinimumExp { get; set; }
        public MinimumExpRequirement(int experience)
        {
            MinimumExp = experience;
        }
    }
}