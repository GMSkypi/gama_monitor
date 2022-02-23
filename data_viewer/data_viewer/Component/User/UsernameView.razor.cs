using System;
using System.Text.Json;
using Radzen;

namespace data_viewer.Component.User
{
    public partial class UsernameView
    {
        class Model
        {
            public string Username { get; set; }
            public double Value { get; set; }
            public string RepeatUsername { get; set; }
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