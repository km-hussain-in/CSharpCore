using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MvcRouteTest.TagHelpers
{
	[HtmlTargetElement(Attributes = "server-time-format")]
	public class ServerTimeTagHelper : TagHelper
	{
		public string ServerTimeFormat {get; set;}

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var value = DateTime.Now.ToString(ServerTimeFormat);
			output.Attributes.RemoveAll("server-time-format");
			output.Content.SetContent(value);
		}
	}
}

