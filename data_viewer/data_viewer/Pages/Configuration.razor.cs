using System;
using data_viewer.Model;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace data_viewer.Pages
{
    public partial class Configuration : ComponentBase, IDisposable
    {
        [Inject] public SlackConfigComService slackConfigComService { get; set; }
        [Inject] public NotificationService notificationService { get; set; }
        private string _slackWebhook { get; set; }
        private bool _actioveNotification { get; set; }

        private SlackConf _conf;

        public void Dispose()
        {
        }

        protected override async void OnInitialized()
        {
            _conf = await slackConfigComService.GetSlackServerConf();
            if (_conf != null)
            {
                _slackWebhook = _conf.slackWebhook;
                _actioveNotification = _conf.active;
                StateHasChanged();
            }
        }

        private async void WebhookChanged()
        {
            bool success = await slackConfigComService.SetSlackServerUrl(_slackWebhook);
            if (success)
            {
                _conf.slackWebhook = _slackWebhook;
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Success, Summary = "Slack webhook edited",
                    Detail = "webhook: " + _slackWebhook,
                    Duration = 5000,
                };
                notificationService.Notify(message);
            }
            else
            {
                _slackWebhook = _conf.slackWebhook;
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error, Summary = "Slack webhook error",
                    Detail = "webhook not edited",
                    Duration = 5000,
                };
                notificationService.Notify(message);
            }
        }

        private async void SlackActivation()
        {
            bool success = await slackConfigComService.SetSlackServerActiveFlag(_actioveNotification);
            if (success)
            {
                _conf.active = _actioveNotification;
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Success, Summary = "Slack activation",
                    Detail = "Activated: " + _actioveNotification,
                    Duration = 5000,
                };
                notificationService.Notify(message);
            }
            else
            {
                _actioveNotification = _conf.active;
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error, Summary = "Slack activation error",
                    Detail = "Activation failed",
                    Duration = 5000,
                };
                notificationService.Notify(message);
            }
        }
    }
}