#pragma checksum "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d27454e0a95475abe79aa13f1e12941c655a2e3e"
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
#line 13 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/removedata")]
    public partial class DataRemoval : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Data removing from database</h1>\n");
            __builder.OpenComponent<Radzen.Blazor.RadzenCard>(1);
            __builder.AddAttribute(2, "Class", "w-100");
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(4, "<h3>Container removal</h3>\n    ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenDataGrid<data_viewer.Model.Container>>(5);
                __builder2.AddAttribute(6, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 6 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(7, "FilterCaseSensitivity", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterCaseSensitivity>(
#nullable restore
#line 7 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                           FilterCaseSensitivity.CaseInsensitive

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(8, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 8 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 9 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                 true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(10, "PageSize", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 10 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                              5

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(11, "PagerHorizontalAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.HorizontalAlign>(
#nullable restore
#line 11 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                          HorizontalAlign.Center

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(12, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 12 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                  true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(13, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<data_viewer.Model.Container>>(
#nullable restore
#line 13 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                           _data

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(14, "IsLoading", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 15 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                _isLoading

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(15, "Count", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 16 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                            _count

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(16, "LoadData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.LoadDataArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.LoadDataArgs>(this, 
#nullable restore
#line 17 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                               LoadData

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(17, "Style", "cursor: pointer;");
                __builder2.AddAttribute(18, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<data_viewer.Model.Container>>(19);
                    __builder3.AddAttribute(20, "Property", "Container.id");
                    __builder3.AddAttribute(21, "Title", "ID");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(22, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<data_viewer.Model.Container>>(23);
                    __builder3.AddAttribute(24, "Property", "Container.dockerID");
                    __builder3.AddAttribute(25, "Title", "DockerID");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(26, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<data_viewer.Model.Container>>(27);
                    __builder3.AddAttribute(28, "Property", "Container.name");
                    __builder3.AddAttribute(29, "Title", "Name");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(30, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<data_viewer.Model.Container>>(31);
                    __builder3.AddAttribute(32, "Property", "Container.image");
                    __builder3.AddAttribute(33, "Title", "Image");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(34, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<data_viewer.Model.Container>>(35);
                    __builder3.AddAttribute(36, "Property", "Container.lastRecord");
                    __builder3.AddAttribute(37, "Title", "Last record");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(38, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<data_viewer.Model.Container>>(39);
                    __builder3.AddAttribute(40, "Title", "Action");
                    __builder3.AddAttribute(41, "Width", "135px");
                    __builder3.AddAttribute(42, "Template", (Microsoft.AspNetCore.Components.RenderFragment<data_viewer.Model.Container>)((container) => (__builder4) => {
                        __builder4.OpenElement(43, "div");
                        __builder4.AddAttribute(44, "class", "row pb-1");
                        __builder4.OpenComponent<Radzen.Blazor.RadzenButton>(45);
                        __builder4.AddAttribute(46, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 29 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                                   ButtonStyle.Danger

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(47, "Text", "Remove");
                        __builder4.AddAttribute(48, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 31 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                             () => RemoveContainer(container)

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.CloseComponent();
                        __builder4.CloseElement();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentReferenceCapture(49, (__value) => {
#nullable restore
#line 5 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                          _dataGrid = (Radzen.Blazor.RadzenDataGrid<data_viewer.Model.Container>)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(50, "\n");
            __builder.OpenComponent<Radzen.Blazor.RadzenCard>(51);
            __builder.AddAttribute(52, "Class", "w-100");
            __builder.AddAttribute(53, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(54, "div");
                __builder2.AddAttribute(55, "class", "row pb-1");
                __builder2.AddMarkupContent(56, "<div class=\"col-2 d-flex flex-column\"><h3>Data removal</h3></div>\n        ");
                __builder2.OpenElement(57, "div");
                __builder2.AddAttribute(58, "class", "col-5 d-flex flex-column");
                __builder2.AddMarkupContent(59, "<label>\n                Remove data to date \n            </label>\n            ");
                __Blazor.data_viewer.Pages.DataRemoval.TypeInference.CreateRadzenDatePicker_0(__builder2, 60, 61, 
#nullable restore
#line 48 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                        true

#line default
#line hidden
#nullable disable
                , 62, 
#nullable restore
#line 49 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                           true

#line default
#line hidden
#nullable disable
                , 63, "1.5", 64, "5", 65, "10", 66, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.DateTime?>(this, 
#nullable restore
#line 53 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                       args => OnDateTimeChange(args, "MM/dd/yyyy HH:mm")

#line default
#line hidden
#nullable disable
                ), 67, "MM/dd/yyyy HH:mm", 68, "w-100", 69, 
#nullable restore
#line 47 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                           _dateTimeDatePicker

#line default
#line hidden
#nullable disable
                , 70, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _dateTimeDatePicker = __value, _dateTimeDatePicker)), 71, () => _dateTimeDatePicker);
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(72, "\n    ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenDataGrid<data_viewer.Extension.EnumExtension<data_viewer.Model.Notification.Group>>>(73);
                __builder2.AddAttribute(74, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 58 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                        true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(75, "FilterCaseSensitivity", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterCaseSensitivity>(
#nullable restore
#line 59 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                               FilterCaseSensitivity.CaseInsensitive

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(76, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 60 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                    FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(77, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 61 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                     true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(78, "PageSize", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 62 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                  5

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(79, "PagerHorizontalAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.HorizontalAlign>(
#nullable restore
#line 63 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                              HorizontalAlign.Center

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(80, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 64 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                      true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(81, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<data_viewer.Extension.EnumExtension<data_viewer.Model.Notification.Group>>>(
#nullable restore
#line 65 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
               _enumGroups

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(82, "Style", "cursor: pointer;");
                __builder2.AddAttribute(83, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<data_viewer.Extension.EnumExtension<data_viewer.Model.Notification.Group>>>(84);
                    __builder3.AddAttribute(85, "Property", "EnumExtension<Group>.enumName");
                    __builder3.AddAttribute(86, "Title", "Metric name");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(87, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<data_viewer.Extension.EnumExtension<data_viewer.Model.Notification.Group>>>(88);
                    __builder3.AddAttribute(89, "Title", "Action");
                    __builder3.AddAttribute(90, "Width", "135px");
                    __builder3.AddAttribute(91, "Template", (Microsoft.AspNetCore.Components.RenderFragment<data_viewer.Extension.EnumExtension<data_viewer.Model.Notification.Group>>)((group) => (__builder4) => {
                        __builder4.OpenElement(92, "div");
                        __builder4.AddAttribute(93, "class", "row pb-1");
                        __builder4.OpenComponent<Radzen.Blazor.RadzenButton>(94);
                        __builder4.AddAttribute(95, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 74 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                                   ButtonStyle.Danger

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(96, "Text", "Remove");
                        __builder4.AddAttribute(97, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 76 "/home/gama/gama_monitor/data_viewer/data_viewer/Pages/DataRemoval.razor"
                                             () => RemoveMetricData(group)

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.CloseComponent();
                        __builder4.CloseElement();
                    }
                    ));
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
namespace __Blazor.data_viewer.Pages.DataRemoval
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateRadzenDatePicker_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Boolean __arg0, int __seq1, global::System.Boolean __arg1, int __seq2, global::System.String __arg2, int __seq3, global::System.String __arg3, int __seq4, global::System.String __arg4, int __seq5, global::Microsoft.AspNetCore.Components.EventCallback<global::System.DateTime?> __arg5, int __seq6, global::System.String __arg6, int __seq7, System.Object __arg7, int __seq8, global::System.Object __arg8, int __seq9, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg9, int __seq10, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg10)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenDatePicker<TValue>>(seq);
        __builder.AddAttribute(__seq0, "ShowTime", __arg0);
        __builder.AddAttribute(__seq1, "ShowSeconds", __arg1);
        __builder.AddAttribute(__seq2, "HoursStep", __arg2);
        __builder.AddAttribute(__seq3, "MinutesStep", __arg3);
        __builder.AddAttribute(__seq4, "SecondsStep", __arg4);
        __builder.AddAttribute(__seq5, "Change", __arg5);
        __builder.AddAttribute(__seq6, "DateFormat", __arg6);
        __builder.AddAttribute(__seq7, "Class", __arg7);
        __builder.AddAttribute(__seq8, "Value", __arg8);
        __builder.AddAttribute(__seq9, "ValueChanged", __arg9);
        __builder.AddAttribute(__seq10, "ValueExpression", __arg10);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
