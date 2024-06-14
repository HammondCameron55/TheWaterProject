using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheWaterProject.Infrastructure;
using TheWaterProject.Models;

namespace TheWaterProject.Pages
{
    public class CartModel : PageModel
    {
        public IWaterRepository repository;

        public Cart? Cart { get; set; }

        public CartModel(IWaterRepository repo, Cart cartService )
        {
            repository = repo;
            
            Cart = cartService;
        }
        
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            
        }

        public IActionResult OnPost(int projectId, string returnUrl)
        {
            //Get the selected project
            Project proj = repository.Projects
                .FirstOrDefault(p => p.ProjectId == projectId);

            if (proj != null)
            {
                
                Cart.AddItem(proj, 1);
                
            }

            return RedirectToPage(new { returnUrl = returnUrl });
            
        }

        public IActionResult OnPostRemove(int projectId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(x => x.Project.ProjectId == projectId).Project);
            
            return RedirectToPage(new { returnUrl = returnUrl });
            
        }

    }
}
