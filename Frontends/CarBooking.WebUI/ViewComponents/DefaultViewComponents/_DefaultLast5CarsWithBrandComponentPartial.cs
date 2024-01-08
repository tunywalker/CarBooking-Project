﻿using CarBooking.Dto.CarDtos;
using CarBooking.Dto.TestiomonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBooking.WebUI.ViewComponents.DefaultViewComponents
{
	public class _DefaultLast5CarsWithBrandComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultLast5CarsWithBrandComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		



		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client= _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7182/api/Cars/GetLast5CarsWithBrand");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrandsDto>>(jsonData);
				return View(values);

			}
			return View();
		}
	}
}
