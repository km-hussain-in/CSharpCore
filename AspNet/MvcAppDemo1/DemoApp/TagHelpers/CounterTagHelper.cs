using System.Collections.Concurrent;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DemoApp.TagHelpers
{
    [HtmlTargetElement("span", Attributes = "count-for")]
    public class CounterTagHelper : TagHelper
    {
        private static ConcurrentDictionary<string, int> counters = new ConcurrentDictionary<string, int>();

        public string CountFor {get; set;}

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            int count;
            counters.TryGetValue(CountFor, out count);
            counters[CountFor] = ++count;
            output.Attributes.RemoveAll("count-for");
            output.Content.SetContent(count.ToString());
        }
    }
}