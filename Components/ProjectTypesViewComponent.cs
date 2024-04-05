using Microsoft.AspNetCore.Mvc;
using TheWaterProject.Models;

namespace TheWaterProject.Components
{
    public class ProjectTypesViewComponent : ViewComponent 
    {

        private IWaterRepository _waterRepo;

        //Constructor
        public ProjectTypesViewComponent(IWaterRepository temp)
        {
            _waterRepo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedProjectType = RouteData?.Values["projectType"]; // RouteData is a property of the ViewComponent class that contains information about the current request
            //The ViewBag is a dynamic object that is used to pass data from a controller to a view. It is a dictionary that can store key/value pairs of data that can be accessed in the view.
            //This enables the view to access data that is not part of the model.
            //Specifically this is enabling us to have the selected project type to be highlighted in the view


            var projectTypes = _waterRepo.Projects
                .Select(x => x.ProjectType)
                .Distinct()
                .OrderBy(x => x);

            return View(projectTypes); // This will return the default view for the view component
            // The view component will look for a view with the same name as the view component class in the Views/Shared/Components folder
            // It returns an IViewComponentResult object, which is a base class for all view component results Maybe
        }
    }
}
