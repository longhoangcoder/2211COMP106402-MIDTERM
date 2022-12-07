using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemoApp.Data;
using RazorPagesDemoApp.Model.ViewModels;


namespace RazorPagesDemoApp.Pages.Teams
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        [BindProperty]
        public EditTeamViewModel EditTeamViewModel { get; set; }
        public EditModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var team = dbContext.Teams.Find(id);
            if (team != null)
            {
                //convert domain model to view model
                EditTeamViewModel = new EditTeamViewModel()
                {
                    Id = team.Id,
                    QuocGia = team.QuocGia,
                    SLCauThu = team.SLCauThu
                };
            }
        }
        public void OnPostSave()
        {
            if (EditTeamViewModel != null)
            {
                var existingTeam = dbContext.Teams.Find(EditTeamViewModel.Id);

                if (existingTeam != null)
                {
                    //convert ViewModel to DomainModel

                    existingTeam.QuocGia = EditTeamViewModel.QuocGia;
                    existingTeam.SLCauThu = EditTeamViewModel.SLCauThu;

                    dbContext.SaveChanges();


                    ViewData["Message"] = "Changed successfully!";
                }
            }


        }
        public IActionResult OnPostDelete()
        {
            var existingTeam = dbContext.Teams.Find(EditTeamViewModel.Id);
            if (existingTeam != null)
            {
                dbContext.Teams.Remove(existingTeam);
                dbContext.SaveChanges();
                return RedirectToPage("/Teams/List");
            }
            return Page();
        }
    }
}
