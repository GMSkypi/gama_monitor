#pragma checksum "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e47b14099ed948eb74a0457d2fa9f5510a5eae7"
// <auto-generated/>
#pragma warning disable 1591
namespace data_viewer.Component.User
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
    public partial class UsernameView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenTemplateForm<Model>>(0);
            __builder.AddAttribute(1, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Model>(
#nullable restore
#line 1 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor"
                                        model

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "Submit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Model>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Model>(this, 
#nullable restore
#line 1 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor"
                                                      OnSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "InvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.FormInvalidSubmitEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.FormInvalidSubmitEventArgs>(this, 
#nullable restore
#line 1 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor"
                                                                              OnInvalidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenFieldset>(5);
                __builder2.AddAttribute(6, "Text", "Username");
                __builder2.AddAttribute(7, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(8, "div");
                    __builder3.AddAttribute(9, "class", "row mb-5");
                    __builder3.OpenElement(10, "div");
                    __builder3.AddAttribute(11, "class", "col-md-4");
                    __builder3.AddAttribute(12, "style", "align-self: center;");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(13);
                    __builder3.AddAttribute(14, "Text", "Username");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(15, "\n            ");
                    __builder3.OpenElement(16, "div");
                    __builder3.AddAttribute(17, "class", "col");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenTextBox>(18);
                    __builder3.AddAttribute(19, "style", "display: block");
                    __builder3.AddAttribute(20, "Name", "new username");
                    __builder3.AddAttribute(21, "Class", "w-100");
                    __builder3.AddAttribute(22, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 8 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor"
                                                                                       model.Username

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(23, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.Username = __value, model.Username))));
                    __builder3.AddAttribute(24, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.Username));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(25, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(26);
                    __builder3.AddAttribute(27, "Component", "Username");
                    __builder3.AddAttribute(28, "Text", "Enter username");
                    __builder3.AddAttribute(29, "Popup", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 9 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor"
                                                                                            popup

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(30, "Style", "position: absolute");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(31, "\n        ");
                    __builder3.OpenElement(32, "div");
                    __builder3.AddAttribute(33, "class", "row mb-4");
                    __builder3.OpenElement(34, "div");
                    __builder3.AddAttribute(35, "class", "col-md-4");
                    __builder3.AddAttribute(36, "style", "align-self: center;");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(37);
                    __builder3.AddAttribute(38, "Text", "Repeat Username");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(39, "\n            ");
                    __builder3.OpenElement(40, "div");
                    __builder3.AddAttribute(41, "class", "col");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenTextBox>(42);
                    __builder3.AddAttribute(43, "style", "display: block");
                    __builder3.AddAttribute(44, "Name", "RepeatUsername");
                    __builder3.AddAttribute(45, "Class", "w-100");
                    __builder3.AddAttribute(46, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor"
                                                                                         model.RepeatUsername

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(47, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => model.RepeatUsername = __value, model.RepeatUsername))));
                    __builder3.AddAttribute(48, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => model.RepeatUsername));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(49, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(50);
                    __builder3.AddAttribute(51, "Component", "RepeatUsername");
                    __builder3.AddAttribute(52, "Text", "Repeat your username");
                    __builder3.AddAttribute(53, "Popup", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 18 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor"
                                                                                                       popup

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(54, "Style", "position: absolute");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(55, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenCompareValidator>(56);
                    __builder3.AddAttribute(57, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 19 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor"
                                                  !string.IsNullOrEmpty(model.RepeatUsername)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(58, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 19 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor"
                                                                                                      model.Username

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(59, "Component", "RepeatUsername");
                    __builder3.AddAttribute(60, "Text", "Username should be the same");
                    __builder3.AddAttribute(61, "Popup", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 19 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor"
                                                                                                                                                                                          popup

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(62, "Style", "position: absolute");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(63, "\n        ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(64);
                    __builder3.AddAttribute(65, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 22 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/User/UsernameView.razor"
                                  ButtonType.Submit

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(66, "Text", "Submit");
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
