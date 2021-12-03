using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Container;

public interface IContainerHtmlGenerator
{
    /// <summary>
    /// Generates a &lt;div&gt; that is a smart container.
    /// More info can be seen <see href="https://design.smart.coop/development/docs/o-container.html">here</see>.
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    TagBuilder GenerateSmartContainer(ContainerSize size);
}