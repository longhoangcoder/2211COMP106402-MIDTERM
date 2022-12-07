using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Data;

namespace RazorPagesDemoApp.Pages.Teams
{
    public class ListModel : PageModel
    {
        //note
        private readonly RazorPagesDemoDbContext dbContext;
        public List<Model.Domain.Team> Teams { get; set; }
        public ListModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Teams = dbContext.Teams.ToList();
        }
    }
}
