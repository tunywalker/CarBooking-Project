﻿using CarBooking.Application.Interfaces.BlogInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistance.Repositories.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public List<Blog> GetAllBlogsWithAuthors()
        {
            var values = _carBookContext.Blogs.Include(b => b.Author).Include(c => c.Category).ToList();
            return values;
        }

        public List<Blog> GetLast3BlogsWithAuthors()
        {
            var values = _carBookContext.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToList();
            return values;
        }

        public Blog GetBlogByAuthorId(int blogId)
        {
            var values = _carBookContext.Blogs.Include(x => x.Author).Where(y => y.BlogID == blogId).FirstOrDefault();
            return values;
        }
    }
}
