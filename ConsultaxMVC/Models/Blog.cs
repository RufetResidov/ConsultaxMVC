using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
