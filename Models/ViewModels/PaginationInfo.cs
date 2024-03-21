namespace TheWaterProject.Models.ViewModels
{
    public class PaginationInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage);

    }
}

// Explain the purpose of the PaginationInfo class.
// The PaginationInfo class is used to store information about the pagination of a list of items. It contains properties for the total number of items, the number of items per page, the current page, and the total number of pages. It also contains a calculated property for the total number of pages, which is calculated by dividing the total number of items by the number of items per page and rounding up to the nearest whole number. This class is used in the ProjectsListViewModel class to store pagination information for a list of projects.
