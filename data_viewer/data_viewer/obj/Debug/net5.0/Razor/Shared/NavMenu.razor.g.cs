#pragma checksum "/home/gama/gama_monitor/data_viewer/data_viewer/Shared/NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8124bb9b7b5ae39b9e6407cce13d527733711551"
// <auto-generated/>
#pragma warning disable 1591
namespace data_viewer.Shared
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
#line 13 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddAttribute(2, "b-wtjfv14z3t");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "row pb-1");
            __builder.AddAttribute(5, "b-wtjfv14z3t");
            __builder.AddMarkupContent(6, "<div class=\"col-4 d-flex flex-column\" b-wtjfv14z3t><a class=\"navbar-brand\" href b-wtjfv14z3t>Monitor</a></div>\n        ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "col-8 d-flex flex-column");
            __builder.AddAttribute(9, "b-wtjfv14z3t");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(10);
            __builder.AddAttribute(11, "Text", "LOGOUT");
            __builder.AddAttribute(12, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 7 "/home/gama/gama_monitor/data_viewer/data_viewer/Shared/NavMenu.razor"
                                                     ButtonStyle.Secondary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 7 "/home/gama/gama_monitor/data_viewer/data_viewer/Shared/NavMenu.razor"
                                                                                    Logout

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\n\n");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", 
#nullable restore
#line 12 "/home/gama/gama_monitor/data_viewer/data_viewer/Shared/NavMenu.razor"
             navMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(17, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "/home/gama/gama_monitor/data_viewer/data_viewer/Shared/NavMenu.razor"
                                        ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "b-wtjfv14z3t");
            __builder.OpenElement(19, "ul");
            __builder.AddAttribute(20, "class", "nav flex-column");
            __builder.AddAttribute(21, "b-wtjfv14z3t");
            __builder.OpenElement(22, "li");
            __builder.AddAttribute(23, "class", "nav-item px-3");
            __builder.AddAttribute(24, "b-wtjfv14z3t");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(25);
            __builder.AddAttribute(26, "class", "nav-link");
            __builder.AddAttribute(27, "href", "dashboard");
            __builder.AddAttribute(28, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 15 "/home/gama/gama_monitor/data_viewer/data_viewer/Shared/NavMenu.razor"
                                                              NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(29, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(30, "<span class=\"oi oi-list-rich\" aria-hidden=\"true\" b-wtjfv14z3t></span> Dashboard\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\n        ");
            __builder.OpenElement(32, "li");
            __builder.AddAttribute(33, "class", "nav-item px-3");
            __builder.AddAttribute(34, "b-wtjfv14z3t");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(35);
            __builder.AddAttribute(36, "class", "nav-link");
            __builder.AddAttribute(37, "href", "list");
            __builder.AddAttribute(38, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(39, "<span class=\"oi oi-list-rich\" aria-hidden=\"true\" b-wtjfv14z3t></span> Containers\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\n        ");
            __builder.OpenElement(41, "li");
            __builder.AddAttribute(42, "class", "nav-item px-3");
            __builder.AddAttribute(43, "b-wtjfv14z3t");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(44);
            __builder.AddAttribute(45, "class", "nav-link");
            __builder.AddAttribute(46, "href", "notifications");
            __builder.AddAttribute(47, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(48, "<span class=\"oi oi-plus\" aria-hidden=\"true\" b-wtjfv14z3t></span> Notifications\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\n        ");
            __builder.OpenElement(50, "li");
            __builder.AddAttribute(51, "class", "nav-item px-3");
            __builder.AddAttribute(52, "b-wtjfv14z3t");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(53);
            __builder.AddAttribute(54, "class", "nav-link");
            __builder.AddAttribute(55, "href", "configuration");
            __builder.AddAttribute(56, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(57, "<span class=\"oi oi-plus\" aria-hidden=\"true\" b-wtjfv14z3t></span> Configuration\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\n        ");
            __builder.OpenElement(59, "li");
            __builder.AddAttribute(60, "class", "nav-item px-3");
            __builder.AddAttribute(61, "b-wtjfv14z3t");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(62);
            __builder.AddAttribute(63, "class", "nav-link");
            __builder.AddAttribute(64, "href", "profile");
            __builder.AddAttribute(65, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(66, "<span class=\"oi oi-plus\" aria-hidden=\"true\" b-wtjfv14z3t></span> User profile\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\n        ");
            __builder.OpenElement(68, "li");
            __builder.AddAttribute(69, "class", "nav-item px-3");
            __builder.AddAttribute(70, "b-wtjfv14z3t");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(71);
            __builder.AddAttribute(72, "class", "nav-link");
            __builder.AddAttribute(73, "href", "removedata");
            __builder.AddAttribute(74, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(75, "<span class=\"oi oi-plus\" aria-hidden=\"true\" b-wtjfv14z3t></span> Data removal\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
