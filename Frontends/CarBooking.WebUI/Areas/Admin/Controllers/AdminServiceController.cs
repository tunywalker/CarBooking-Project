using CarBooking.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBooking.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminService")]
	
		public class AdminServiceController : Controller
	{
	
			private readonly IHttpClientFactory _httpClientFactory;

			public AdminServiceController(IHttpClientFactory httpClientFactory)
			{
				_httpClientFactory = httpClientFactory;
			}

			[Route("Index")]
			[Route("")]
			public async Task<IActionResult> Index()
			{

				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.GetAsync("https://localhost:7182/api/Services");
				if (responseMessage.IsSuccessStatusCode)
				{

					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
					return View(values);
				}
				return View();
			}
			[Route("CreateService")]
			[HttpGet]
			public IActionResult CreateService()
			{
				return View();
			}

			[HttpPost]
			[Route("CreateService")]
			public async Task<IActionResult> CreateService([FromForm] CreateServiceDto ServiceDto)
			{
				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(ServiceDto);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("https://localhost:7182/api/Services", stringContent);
				if (responseMessage.IsSuccessStatusCode)
					return RedirectToAction("Index", "AdminService", new { area = "Admin" });
				return View();


			}

			[Route("UpdateService/{id}")]
			[HttpGet]
			public async Task<IActionResult> UpdateService(int id)
			{

				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.GetAsync($"https://localhost:7182/api/Services/{id}");
				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
					return View(values);
				}
				return View();
			}

			[HttpPost]
			[Route("UpdateService/{id}")]
			public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
			{

				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(updateServiceDto);
				StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PutAsync($"https://localhost:7182/api/Services/", content);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "AdminService", new { area = "Admin" });
				}
				return View();



			}

			[Route("RemoveService/{id}")]
			public async Task<IActionResult> RemoveService([FromRoute] int id)
			{
				var client = _httpClientFactory.CreateClient();

				var responseMessage = await client.DeleteAsync($"https://localhost:7182/api/Services?id=" + id);
				if (responseMessage.IsSuccessStatusCode)
					return RedirectToAction("Index", "AdminService", new { area = "Admin" });
				return View();


			}
		}
}
