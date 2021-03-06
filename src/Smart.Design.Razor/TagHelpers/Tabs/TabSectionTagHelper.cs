using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;

namespace Smart.Design.Razor.TagHelpers.Tabs;

[HtmlTargetElement(TagNames.TabsSection)]
public class TabSectionTagHelper : TagHelper
{
    private readonly ITabsHtmlGenerator _smartHtmlGenerator;
    private const string IdAttributeName = "id";

    [HtmlAttributeName(IdAttributeName)]
    public string? Id { get; set; }

    public TabSectionTagHelper(ITabsHtmlGenerator smartHtmlGenerator)
    {
        _smartHtmlGenerator = smartHtmlGenerator;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var tabsSection = _smartHtmlGenerator.GenerateTabSection(Id);

        output.TagName = tabsSection.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.ClearAndMergeAttributes(tabsSection);
    }
}
