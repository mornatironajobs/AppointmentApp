using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace SchedulingApp.Shared.Components;

/// <summary>
/// An <see cref="InputText"/> that updates its bound value on every keystroke (oninput) instead of on change.
/// </summary>
public class InputTextImmediate : InputText
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "input");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        if (!string.IsNullOrEmpty(NameAttributeValue))
        {
            builder.AddAttribute(2, "name", NameAttributeValue);
        }
        builder.AddAttribute(3, "class", CssClass);
        builder.AddAttribute(4, "value", CurrentValueAsString);
        builder.AddAttribute(5, "oninput", EventCallback.Factory.CreateBinder<string?>(this, v => CurrentValueAsString = v, CurrentValueAsString));
        builder.SetUpdatesAttributeName("value");
        builder.AddElementReferenceCapture(6, r => Element = r);
        builder.CloseElement();
    }
}
