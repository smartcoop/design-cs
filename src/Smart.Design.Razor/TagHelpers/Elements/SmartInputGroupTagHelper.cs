﻿using System;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Base;
using Smart.Design.Razor.TagHelpers.Constants;
using Smart.Design.Razor.TagHelpers.Extensions;
using Smart.Design.Razor.TagHelpers.Html;

namespace Smart.Design.Razor.TagHelpers.Elements
{
    [HtmlTargetElement(TagNames.SmartInputGroupTagName)]
    public class SmartInputGroupTagHelper : BaseTagHelper
    {
        private const string AlignmentAttributeName = "align";
        private const string ForAttributeName = "asp-for";
        private const string GroupedTextAttributeName = "grouped-text";
        private const string IconAttributeName = "icon";
        private const string PlaceholderAttributeName = "placeholder";
        private const string ValueAttributeName = "value";

        public SmartInputGroupTagHelper(ISmartHtmlGenerator smartHtmlGenerator) : base(smartHtmlGenerator)
        {
        }

        [HtmlAttributeName(AlignmentAttributeName)]
        public Alignment Alignment { get; set; }

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get ; set ; }

        [HtmlAttributeName(GroupedTextAttributeName)]
        public string GroupedText { get; set; }

        [HtmlAttributeName(IconAttributeName)]
        public Icon Icon { set; get; }

        [HtmlAttributeName(PlaceholderAttributeName)]
        public string Placeholder { get; set; }

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrWhiteSpace(GroupedText) && Icon != Icon.None)
            {
                throw new InvalidOperationException("input group cannot have and icon and a grouped text set");
            }

            var inputGroup = HtmlGenerator.GenerateInputGroup(ViewContext, Id, Name, Placeholder, Value, For, Alignment, Icon, GroupedText);

            output.TagName = inputGroup.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;

            output.ClearAndMergeAttributes(inputGroup);

            output.Content.SetHtmlContent(inputGroup.InnerHtml);
        }
    }
}