﻿using CarBooking.Application.Features.RepositoryPattern;
using CarBooking.Domain.Entities;
using CarBooking.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistance.Repositories.CommentRepositories
{
	public class CommentRepository<T> : IGenericRepository<Comment>
	{
		private readonly CarBookContext _context;

		public CommentRepository(CarBookContext context)
		{
			_context = context;
		}

		public void Create(Comment entity)
		{
			_context.Comments.Add(entity);
			_context.SaveChanges();
		}

		public List<Comment> GetAll()
		{
			return _context.Comments.Select(x=> new Comment
			{
				
				CommentID= x.CommentID,
				BlogID= x.BlogID,
				CreatedDate= x.CreatedDate,
				Description = x.Description,
				Name = x.Name
			
				
			}).ToList();
		}

		public Comment GetById(int id)
		{
			return _context.Comments.Find(id);

		}

		public List<Comment> GetCommentsByBlogId(int blogId)
		{
			return _context.Set<Comment>().ToList().Where(x=>x.BlogID==blogId).ToList();
		}

		public void Remove(Comment entity)
		{
			var value = _context.Comments.Find(entity.CommentID);
			_context.Remove(value);
			_context.SaveChanges();
		}

		public void Update(Comment entity)
		{
			_context.Comments.Update(entity);
			_context.SaveChanges();
		}

		

		public int CommentCountByBlog(int id)
		{
			return _context.Comments.Where(x => x.BlogID == id).Count();
		}
	}
}
