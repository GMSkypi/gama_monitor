#pragma checksum "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ComfirmationDialog.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "842d732453cde72552ec9a2346dc4b526e5ce7de"
// <auto-generated/>
#pragma warning disable 1591
namespace data_viewer.Component
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using data_viewer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using data_viewer.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
    public partial class ComfirmationDialog : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 1 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ComfirmationDialog.razor"
                  message

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 1 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ComfirmationDialog.razor"
                                          ValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(4);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(5, "\n    ");
                __builder2.OpenElement(6, "h3");
                __builder2.AddContent(7, "\"");
                __builder2.AddContent(8, 
#nullable restore
#line 3 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ComfirmationDialog.razor"
          message

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(9, "\"");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(10, "\n    ");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "d-flex flex-row justify-content-between");
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(13);
                __builder2.AddAttribute(14, "Text", "OK");
                __builder2.AddAttribute(15, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 5 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ComfirmationDialog.razor"
                                             ButtonStyle.Secondary

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(16, "type", "submit");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(17, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(18);
                __builder2.AddAttribute(19, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 6 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ComfirmationDialog.razor"
                               (args) => DialogService.Close(false)

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(20, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 6 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ComfirmationDialog.razor"
                                                                                   ButtonStyle.Light

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "Text", "Cancel");
                __builder2.CloseComponent();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
