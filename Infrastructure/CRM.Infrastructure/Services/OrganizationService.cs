using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CRM.Infrastructure.Services
{
    public class OrganizationService(IHttpContextAccessor httpContext) : IOrganizationService
    {
        private readonly IHttpContextAccessor _httpContext = httpContext;

        public Guid GetAuthenticatedUserId()
        {
            return Guid.Parse(_httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString());
        }

        public Guid GetCurrentOrganizationId()
        {
            // Assuming the organization ID is stored as a claim in the user's claims
            var organizationIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "OrganizationId");
            if (organizationIdClaim != null && Guid.TryParse(organizationIdClaim.Value, out var organizationId))
            {
                return organizationId;
            }
            return Guid.Empty; // Return an empty GUID if not found or invalid
        }

        public bool IsAuthenticated()
        {
            return _httpContext.HttpContext.User.Identity!.IsAuthenticated;
        }
    }
}
