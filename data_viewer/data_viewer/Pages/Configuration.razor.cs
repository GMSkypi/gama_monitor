using System;
using data_viewer.Model;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace data_viewer.Pages
{
    public partial class Configuration  : ComponentBase, IDisposable
    {
        [Inject]
        public SlackConfigComService SlackConfigComService { get; set; }
        [Inject]
        public NotificationService NotificationService { get; set; }
        public String SlackWebhook { get; set; }
        public bool ActioveNotification { get; set; }

        private SlackConf _conf;
        
        public void Dispose()
        {
            
        }

        protected async override void OnInitialized()
        {
            _conf = await SlackConfigComService.getSlackServerConf();
            if (_conf != null)
            {
                SlackWebhook = _conf.slackWebhook;
                ActioveNotification = _conf.active;
                StateHasChanged();
            }
            
        }

        public async void WebhookChanged()
        {
            bool success = await SlackConfigComService.setSlackServerUrl(SlackWebhook);
            if (success)
            {
                _conf.slackWebhook = SlackWebhook;
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Success, Summary = "Slack webhook edited", Detail = "webhook: " + SlackWebhook ,
                    Duration = 5000,
                };
                NotificationService.Notify(message);
            }
            else
            {
                SlackWebhook = _conf.slackWebhook;
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error, Summary = "Slack webhook error", Detail = "webhook not edited" ,
                    Duration = 5000,
                };
                NotificationService.Notify(message);
            }
        }

        public async void SlackActivation()
        {
            bool success = await SlackConfigComService.setSlackServerActiveFlag(ActioveNotification);
            if (success)
            {
                _conf.active = ActioveNotification;
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Success, Summary = "Slack activation", Detail = "Activated: " + ActioveNotification ,
                    Duration = 5000,
                };
                NotificationService.Notify(message);
            }
            else
            {
                ActioveNotification = _conf.active;
                NotificationMessage message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error, Summary = "Slack activation error", Detail = "Activation failed" ,
                    Duration = 5000,
                };
                NotificationService.Notify(message);
            }
        }
    }
}