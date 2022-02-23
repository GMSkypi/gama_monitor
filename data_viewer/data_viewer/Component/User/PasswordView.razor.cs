using System;
using System.Text.Json;
using Radzen;

namespace data_viewer.Component.User
{
    public partial class PasswordView
    {
        class Model
        {
            public string Password { get; set; }
            public double Value { get; set; }
            public string RepeatPassword { get; set; }
        }
        Model model = new Model();
        bool popup;
        
        void OnSubmit(Model model)
        {
            Console.WriteLine("Submit", JsonSerializer.Serialize(model, new JsonSerializerOptions() { WriteIndented = true }));
        }

        void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
        }
    }
}