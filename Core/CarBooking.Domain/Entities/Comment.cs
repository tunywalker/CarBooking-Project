using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Domain.Entities
{
	public class Comment
	{
        public int CommentID { get; set; }
        public int Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }
        public string BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
