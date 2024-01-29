using CarBooking.Dto.BrandDtos;
using CarBooking.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace CarBooking.WebUI.Controllers
{
	public class AdminCarController : Controller
	{

		private readonly IHttpClientFactory _httpClientFactory;


		public AdminCarController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7182/api/Cars/GetCarWithBrand");
			if (responseMessage.IsSuccessStatusCode)
			{

				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateCar()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7182/api/Brands");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
				List<SelectListItem> brandValues = (from x in values
													select new SelectListItem
													{
														Text = x.name,
														Value = x.brandId.ToString()
													}).ToList();
				ViewBag.BrandValues = brandValues;
			}

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateCar([FromForm] CreateCarDto carDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(carDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7182/api/Cars", stringContent);
			if (responseMessage.IsSuccessStatusCode)
				return RedirectToAction("Index");
			return View();


		}

		public async Task<IActionResult> RemoveCar(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.DeleteAsync($"https://localhost:7182/api/Cars/{id}");
			if (responseMessage.IsSuccessStatusCode)
				return RedirectToAction("Index");
			return View();


		}

		[HttpGet]
		public async Task<IActionResult> UpdateCar(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7182/api/Brands");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
				List<SelectListItem> brandValues = (from x in values
													select new SelectListItem
													{
														Text = x.name,
														Value = x.brandId.ToString()
													}).ToList();
				ViewBag.BrandValues = brandValues;
			}

			responseMessage = await client.GetAsync($"https://localhost:7182/api/Cars/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
		{

			var client = _httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(updateCarDto);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync($"https://localhost:7182/api/Cars/", content);
			if(responseMessage.IsSuccessStatusCode )
			{
				return RedirectToAction("Index");
			}
			return View();



		}
	}
}
