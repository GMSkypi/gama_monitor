using System;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace data_viewer.Component
{
    public partial class ComfirmationDialog: ComponentBase, IDisposable
    {
        [Parameter] public String message { get; set; }
        [Inject]
        public DialogService DialogService { get; set; }
 
        public void Dispose()
        {
        }
        protected void ValidSubmit()
        {
            DialogService.Close(true);
        }
    }
}