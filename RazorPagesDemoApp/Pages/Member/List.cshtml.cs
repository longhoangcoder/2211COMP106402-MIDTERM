using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Data;
using RazorPagesDemoApp.Model.Domain;

namespace QuanLyBongDa.Pages.Member
{
    public class ListModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        public List<Model.Domain.Member> Members { get; set; }
        public ListModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Members = dbContext.Members.ToList();
        }
    }
}
