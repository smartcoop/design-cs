using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Design.Razor.TagHelpers.Panel;

public class PanelHtmlGenerator : IPanelHtmlGenerator
{

    /// <inheritdoc />
    public virtual TagBuilder GeneratePanel(string? header, IHtmlContent content)
    {
        var panel = new TagBuilder("div");
        panel.AddCssClass("c-panel");

        // div that contains the actual header html element.
        var panelHeader = new TagBuilder("div");
        panelHeader.AddCssClass("c-panel__header");

        // Actual header title.
        var headerTagBuilder = new TagBuilder("h2");
        headerTagBuilder.AddCssClass("c-panel__title");
        if (!string.IsNullOrEmpty(header))
        {
            headerTagBuilder.InnerHtml.SetContent(header);
        }

        panelHeader.InnerHtml.AppendHtml(headerTagBuilder);

        // div containing the body
        var panelBody = new TagBuilder("div");
        panelBody.AddCssClass("c-panel__body");
        panelBody.InnerHtml.AppendHtml(content);

        panel.InnerHtml.AppendHtml(panelHeader);
        panel.InnerHtml.AppendHtml(panelBody);

        return panel;
    }
}