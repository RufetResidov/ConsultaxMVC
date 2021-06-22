using ConsultaxMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.Data
{
    public class ConsultaxTable:DbContext
    {
        public ConsultaxTable(DbContextOptions options):base(options)
        {

        }
        public DbSet<AllProject>AllProjects { get; set; }
        public DbSet<AllService> AllServices{ get; set; }
        public DbSet<AltSection> AltSections{ get; set; }
        public DbSet<Blog> Blogs{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<SectionOne> SectionOnes{ get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<WhoWeAre> whoWeAres { get; set; }
    }
}
