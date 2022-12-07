using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyBongDa.Model.ViewModels;
using RazorPagesDemoApp.Data;
using RazorPagesDemoApp.Model.ViewModels;

namespace QuanLyBongDa.Pages.Member
{

    public class EditModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        [BindProperty]
        public EditMemberViewModel EditMemberViewModel { get; set; }
        public EditModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var member = dbContext.Members.Find(id);
            if (member != null)
            {
                //convert domain model to view model
                EditMemberViewModel = new EditMemberViewModel()
                {
                    TenCauThu = member.TenCauThu,
                    SoAo = member.SoAo,
                    ViTri = member.ViTri
                };
            }

        }
        public void OnPostSave()
        {
            if (EditMemberViewModel != null)
            {
                var existingMember = dbContext.Members.Find(EditMemberViewModel.Id);

                if (existingMember != null)
                {
                    //convert ViewModel to DomainModel

                    existingMember.TenCauThu = EditMemberViewModel.TenCauThu;
                    existingMember.SoAo = EditMemberViewModel.SoAo;
                    existingMember.ViTri = EditMemberViewModel.ViTri;
                    

                    dbContext.SaveChanges();


                    ViewData["Message"] = "Changed successfully!";
                }

            }


        }
        public IActionResult OnPostDelete()
        {
            var existingMember = dbContext.Members.Find(EditMemberViewModel.Id);
            if (existingMember != null)
            {
                dbContext.Members.Remove(existingMember);
                dbContext.SaveChanges();
                return RedirectToPage("/Member/List");
            }
            return Page();
        }
    }
}
