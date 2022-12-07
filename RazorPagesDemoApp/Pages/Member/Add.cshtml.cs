using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyBongDa.Model.Domain;
using QuanLyBongDa.Model.ViewModels;
using RazorPagesDemoApp.Data;
using RazorPagesDemoApp.Model.Domain;
using RazorPagesDemoApp.Model.ViewModels;


namespace QuanLyBongDa.Pages.Member
{
    public class AddModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        public AddModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public AddMemberViewModel AddMemberRequest { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            var memberDomainModel = new QuanLyBongDa.Model.Domain.Member
            {
                TenCauThu = AddMemberRequest.TenCauThu,
                SoAo = AddMemberRequest.SoAo,
                ViTri = AddMemberRequest.ViTri,
            };
            dbContext.Members.Add(memberDomainModel);
            dbContext.SaveChanges();

            ViewData["Message"] = "Member added successfully!";
        }
    }
}
