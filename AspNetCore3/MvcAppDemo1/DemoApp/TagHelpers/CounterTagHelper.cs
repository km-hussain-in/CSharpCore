using System.Collections.Concurrent;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DemoApp.TagHelpers
{
	[HtmlTargetElement("span", Attributes = "demo-count-for")]
	public class CounterTagHelper : TagHelper
	{
		private static ConcurrentDictionary<string, int> counters = new ConcurrentDictionary<string, int>();
		
		public string DemoCountFor {get; set;}
		
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			int count;
			counters.TryGetValue(DemoCountFor, out count);
			counters[DemoCountFor] = ++count;
			output.Attributes.RemoveAll("demo-count-for");
			output.Content.SetContent(count.ToString());
		}
	}
	
}

