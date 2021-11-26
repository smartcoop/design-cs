using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Smart.Design.Razor.Enums;
using Smart.Design.Razor.TagHelpers.Html.Options;

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
        /// Generate a form group with its label and an empty controls container.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="label">The label associated to the form group.</param>
        /// <param name="helperText"></param>
        /// <param name="controls">The content of the controls container.</param>
        /// <returns>A instance of a form group.</returns>
        TagBuilder GenerateFormGroup(string id, string name, string label, string helperText, TagBuilder controls);

        /// <summary>
        /// Generates a form group &lt;div&gt;.
        /// The combination of a form label and an element field are usually wrapped inside this element.
        /// The consistent markup pattern makes it easy to manipulate grouped form elements.
        /// </summary>
        /// <returns> An instance of the &lt;div&gt;</returns>
        TagBuilder GenerateFormGroup();

        /// <summary>
        /// Generate a &lt;label&gt; element.
        /// </summary>
        /// <param name="label">The value of the label.</param>
        /// <param name="labelFor"></param>
        /// <returns>A instance of the &lt;label&gt;</returns>
        TagBuilder GenerateFormGroupLabel(string label, string? labelFor);

        /// <summary>
        /// Generate a &lt;div&gt; in which are grouped element of a form group.
        /// </summary>
        /// <returns> An instance of the &lt;div&gt;</returns>
        TagBuilder GenerateFormGroupControlsContainer();

        /// <summary>
        /// Generates a smart design radio button.
        /// Documentation is available <see href="https://design.smart.coop/development/docs/c-radio-button.html">here</see>.
        /// </summary>
        /// <param name="id">The id of the generated &lt;input&gt; element.</param>
        /// <param name="name">The attribute name of the generated &lt;input&gt; element.</param>
        /// <param name="label">The label associated to the radio button.</param>
        /// <param name="value">Value of the generated &lt;input&gt; element.</param>
        /// <param name="checked">If the radio button is checked or not.</param>
        /// <param name="for">The <see cref="ModelExpression"/> passed to the tag helper.</param>
        /// <returns>A instance of a smart design radio button.</returns>
        TagBuilder GenerateSmartRadio(string id, string name, string label, string value, bool @checked, ModelExpression @for);

        /// <summary>
        /// Generate a &lt;div&gt; that represents a panel and is compliant with smart design.
        /// A panel is composed of two things: a header and a body.
        /// </summary>
        /// <param name="header">The header of the panel.</param>
        /// <param name="body">The content of the panel. This can be any html.</param>
        /// <returns>A instance of a &lt;div&gt; that represents a panel.</returns>
        TagBuilder GenerateSmartPanel(string header, IHtmlContent body);

        /// <summary>
        /// Generate a &lt;textarea&gt; that is compliant with smart design.
        /// </summary>
        /// <param name="id">The id of the &lt;textarea&gt;</param>
        /// <param name="name">The name of the &lt;textarea&gt;</param>
        /// <param name="rows">The number of rows of the &lt;textarea&gt;. This parameter is optional.</param>
        /// <param name="textareaSize"></param>
        /// <param name="for"></param>
        /// <returns>An instance of the &lt;textarea&gt;</returns>
        TagBuilder GenerateSmartTextArea(string id, string name, int? rows, TextAreaSize textareaSize, ModelExpression @for);

        /// <summary>
        /// Generate a div that represents the smart button toolbar.
        /// Documentation is available <see href="https://design.smart.coop/development/docs/c-button-toolbar.html">here</see>.
        /// </summary>
        /// <param name="layout">The orientation of the item inside the toolbar. Value are.</param>
        /// <param name="isCompact">Tells is there should be no space between items.</param>
        /// <returns>A instance of a smart button toolbar</returns>
        TagBuilder GenerateSmartButtonToolbar(ButtonToolbarLayout layout, bool isCompact);

        /// <summary>
        /// Generates a &lt;div&gt; that is a smart container.
        /// More info can be seen <see href="https://design.smart.coop/development/docs/o-container.html">here</see>.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        TagBuilder GenerateSmartContainer(ContainerSize size);

        /// <summary>
        /// Generate a &lt;hr&gt; that is compliant with smart design
        /// More information can be seen <see href="https://sesign.smart.coop">here</see>.
        /// </summary>
        /// <returns></returns>
        TagBuilder GenerateHorizontalRule();

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

        /// <summary>
        /// Generates a &lt;div&gt; that is a smart design grid.
        /// Documentation is available <see href="https://design.smart.coop/development/docs/o-grid.html">here</see>.
        /// </summary>
        /// <returns>An instance of the grid.</returns>
        TagBuilder GenerateSmartGrid();

        /// <summary>
        /// Generates a column for the smart grid.
        /// Documentation is available <see href="https://design.smart.coop/development/docs/o-grid.html">here</see>.
        /// </summary>
        /// <param name="width">The width of the column.</param>
        /// <returns>An instance of a column.</returns>
        TagBuilder GenerateSmartColumnGrid(int width);

        /// <summary>
        /// Generate a &lt;form&gt; compliant with smart design.
        /// </summary>
        /// <param name="layout">The layout to be applied.</param>
        /// <param name="content"></param>
        /// <returns>An instance of a form.</returns>
        TagBuilder GenerateForm(FormLayout layout, IHtmlContent content);

        /// <summary>
        /// Generates an &lt;input&gt; time compliant with smart design.
        /// </summary>
        /// <param name="id">Id attribute of the element.</param>
        /// <param name="name">Name attribute of the element.</param>
        /// <param name="value">The value of the input.</param>
        /// <param name="for">The <see cref="ModelExpression"/> associated to the html element.</param>
        /// <returns></returns>
        TagBuilder GenerateInputTime(string id, string name, DateTime? value, ModelExpression @for);

        /// <summary>
        /// Generates an smart design input group.
        /// See documentation <see href="https://design.smart.coop/development/docs/c-input-group.html">here</see>.
        /// </summary>
        /// <param name="viewContext"></param>
        /// <param name="id">d of the &lt;input&gt; element.</param>
        /// <param name="name">Name of the &lt;input&gt; element.</param>
        /// <param name="placeholder">Placeholder of the &lt;input&gt; element.</param>
        /// <param name="value">HTML value of the &lt;input&gt; element.</param>
        /// <param name="for">ModelExpression associated with the component.</param>
        /// <param name="alignment">The alignment of <paramref name="extraContent"/> or <paramref name="icon"/>. Can be at the start or beginning</param>
        /// <param name="icon">An <see cref="Icon"/> that can be aligned at the start or the end of the input group.</param>
        /// <param name="text"></param>
        /// <returns>A instance of an input group component.</returns>
        /// <remarks>There can be only either one icon or one extra content at a time.</remarks>
        /// <exception><see cref="ArgumentException"/> if <paramref name="extraContent"/> and <paramref name="icon"/> are specified.</exception>
        TagBuilder GenerateInputGroup(ViewContext viewContext,
            string id,
            string name,
            string placeholder,
            string value,
            ModelExpression @for,
            Alignment alignment,
            Icon icon, string text);

        TagBuilder GenerateFormGroupHelperText(string helperText);

        /// <summary>
        /// Generates a global banner widget compliant with smart design.
        /// Documentation is available <see href="https://design.smart.coop/development/docs/c-global-banner.html">here</see>.
        /// </summary>
        /// <param name="globalBannerType">The style <see cref="GlobalBannerType">type</see> of the banner.</param>
        /// <param name="label">The label displayed by the banner.</param>
        /// <returns>A instance of a global banner</returns>
        TagBuilder GenerateGlobalBanner(GlobalBannerType globalBannerType, string label);

        /// <summary>
        /// Generates an elevated card with shadows.
        /// </summary>
        /// <param name="elevation">Size of the elevation</param>
        /// <returns>A instance of an elevator.</returns>
        TagBuilder GenerateElevation(ElevationSize elevation);

        /// <summary>
        /// Generates a smart design alert stack.
        /// Documentation is available <see href="https://design.smart.coop/development/docs/c-alert-stack.html">here</see>.
        /// </summary>
        /// <param name="icon">The leading icon of the alert.</param>
        /// <param name="message">The message to be displayed.</param>
        /// <returns></returns>
        TagBuilder GenerateAlertStack(Icon icon, string message);

        /// <summary>
        /// Generates a smart design loader.
        /// Documentation is available <see ref="https://design.smart.coop/development/docs/c-loader.html">here</see>.
        /// </summary>
        /// <param name="loading">The state of the component, i.e. loading or not.</param>
        /// <returns>An instance of a smart design loader.</returns>
        TagBuilder GenerateLoader(bool loading);

        /// <summary>
        /// Generates a smart design avatar.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="imageUrl"></param>
        /// <param name="text">Associated text to the avatar</param>
        /// <param name="icon"></param>
        /// <param name="initial"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        TagBuilder GenerateAvatar(AvatarSize size, string imageUrl, string text, Icon icon, string initial, string link);

        /// <summary>
        /// Generates a smart design button.
        /// </summary>
        /// <param name="buttonOptions">Configuration of the smart design button properties.</param>
        /// <returns>A task that represents the asynchronous generation of an instance of a smart design button.</returns>
        Task<TagBuilder> GenerateSmartButton(SmartButtonOptions buttonOptions);

        /// <summary>
        /// Generate a empty &lt;nav&gt; element compliant with smart design tab whose purpose is containing smart design tab items.
        /// </summary>
        /// <param name="bordered">True if the tab items should be bordered.</param>
        /// <returns>An instance of a empty smart design tab.</returns>
        TagBuilder GenerateSmartTab(bool bordered);

        /// <summary>
        /// Generates a &lt;ul&gt; element whose purpose is containing smart design tab items.
        /// </summary>
        /// <returns>An instance of a &lt;ul&gt; element</returns>
        TagBuilder GenerateSmartTabItemsContainer();

        /// <summary>
        /// Generate a smart design tab item.
        /// </summary>
        /// <param name="label">Label of the tab item.</param>
        /// <param name="ref">Html reference to its html content.</param>
        /// <returns>A instance of a smart design tab item.</returns>
        TagBuilder GenerateSmartTabItem(string label, string @ref);

        /// <summary>
        /// Generates a smart design tab's section. A smart design tab's section is the content that is related to a smart design tab ite.
        /// </summary>
        /// <param name="id">Html id of the smart design tab section. The id should be matching of the smart design tab items.</param>
        /// <returns>A instance of a smart design tab section.</returns>
        TagBuilder GenerateSmartTabSection(string id);
    }
#nullable disable
}
