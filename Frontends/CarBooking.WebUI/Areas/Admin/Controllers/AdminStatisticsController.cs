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
			#region Otomatik Vites Araç Sayısı Ortalama Kiralama Fiyatı
			var responseMessage9 = await client.GetAsync("https://localhost:7182/GetCarCountByTransmissionIsAuto");
			if (responseMessage9.IsSuccessStatusCode)
			{

				var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
				var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
				ViewBag.carCountByTransmissionIsAuto = values9.carCountByTransmissionIsAuto;

			}

			#endregion

			#region En Fazla Araça Sahip Olan Marka
			var responseMessage10 = await client.GetAsync("https://localhost:7182/GetBrandNameByMaxCar");
			if (responseMessage10.IsSuccessStatusCode)
			{

				var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
				var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
				ViewBag.brandNameByMaximumCar = values10.brandNameByMaximumCar;

			}

			#endregion

			#region En Fazla Yoruma Sahip Olan Blog
			var responseMessage11 = await client.GetAsync("https://localhost:7182/GetBrandNameByMaxCar");
			if (responseMessage11.IsSuccessStatusCode)
			{

				var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
				var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
				ViewBag.brandNameByMaximumCar = values11.brandNameByMaximumCar;

			}
			#endregion
			#region 10000 Km Altındaki Araçlar
			var responseMessage12 = await client.GetAsync("https://localhost:7182/GetBrandNameByMaxCar");
			if (responseMessage12.IsSuccessStatusCode)
			{

				var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
				var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
				ViewBag.brandNameByMaximumCar = values12.brandNameByMaximumCar;

			}

			#endregion

			#region Benzin Veya Dizel Araç Sayısı
			var responseMessage13 = await client.GetAsync("https://localhost:7182/GetCarCountByGasolineOrDiesel");
			if (responseMessage13.IsSuccessStatusCode)
			{

				var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
				var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
				ViewBag.carCountByGasolineOrDiesel = values13.carCountByGasolineOrDiesel;

			}

			#endregion

			#region Elektrikli Araç Sayısı
			var responseMessage14 = await client.GetAsync("https://localhost:7182/GetCarCountByFuelElectric");
			if (responseMessage14.IsSuccessStatusCode)
			{

				var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
				var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
				ViewBag.carCountByFuelElectric = values14.carCountByFuelElectric;

			}

			#endregion
			




			return View();
		
		}
	}
}
