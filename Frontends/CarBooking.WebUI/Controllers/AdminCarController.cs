﻿using CarBooking.Dto.BrandDtos;
using CarBooking.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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


	}
}