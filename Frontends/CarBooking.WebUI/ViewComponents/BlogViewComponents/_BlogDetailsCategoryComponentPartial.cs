using CarBooking.Dto.CategoryDtos;
using CarBooking.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBooking.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryComponentPartial:ViewComponent
    {

		IHttpClientFactory _httpClientFactory;

		public _BlogDetailsCategoryComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7182/api/Categories");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);

			}
			return View();
		}
	}
}
