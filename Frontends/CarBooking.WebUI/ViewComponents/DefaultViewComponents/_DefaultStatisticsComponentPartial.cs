using CarBooking.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBooking.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;


		public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
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

			#region Marka Sayısı
			var responseMessage5 = await client.GetAsync("https://localhost:7182/GetBrandCount");
			if (responseMessage.IsSuccessStatusCode)
			{

				var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
				var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
				ViewBag.brandCount = values5.brandCount;

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
