using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.Models
{
    public class AllProject
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public DateTime ContractDate { get; set; }
        public string PhotoUrl { get; set; }
    }
}

