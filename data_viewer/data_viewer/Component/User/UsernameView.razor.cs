using System;
using System.Text.Json;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace data_viewer.Component.User
{
    public partial class UsernameView
    {
        [Inject] private UserService UserService { get; set; }
        
        [Inject]
        public NotificationService NotificationService { get; set; }
        class Model
        {
            public string Username { get; set; }
            public double Value { get; set; }
            public string RepeatUsername { get; set; }
        }
        Model model = new Model();
        bool popup;
        
        async void OnSubmit(Model model)
        {
            bool success = await UserService.ChangeUsername(model.Username);
            if (success)
            {
                model.Username = "";
                model.RepeatUsername = "";
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Success, Summary = "Username", Detail = "New username is set: " + model.Username ,
                    Duration = 5000,
                };
                NotificationService.Notify(message);
            }
            else
            {
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error, Summary = "Username change error", Detail = "Username is not changed" ,
                    Duration = 5000,
                };
                NotificationService.Notify(message);
            }
        }

        void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
        }
    }
}