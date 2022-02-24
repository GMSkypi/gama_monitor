using System;
using System.Text.Json;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace data_viewer.Component.User
{
    public partial class PasswordView
    {
        [Inject] private UserService UserService { get; set; }
        
        [Inject]
        public NotificationService NotificationService { get; set; }
        class Model
        {
            public string Password { get; set; }
            public double Value { get; set; }
            public string RepeatPassword { get; set; }
        }
        Model model = new Model();
        bool popup;
        
        async void OnSubmit(Model model)
        {
            bool success = await UserService.ChangePassword(model.Password);
            if (success)
            {
                model.Password = "";
                model.RepeatPassword = "";
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Success, Summary = "Password", Detail = "New password is set" ,
                    Duration = 5000,
                };
                NotificationService.Notify(message);
            }
            else
            {
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error, Summary = "Password change error", Detail = "Password is not changed" ,
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