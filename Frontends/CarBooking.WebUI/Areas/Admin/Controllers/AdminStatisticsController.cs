using CarBooking.Dto.AuthorDtos;
using CarBooking.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBooking.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminStatistics/Index")]  
    public class AdminStatisticsController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;


        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
			#region Araba Sayısı
			var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7182/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = values.carCount;               
            }
			#endregion

			#region Lokasyon Sayısı
			var responseMessage2 = await client.GetAsync("https://localhost:7182/GetLocationCount");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.locationCount = values.locationCount;
                
            }
            
			#endregion
			#region Yazar Sayısı
			var responseMessage3 = await client.GetAsync("https://localhost:7182/GetAuthorCount");
			if (responseMessage.IsSuccessStatusCode)
			{

				var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
				var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
				ViewBag.authorCount = values3.authorCount;

			}

			#endregion
			return View();
		}
	}
}
