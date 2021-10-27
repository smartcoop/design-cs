using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Smart.Design.Razor.Enums;

#nullable enable
namespace Smart.Design.Razor.TagHelpers.Html
{
    /// <summary>
    /// Contract for a service supporting <see cref="IHtmlHelper"/> and <c>ITagHelper</c> implementations compliant with
    /// <see href="https://design.smart.coop">smart design</see>.
    /// </summary>
    public interface ISmartHtmlGenerator
    {
        /// <summary>
        /// Generates a &lt;input&gt; text compliant with smart design guidelines.
        /// </summary>
        /// <param name="viewContext">A <see cref="ViewContext"/> instance for the current scope.</param>
        /// <param name="id">Id of the element</param>
        /// <param name="name">The name of the element</param>
        /// <param name="placeholder"></param>
        /// <param name="value">The value of the input</param>
        /// <param name="for">The <see cref="ModelExpression"/> for the <paramref name="name"/>.</param>
        /// <returns></returns>
        TagBuilder GenerateSmartInputText(ViewContext viewContext, string id, string name, string placeholder,
            object? value, ModelExpression @for);


        /// <summary>
        /// Generate a &lt;div&gt; that represents a panel and is compliant with smart design.
        /// A panel is composed of two things: a header and a body.
        /// </summary>
        /// <param name="header">The header of the panel.</param>
        /// <param name="body">The content of the panel. This can be any html.</param>
        /// <returns>A instance of a &lt;div&gt; that represents a panel.</returns>
        TagBuilder GenerateSmartPanel(string header, IHtmlContent body);

        /// <summary>
        /// Generates a &lt;div&gt; whose content is a &lt;svg&gt;.
        /// </summary>
        /// <param name="icon">The icon to render.</param>
        /// <returns>An instance of the icon.</returns>
        TagBuilder GenerateIcon(Icon icon);

        /// <summary>
        /// Generates asynchronously a div whose content is a &lt;svg&gt;.
        /// </summary>
        /// <param name="icon">The icon to render</param>
        /// <returns>
        /// A task that represents the rendering asynchronous operation.
        /// The task result is the instance of the icon.
        /// </returns>
        Task<TagBuilder> GenerateIconAsync(Icon icon);
    }
#nullable disable
}
