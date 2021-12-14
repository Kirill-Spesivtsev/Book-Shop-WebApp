using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.TagHelpers
{
    public class PaginatorTagHelper : TagHelper
    {
        LinkGenerator _linkGenerator;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string PaginatorClassCSS { get; set; }
        public int? GroupId { get; set; }

        public PaginatorTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "pnav";

            var ulTB = new TagBuilder("ul");
            ulTB.AddCssClass("pagination");
            ulTB.AddCssClass(PaginatorClassCSS);

            for (int i = 1; i <= TotalPages; i++)
            {
                var url = _linkGenerator.GetPathByAction(Action, Controller,
                new
                {
                    pageNumber = i, 
                    genre = GroupId == 0
                        ? null
                        : GroupId
                });
                var item = GetPaginatorItem(
                    url: url, text: i.ToString(),
                    active: i == CurrentPage,
                    disabled: i == CurrentPage
                );
                ulTB.InnerHtml.AppendHtml(item);
            }
            output.Content.AppendHtml(ulTB);
        }

        private TagBuilder GetPaginatorItem(string url, string text, bool active = false, bool disabled = false)
        {
            var liTB = new TagBuilder("li");
            liTB.AddCssClass("page-item");
            liTB.AddCssClass(active ? "active" : "");

            var aTB = new TagBuilder("a");
            aTB.AddCssClass("page-link");
            aTB.Attributes.Add("href", url);
            aTB.InnerHtml.Append(text);
 
            liTB.InnerHtml.AppendHtml(aTB);

            return liTB;
        }

    }
}
