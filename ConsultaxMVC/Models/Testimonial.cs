using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.Models
{
    public class Testimonial
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FromCity { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
    }
}
