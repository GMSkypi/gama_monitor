using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using data_viewer.Constants;
using data_viewer.Model;
using data_viewer.Model.Rate;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor.Rendering;

namespace data_viewer.services
{
    public abstract class CommunicationService : ICommunicationService
    {
        private NotificationService _notificationService;
        
        private readonly HttpClient _httpClient;
        
        protected ConfigurationService config { get; set; }
        protected const String DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";
        protected CommunicationService(ConfigurationService config, NotificationService notificationService, HttpClient httpClient)
        {
            this._notificationService = notificationService;
            this.config = config;
            this._httpClient = httpClient;
        }

        protected async Task<IEnumerable<T>> ExecuteRequestMultiple<T>(Uri uri,HttpMethod method, Object optionalBody = null )
        {
            Console.WriteLine("start loading");
            var httpRequestMessage = new HttpRequestMessage(method, uri);
            if (optionalBody != null)
            {
                var body = JsonSerializer.Serialize(optionalBody, new JsonSerializerOptions {Converters ={ new JsonStringEnumConverter()}});
                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            try
            {
                var response = await _httpClient.SendAsync(httpRequestMessage);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("response success");
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    Console.WriteLine("read stream");
                    IEnumerable<T> result = await JsonSerializer.DeserializeAsync
                        <IEnumerable<T>>(responseStream,  new JsonSerializerOptions {Converters ={ new JsonStringEnumConverter()},});
                    if (!result.Any())
                    {
                        if(!await TestConnection()) NotifyServerFailed();
                    }
                    return result;
                }
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new List<T>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            NotifyServerFailed();
            return new List<T>();
        }
        protected async Task<T> ExecuteRequestSingle<T>(Uri uri, HttpMethod method, Object optionalBody = null)
        {
            var httpRequestMessage = new HttpRequestMessage(method, uri);
            if (optionalBody != null)
            {
                var body = JsonSerializer.Serialize(optionalBody, new JsonSerializerOptions {Converters ={ new JsonStringEnumConverter()}});
                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            try
            {
                var response = await _httpClient.SendAsync(httpRequestMessage);
                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync
                        <T>(responseStream,  new JsonSerializerOptions {Converters ={ new JsonStringEnumConverter()},});
                }

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return default(T);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            
            NotifyServerFailed();
            return default(T);
        }

        protected async Task<bool> ExecuteNoresponse(Uri uri, HttpMethod method, Object optionalBody = null)
        {
            var httpRequestMessage = new HttpRequestMessage(method, uri);
            if (optionalBody != null)
            {
                var body = JsonSerializer.Serialize(optionalBody, new JsonSerializerOptions {Converters ={ new JsonStringEnumConverter()}});
                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            try
            {
                var response = await _httpClient.SendAsync(httpRequestMessage);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }

        private async Task<bool> TestConnection()
        {
            var uri = new Uri(config.hostName + EndpointConstants.ServerAlive);
            return await ExecuteRequestSingle<bool>(uri, HttpMethod.Get);
        }

        private void NotifyServerFailed()
        {
            
            NotificationMessage message = new NotificationMessage()
            {
                Severity = NotificationSeverity.Error, Summary = "Server failed to load data",
                Duration = 10000,
            };
            _notificationService.Notify(message);
        }
    }
}