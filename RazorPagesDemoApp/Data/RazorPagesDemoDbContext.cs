using Microsoft.EntityFrameworkCore;
using QuanLyBongDa.Model.Domain;
using RazorPagesDemoApp.Model.Domain;

namespace RazorPagesDemoApp.Data
{
    public class RazorPagesDemoDbContext: DbContext
    {
        public RazorPagesDemoDbContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
    }


}
