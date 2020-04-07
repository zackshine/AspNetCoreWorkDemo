using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22MVCIdentity.Data
{
    [HtmlTargetElement("My")]
    public class MyTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "black-div");
            output.Content.AppendHtml(GetTitle());
           
        }


        private TagBuilder GetTitle()
        {
            var builder = new TagBuilder("img");
            builder.AddCssClass("movie-year");
            builder.MergeAttribute("src", "/Capture.PNG");
            builder.MergeAttribute("alt", "AltImage");

            return builder;
        }

    }
}


  