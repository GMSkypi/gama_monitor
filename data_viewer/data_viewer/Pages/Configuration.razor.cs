using System;
using data_viewer.services;
using Microsoft.AspNetCore.Components;

namespace data_viewer.Pages
{
    public partial class Configuration  : ComponentBase, IDisposable
    {
        [Inject]
        public SlackConfigComService SlackConfigComService { get; set; }
        
        public void Dispose()
        {
            
        }
    }
}