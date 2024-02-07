using CarBooking.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBooking.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminLocation")]
	public class AdminLocationController : Controller
	{
			private readonly IHttpClientFactory _httpClientFactory;

			public AdminLocationController(IHttpClientFactory httpClientFactory)
			{
				_httpClientFactory = httpClientFactory;
			}

			[Route("Index")]
			[Route("")]
			public async Task<IActionResult> Index()
			{

				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.GetAsync("https://localhost:7182/api/Locations");
				if (responseMessage.IsSuccessStatusCode)
				{

					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
					return View(values);
				}
				return View();
			}
			[Route("CreateLocation")]
			[HttpGet]
			public IActionResult CreateLocation()
			{
				return View();
			}

			[HttpPost]
			[Route("CreateLocation")]
			public async Task<IActionResult> CreateLocation([FromForm] CreateLocationDto LocationDto)
			{
				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(LocationDto);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("https://localhost:7182/api/Locations", stringContent);
				if (responseMessage.IsSuccessStatusCode)
					return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
				return View();


			}

			[Route("UpdateLocation/{id}")]
			[HttpGet]
			public async Task<IActionResult> UpdateLocation(int id)
			{

				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.GetAsync($"https://localhost:7182/api/Locations/{id}");
				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
					return View(values);
				}
				return View();
			}

			[HttpPost]
			[Route("UpdateLocation/{id}")]
			public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
			{

				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(updateLocationDto);
				StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PutAsync($"https://localhost:7182/api/Locations/", content);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
				}
				return View();



			}

			[Route("RemoveLocation/{id}")]
			public async Task<IActionResult> RemoveLocation([FromRoute] int id)
			{
				var client = _httpClientFactory.CreateClient();

				var responseMessage = await client.DeleteAsync($"https://localhost:7182/api/Locations?id=" + id);
				if (responseMessage.IsSuccessStatusCode)
					return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
				return View();


			}
		}
}
