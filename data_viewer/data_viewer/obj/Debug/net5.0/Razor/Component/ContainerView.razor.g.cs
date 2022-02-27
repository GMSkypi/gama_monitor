#pragma checksum "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "138c87880ab88409a9d5c4dbde1d238f97c7167f"
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
#nullable restore
#line 13 "/home/gama/gama_monitor/data_viewer/data_viewer/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    public partial class ContainerView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenCard>(0);
            __builder.AddAttribute(1, "Style", "width: 490px; cursor: pointer;");
            __builder.AddAttribute(2, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 1 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                                             DetailClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(4, "div");
                __builder2.AddAttribute(5, "class", "center");
                __builder2.OpenElement(6, "h4");
                __builder2.AddContent(7, 
#nullable restore
#line 3 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
             container.id

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 4 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
             if (_notRunning)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                 if (container != null)
                {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(8, "p");
                __builder2.AddAttribute(9, "style", "background-color:tomato;");
                __builder2.AddContent(10, "Container not running since ");
                __builder2.AddContent(11, 
#nullable restore
#line 8 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                                                                      container.lastRecord

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 9 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                }
                else
                {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(12, "<p style=\"background-color:tomato;\">Container not running</p>");
#nullable restore
#line 13 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                 
            }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(13, "\n    ");
                __builder2.OpenElement(14, "div");
                __builder2.AddAttribute(15, "class", "row pb-1");
                __builder2.OpenComponent<Radzen.Blazor.RadzenChart>(16);
                __builder2.AddAttribute(17, "Style", "width: 230px; height: 140px");
                __builder2.AddAttribute(18, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __Blazor.data_viewer.Component.ContainerView.TypeInference.CreateRadzenAreaSeries_0(__builder3, 19, 20, 
#nullable restore
#line 19 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                     _cpuData

#line default
#line hidden
#nullable disable
                    , 21, "dateTime", 22, "Total CPU usage", 23, 
#nullable restore
#line 19 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                                                                                             LineType.Solid

#line default
#line hidden
#nullable disable
                    , 24, "red", 25, "red", 26, "totalPercents");
                    __builder3.AddMarkupContent(27, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenCategoryAxis>(28);
                    __builder3.AddAttribute(29, "Padding", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Double>(
#nullable restore
#line 21 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                         0

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(30, "FormatString", "{0:HH:mm:ss}");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(31, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenValueAxis>(32);
                    __builder3.AddAttribute(33, "Formatter", new System.Func<System.Object, System.String>(
#nullable restore
#line 22 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                         value => ((double) long.Parse((value).ToString()) / 1000).ToString() + " %"

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(34, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridLines>(35);
                    __builder3.AddAttribute(36, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 23 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                      true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(37, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenChartTooltipOptions>(38);
                    __builder3.AddAttribute(39, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 24 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                                false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(40, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLegend>(41);
                    __builder3.AddAttribute(42, "Position", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.Blazor.LegendPosition>(
#nullable restore
#line 25 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                    LegendPosition.Top

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentReferenceCapture(43, (__value) => {
#nullable restore
#line 18 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                           _cpuUsageChart = (Radzen.Blazor.RadzenChart)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(44, "\n\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenChart>(45);
                __builder2.AddAttribute(46, "Style", "width: 230px; height: 140px");
                __builder2.AddAttribute(47, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __Blazor.data_viewer.Component.ContainerView.TypeInference.CreateRadzenAreaSeries_1(__builder3, 48, 49, 
#nullable restore
#line 29 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                     _memoryData

#line default
#line hidden
#nullable disable
                    , 50, "dateTime", 51, "Memory", 52, 
#nullable restore
#line 29 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                                                                                       LineType.Solid

#line default
#line hidden
#nullable disable
                    , 53, "memoryUsed");
                    __builder3.AddMarkupContent(54, "\n            ");
                    __Blazor.data_viewer.Component.ContainerView.TypeInference.CreateRadzenAreaSeries_2(__builder3, 55, 56, 
#nullable restore
#line 31 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                     _memoryData

#line default
#line hidden
#nullable disable
                    , 57, "dateTime", 58, "Swap", 59, 
#nullable restore
#line 31 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                                                                                     LineType.Dashed

#line default
#line hidden
#nullable disable
                    , 60, "swap");
                    __builder3.AddMarkupContent(61, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenCategoryAxis>(62);
                    __builder3.AddAttribute(63, "Padding", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Double>(
#nullable restore
#line 33 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                         0

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(64, "FormatString", "{0:HH:mm:ss}");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(65, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenValueAxis>(66);
                    __builder3.AddAttribute(67, "Formatter", new System.Func<System.Object, System.String>(
#nullable restore
#line 34 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                         value => ((double) long.Parse((value).ToString()) / 1000000).ToString() + " MB"

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(68, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridLines>(69);
                    __builder3.AddAttribute(70, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 35 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                      true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(71, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenChartTooltipOptions>(72);
                    __builder3.AddAttribute(73, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 36 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                                false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(74, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLegend>(75);
                    __builder3.AddAttribute(76, "Position", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.Blazor.LegendPosition>(
#nullable restore
#line 37 "/home/gama/gama_monitor/data_viewer/data_viewer/Component/ContainerView.razor"
                                    LegendPosition.Top

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.data_viewer.Component.ContainerView
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateRadzenAreaSeries_0<TItem>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.Generic.IEnumerable<TItem> __arg0, int __seq1, global::System.String __arg1, int __seq2, global::System.String __arg2, int __seq3, global::Radzen.Blazor.LineType __arg3, int __seq4, global::System.String __arg4, int __seq5, global::System.String __arg5, int __seq6, global::System.String __arg6)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenAreaSeries<TItem>>(seq);
        __builder.AddAttribute(__seq0, "Data", __arg0);
        __builder.AddAttribute(__seq1, "CategoryProperty", __arg1);
        __builder.AddAttribute(__seq2, "Title", __arg2);
        __builder.AddAttribute(__seq3, "LineType", __arg3);
        __builder.AddAttribute(__seq4, "Fill", __arg4);
        __builder.AddAttribute(__seq5, "Stroke", __arg5);
        __builder.AddAttribute(__seq6, "ValueProperty", __arg6);
        __builder.CloseComponent();
        }
        public static void CreateRadzenAreaSeries_1<TItem>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.Generic.IEnumerable<TItem> __arg0, int __seq1, global::System.String __arg1, int __seq2, global::System.String __arg2, int __seq3, global::Radzen.Blazor.LineType __arg3, int __seq4, global::System.String __arg4)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenAreaSeries<TItem>>(seq);
        __builder.AddAttribute(__seq0, "Data", __arg0);
        __builder.AddAttribute(__seq1, "CategoryProperty", __arg1);
        __builder.AddAttribute(__seq2, "Title", __arg2);
        __builder.AddAttribute(__seq3, "LineType", __arg3);
        __builder.AddAttribute(__seq4, "ValueProperty", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateRadzenAreaSeries_2<TItem>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.Generic.IEnumerable<TItem> __arg0, int __seq1, global::System.String __arg1, int __seq2, global::System.String __arg2, int __seq3, global::Radzen.Blazor.LineType __arg3, int __seq4, global::System.String __arg4)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenAreaSeries<TItem>>(seq);
        __builder.AddAttribute(__seq0, "Data", __arg0);
        __builder.AddAttribute(__seq1, "CategoryProperty", __arg1);
        __builder.AddAttribute(__seq2, "Title", __arg2);
        __builder.AddAttribute(__seq3, "LineType", __arg3);
        __builder.AddAttribute(__seq4, "ValueProperty", __arg4);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
