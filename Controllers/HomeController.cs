using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheWaterProject.Models;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Controllers
{
    public class HomeController : Controller
    {
        private IWaterRepository _repo;

        public HomeController(IWaterRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 5;

            
            // ProjectListViewModel is a class that contains a list of projects and a PaginationInfo object
            var blah = new ProjectsListViewModel // Create a new instance of the ProjectsListViewModel class
            {
                Projects = _repo.Projects
                .OrderBy(x => x.ProjectName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                // The Skip method is used to skip over a certain number of items in the list, and the Take method is used to take a certain number of items from the list.

                //PaginationInfo is a class that contains information about the current page, the number of items per page, and the total number of items in the list
                PaginationInfo = new PaginationInfo // Create a new instance of the PaginationInfo class
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Projects.Count()

                }
            };
                     
            return View(blah);
        }

  
    }
}

// Pagination is a technique used to break up a large list of items into smaller, more manageable pieces.
// This is useful when you have a large number of items to display, and you don't want to overwhelm the user with a long list.


//If a property that is being passed in the URL route is not in an entry for the MapControllerRoute, it will show up as a key/value pair in the URL after the # sign
// 