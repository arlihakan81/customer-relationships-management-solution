using CRM.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.WebUI.Controllers
{
	[Authorize]
	public class CompanyController(HttpClient httpClient) : Controller
	{
		private readonly HttpClient _httpClient = httpClient;
		private string baseUrl = "https://localhost:7257/api/v1/";


        private void AddToken()
		{
			var token = Request.Cookies["JWToken"];
			if (token != null)
			{
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
		}

		[HttpGet("companies")]
		public async Task<IActionResult> Index()
		{
			AddToken();
			var companies = await _httpClient.GetFromJsonAsync<BaseResponse<PagedList<CRM.Application.Dtos.Company.CompanyDto>>>($"{baseUrl}companies");
            return View(companies);
		}
	}
}
