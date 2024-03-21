using CarBooking.Application.Features.RepositoryPattern;
using CarBooking.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly IGenericRepository<Comment> _commentsRepository;

		public CommentsController(IGenericRepository<Comment> commentsRepository)
		{
			_commentsRepository = commentsRepository;
		}

		[HttpGet]
		public IActionResult CommentList()
		{
			var values=_commentsRepository.GetAll();
			return Ok(values);


		}

		[HttpPost]
		public IActionResult CreateComment (Comment comment)
		{
			_commentsRepository.Create(comment);
			return Ok("Yorum başarıyla eklendi");


		}
		[HttpDelete]
		public IActionResult DeleteComment(int id)
		{
			var value =_commentsRepository.GetById(id);
			_commentsRepository.Remove(value);
			return Ok("Yorum başarıyla silindi");
					}
		[HttpPut]
		public IActionResult UpdateComment(Comment comment)
		{
			_commentsRepository.Update(comment);
			return Ok("Yorum başarıyla güncellendi");


		}
		[HttpGet("{id}")]
		public IActionResult GetComment(int id)
		{
			var value=_commentsRepository.GetById(id);
			return Ok(value);
		}
		[HttpGet("CommentListByBlog")]
		public IActionResult CommentListByBlog(int id)
		{
			var value = _commentsRepository.GetCommentsByBlogId(id);
			return Ok(value);
		}
		[HttpGet("CommentCountByBlog")]
		public IActionResult CommentCountByBlog(int id)
		{
			var value = _commentsRepository.CommentCountByBlog(id);
			return Ok(value);
		}



	}
}
