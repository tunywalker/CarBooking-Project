using CarBooking.Dto.BrandDtos;
using CarBooking.Dto.LocationDtos;
using CarBooking.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBooking.WebUI.Controllers
{
	public class RentACarListController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;


		public RentACarListController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(int locationID)
		{

			var book_pick_date = TempData["book_pick_date"];
			var book_off_date = TempData["book_off_date"];
			var time_pick = TempData["time_pick"];
			var time_off = TempData["time_off"];
			var locationId = TempData["locationId"];


			ViewBag.bookpickdate = book_pick_date;
			ViewBag.bookoffdate = book_off_date;
			ViewBag.timepick = time_pick;
			ViewBag.timeoff = time_off;
			ViewBag.locationId = locationId;





			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7182/api/RentACars?locationID={locationId}&available={true}");
			if (responseMessage.IsSuccessStatusCode)
			{

				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
				return View(values);
			}
			return View();




		}
	}
}
