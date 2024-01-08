using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Domain.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public Author Author { get; set; }
        public List<Blog> Blogs { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set;}
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
