using Azure.Core;
using CRM.Application.Interfaces;
using CRM.Application.Requests;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Services
{
    public class AuthenticateService(AppDbContext context,  ITokenService tokenService) : IAuthenticateService
    {
        private readonly AppDbContext _context = context;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var user = await GetByEmailAsync(email);
            if (user is null)
                return null!;
            if (!user.IsEmailConfirmed || user.IsDeleted)
                throw new UnauthorizedAccessException("Your email is not confirmed");
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, password)
                is PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("Invalid credentials");
            return _tokenService.GenerateToken(user);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Role).IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
                throw new InvalidOperationException("Email already exists");
            var organization = new Organization()
            {
                Name = request.Email.Split('@')[1],
                Domain = request.Email.Split('@')[1],
                Users = [
                    new()
                    {
                        Name = request.Name,
                        Email = request.Email,
                        PasswordHash = new PasswordHasher<User>().HashPassword(null!, request.Password),
                        RoleId = _context.Roles.FirstOrDefault(r => r.Name == "Admin")!.Id
                    }
                ]
            };
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();
        }
    }
}
