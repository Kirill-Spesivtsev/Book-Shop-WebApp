using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project
{
    public class TimerTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";    
            output.Content.SetContent($"Текущее время: {DateTime.Now.ToString("HH:mm:ss")}");
        }
    }
}
