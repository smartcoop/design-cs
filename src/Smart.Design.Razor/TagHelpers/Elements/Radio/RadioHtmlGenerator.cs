using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Smart.Design.Razor.TagHelpers.Elements.Radio;

public class RadioHtmlGenerator : IRadioHtmlGenerator
{
    public TagBuilder GenerateSmartRadio(string? id, string? name, string? label, string? value, bool @checked, ModelExpression? @for)
    {
        var inputRadioContainer = new TagBuilder("div");

        inputRadioContainer.AddCssClass("c-radio");

        var radioName = !string.IsNullOrWhiteSpace(@for?.Name) ? @for.Name : name;

        var inputRadioTagBuilder = new TagBuilder("input");
        inputRadioTagBuilder.Attributes.Add("name", radioName);
        inputRadioTagBuilder.Attributes.Add("type", "radio");

        if (@checked)
        {
            inputRadioTagBuilder.Attributes.Add("checked", "checked");
        }

        var modelValue = Convert.ToString(@for?.Model, CultureInfo.CurrentCulture);

        if (modelValue != null &&
            string.Equals(modelValue, value, StringComparison.OrdinalIgnoreCase))
        {
            inputRadioTagBuilder.Attributes.Add("checked", "checked");
        }
        else if (!string.IsNullOrWhiteSpace(value))
        {
            inputRadioTagBuilder.Attributes.Add("value", value);
        }

        var labelTagBuilder = new TagBuilder("label");
        labelTagBuilder.InnerHtml.AppendHtml(inputRadioTagBuilder);
        labelTagBuilder.InnerHtml.Append(label!);

        inputRadioContainer.InnerHtml.AppendHtml(labelTagBuilder);

        return inputRadioContainer;
    }
}
