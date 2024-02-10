﻿using CarBooking.Dto.AuthorDtos;
using CarBooking.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBooking.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminAuthor")]
	public class AdminAuthorController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;


		public AdminAuthorController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		[Route("")]
		public async Task<IActionResult> Index()
		{

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7182/api/Authors");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
		[Route("CreateAuthor")]
		[HttpGet]
		public IActionResult CreateAuthor()
		{
			return View();
		}

		[HttpPost]
		[Route("CreateAuthor")]
		public async Task<IActionResult> CreateAuthor([FromForm] CreateAuthorDto AuthorDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(AuthorDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7182/api/Authors", stringContent);
			if (responseMessage.IsSuccessStatusCode)
				return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
			return View();


		}

		[Route("UpdateAuthor/{id}")]
		[HttpGet]
		public async Task<IActionResult> UpdateAuthor(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7182/api/Authors/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		[Route("UpdateAuthor/{id}")]
		public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
		{

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateAuthorDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync($"https://localhost:7182/api/Authors/", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
			}
			return View();



		}

		[Route("RemoveAuthor/{id}")]
		public async Task<IActionResult> RemoveAuthor([FromRoute] int id)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.DeleteAsync($"https://localhost:7182/api/Authors?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
				return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
			return View();


		}
	}
}
