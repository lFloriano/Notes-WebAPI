using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes_API.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime Creation { get; set; }
    }
}