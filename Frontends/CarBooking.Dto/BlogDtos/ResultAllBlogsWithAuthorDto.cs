using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Dto.BlogDtos
{
    public class ResultAllBlogsWithAuthorDto
    {


        public int blogID { get; set; }
        public string title { get; set; }
        public string authorName { get; set; }
        public int authorId { get; set; }
        public string coverImageUrl { get; set; }
        public DateTime createdDate { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public string authorImageUrl { get; set; }
        public string authorDescription { get; set; }


    }
}
