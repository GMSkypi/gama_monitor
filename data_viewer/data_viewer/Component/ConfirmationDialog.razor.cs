using System;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace data_viewer.Component
{
    public partial class ConfirmationDialog: ComponentBase, IDisposable
    {
        [Parameter] public String message { get; set; }
        [Inject] public DialogService dialogService { get; set; }
 
        public void Dispose()
        {
        }
        private void ValidSubmit()
        {
            dialogService.Close(true);
        }
    }
}