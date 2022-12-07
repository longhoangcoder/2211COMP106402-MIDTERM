using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Data;
using RazorPagesDemoApp.Model.Domain;
using RazorPagesDemoApp.Model.ViewModels;

namespace RazorPagesDemoApp.Pages.Teams
{
    public class AddModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        public AddModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public AddTeamViewModel AddTeamRequest { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var teamDomainModel = new Team
            {
                QuocGia = AddTeamRequest.QuocGia,
                SLCauThu = AddTeamRequest.SLCauThu,
            };
            dbContext.Teams.Add(teamDomainModel);
            dbContext.SaveChanges();

            ViewData["Message"] = "Team created successfully!";
        }
    }
}
