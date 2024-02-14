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
			#region Blog Sayısı
			var responseMessage4 = await client.GetAsync("https://localhost:7182/GetBlogCount");
			if (responseMessage.IsSuccessStatusCode)
			{

				var jsonData3 = await responseMessage4.Content.ReadAsStringAsync();
				var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
				ViewBag.blogCount = values4.blogCount;

			}

			#endregion
			#region Marka Sayısı
			var responseMessage5 = await client.GetAsync("https://localhost:7182/GetBrandCount");
			if (responseMessage.IsSuccessStatusCode)
			{

				var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
				var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
				ViewBag.BrandCount = values5.brandCount;

			}

			#endregion
			#region Günlük Ortalama Kiralama Fiyatı
			var responseMessage6 = await client.GetAsync("https://localhost:7182/GetAvgRentPriceForDaily");
			if (responseMessage6.IsSuccessStatusCode)
			{

				var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
				var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
				ViewBag.avgRentPriceForDaily = values6.avgPriceForDaily.ToString("0.00"); ;

			}

			#endregion
			#region Haftalık Ortalama Kiralama Fiyatı
			var responseMessage7 = await client.GetAsync("https://localhost:7182/GetAvgRentPriceForWeekly");
			if (responseMessage7.IsSuccessStatusCode)
			{

				var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
				var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
				ViewBag.avgRentPriceForWeekly = values7.avgPriceForWeekly.ToString("0.00"); ;

			}

			#endregion
			#region Aylık Ortalama Kiralama Fiyatı
			var responseMessage8 = await client.GetAsync("https://localhost:7182/GetAvgRentPriceForMonthly");
			if (responseMessage8.IsSuccessStatusCode)
			{

				var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
				var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
				ViewBag.avgRentPriceForMonthly = values8.avgPriceForMonthly.ToString("0.00");

			}

			#endregion
			return View();
		}
	}
}
