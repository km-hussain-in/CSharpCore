using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperTest.TagHelpers
{
	public class ServerTimeTagHelper : TagHelper
	{
		public string OutputFormat {get; set;}

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "span";
			output.TagMode = TagMode.StartTagAndEndTag;
			output.Content.SetContent(System.DateTime.Now.ToString(OutputFormat));
		}
	}
}

