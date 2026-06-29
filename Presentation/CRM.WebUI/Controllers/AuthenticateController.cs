using Azure.Core;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using CRM.Application.Requests;
using CRM.Domain.Entities;

namespace CRM.WebUI.Controllers
{
    [Authorize]
    public class AuthenticateController(IAuthenticateService authService, ITokenService tokenService, HttpClient httpClient) : Controller
    {
        private readonly IAuthenticateService _authService = authService;
		private readonly ITokenService _tokenService = tokenService;
		private readonly HttpClient _httpClient = httpClient;
        private string baseUrl = "https://localhost:7257/api/v1/auth";

        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync<LoginRequest>($"{baseUrl}/login", request);
                if (res.IsSuccessStatusCode)
                {
                    var token = await res.Content.ReadAsStringAsync();
                    Response.Cookies.Append("JWToken", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None,
                        Expires = DateTimeOffset.UtcNow.AddHours(1)
                    });
                }

                var user = await _authService.GetByEmailAsync(request.Email);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı veya parola hatalı");
                    return View(request);
                }

                if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı veya parola hatalı");
                    return View(request);
                }

                var claims = _tokenService.GetClaims(user);
				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1) // Set expiration time as needed
                });

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }

}

