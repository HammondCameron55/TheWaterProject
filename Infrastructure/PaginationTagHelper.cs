using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PaginationTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }

        public string? PageAction { get; set; } // C# knows that PageAction is refering to page-action in the view
        public PaginationInfo PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper? urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder? result = new TagBuilder("div");

                for (int i = 1; i <= PageModel.TotalPages; i++) // Switch TotalPages for TotalNumPages if stuff breaks
                {
                    TagBuilder? tag = new TagBuilder("a");
                    string? url = urlHelper.Action(PageAction, new { pageNum = i });
                    tag.Attributes["href"] = url;
                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }
                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
//Explain this page
// The PaginationTagHelper class is a custom tag helper that is used to generate pagination links in a view.
// The tag helper is used to generate a list of links that allow the user to navigate between pages of a list of items.
// The tag helper takes a PaginationInfo object as a parameter, which contains information about the current page, the number of items per page, and the total number of items in the list.
// The tag helper uses the IUrlHelperFactory interface to generate URLs for the pagination links.
// The Process method of the tag helper generates the pagination links and adds them to the output of the tag helper.
// The tag helper is used in a view by adding a div element with the page-model attribute set to the name of the PaginationInfo object, and the page-action attribute set to the name of the action method that handles the pagination.
// The tag helper is used in the Index view of the HomeController to generate pagination links for the list of projects.
