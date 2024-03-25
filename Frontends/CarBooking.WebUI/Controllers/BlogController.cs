using CarBooking.Dto.BlogDtos;
using CarBooking.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBooking.WebUI.Controllers
{
    public class BlogController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7182/api/Blogs/GetAllBlogsWithAuthorList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.V1 = "Bloglar";
			ViewBag.V2 = "Blog Detayı ve Yorumlar";
            ViewBag.blogId = id;
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("https://localhost:7182/api/Blogs/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetBlogByIdDto>(jsonData);
				return View(values);

			}
			return View();
			
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
		[HttpPost]
		public IActionResult AddComment(string p)
		{
			return View();
		}
	}
}
