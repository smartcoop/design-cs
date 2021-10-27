using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Smart.Design.Razor.TagHelpers.Extensions
{
    public static class TagHelperOutputExtensions
    {
        /// <summary>
        /// Clear's all attribute of <paramref name="output"/> but keeps <c>class</c> attribute.
        /// The <c>class</c> attribute is retrieved from <paramref name="context"/>
        /// </summary>
        /// <param name="output"></param>
        /// <param name="context"></param>
        public static void ClearAndCopyClassAttribute(this TagHelperOutput output, TagHelperContext context)
        {
            output.Attributes.Clear();
            if (context.AllAttributes.ContainsName("class"))
                output.CopyHtmlAttribute("class", context);
        }

        /// <summary>
        /// Removes all attributes of <see cref="TagHelperOutput"/>
        /// </summary>
        /// <param name="output"></param>
        public static void ClearAllAttributes(this TagHelperOutput output)
        {
            output.Attributes.Clear();
        }
    }
}
