using CarBooking.Dto.BannerDtos;
using CarBooking.Dto.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace CarBooking.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminBannerController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;


		public AdminBannerController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7182/api/Banners");
			if (responseMessage.IsSuccessStatusCode)
			{

				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
