#pragma checksum "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/Dashboard.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "daf12df265d289dc87cf96473a65af048f8d690b"
// <auto-generated/>
#pragma warning disable 1591
namespace data_viewer.Pages
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
#nullable restore
#line 2 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/Dashboard.razor"
using data_viewer.Model.Notification;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/Dashboard.razor"
using data_viewer.Component;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/dashboard")]
    public partial class Dashboard : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Dashboard</h3>\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
#nullable restore
#line 6 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/Dashboard.razor"
 foreach (var container in data)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-sm pb-2");
            __builder.OpenComponent<data_viewer.Component.ContainerView>(5);
            __builder.AddAttribute(6, "container", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<data_viewer.Model.Container>(
#nullable restore
#line 9 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/Dashboard.razor"
                                     container

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 11 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/Dashboard.razor"
}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
