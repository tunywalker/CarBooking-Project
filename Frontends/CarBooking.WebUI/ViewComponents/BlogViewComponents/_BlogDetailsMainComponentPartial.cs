using CarBooking.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBooking.WebUI.ViewComponents.BlogViewComponents
{
	public class _BlogDetailsMainComponentPartial : ViewComponent
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage2 = await client.GetAsync($"https://localhost:7182/api/Comments/CommentCountByBlog?id=" + id);
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			ViewBag.v2 = jsonData2;
			var responseMessage = await client.GetAsync($"https://localhost:7182/api/TagClouds/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetBlogByIdDto>(jsonData);
				return View(values);

			}

			return View();





		}
	}
}
