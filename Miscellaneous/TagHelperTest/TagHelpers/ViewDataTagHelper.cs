using System.Threading.Tasks;
using Mvc = Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperTest.TagHelpers
{
	[HtmlTargetElement(Attributes =  "view-data-id")]
	public class ViewDataTagHelper : TagHelper
	{
		public string ViewDataId {get; set;}

		[HtmlAttributeNotBound]
		[Mvc.ViewFeatures.ViewContext]
		public Mvc.Rendering.ViewContext ViewContext {get; set;} 

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			string value = ViewContext.ViewData[ViewDataId].ToString();
			var body = await output.GetChildContentAsync();

			output.Attributes.RemoveAll("view-data-id");
			if(body.GetContent().Length > 0)
				output.PostContent.SetContent($" {value}");
			else
				output.Content.SetContent(value);				
		}
	}
}

