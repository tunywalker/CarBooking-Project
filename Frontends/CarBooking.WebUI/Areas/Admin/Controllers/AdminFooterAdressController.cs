using CarBooking.Dto.FooterAdressDtos;
using CarBooking.Dto.FooterAdressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBooking.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminFooterAdress")]
	public class AdminFooterAdressController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;


		public AdminFooterAdressController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		[Route("")]
		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7182/api/FooterAdresses");
			if (responseMessage.IsSuccessStatusCode)
			{

				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFooterAdressDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[Route("CreateFooterAdress")]
		[HttpGet]
		public IActionResult CreateFooterAdress()
		{
			return View();
		}

		[HttpPost]
		[Route("CreateFooterAdress")]
		public async Task<IActionResult> CreateFooterAdress([FromForm] CreateFooterAdressDto FooterAdressDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(FooterAdressDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7182/api/FooterAdresses", stringContent);
			if (responseMessage.IsSuccessStatusCode)
				return RedirectToAction("Index", "AdminFooterAdress", new { area = "Admin" });
			return View();


		}

		[Route("UpdateFooterAdress/{id}")]
		[HttpGet]
		public async Task<IActionResult> UpdateFooterAdress(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7182/api/FooterAdresses/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFooterAdressDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		[Route("UpdateFooterAdress/{id}")]
		public async Task<IActionResult> UpdateFooterAdress(UpdateFooterAdressDto updateFooterAdressDto)
		{

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFooterAdressDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync($"https://localhost:7182/api/FooterAdresses/", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminFooterAdress", new { area = "Admin" });
			}
			return View();



		}

		[Route("RemoveFooterAdress/{id}")]
		public async Task<IActionResult> RemoveFooterAdress([FromRoute] int id)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.DeleteAsync($"https://localhost:7182/api/FooterAdresses?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
				return RedirectToAction("Index", "AdminFooterAdress", new { area = "Admin" });
			return View();


		}
	}
}
