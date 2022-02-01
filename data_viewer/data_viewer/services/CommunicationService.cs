using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using data_viewer.Constants;
using data_viewer.Model;
using data_viewer.Model.Rate;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor.Rendering;

namespace data_viewer.services
{
    public abstract class CommunicationService : ICommunicationService
    {
        protected ConfigurationService config { get; set; }
        protected const String dateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";
        protected CommunicationService(ConfigurationService config)
        {
            this.config = config;
        }

        protected async Task<IEnumerable<T>> executeRequestMultiple<T>(Uri uri)
        {
            var response = await new HttpClient().SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync
                    <IEnumerable<T>>(responseStream);
            }
            return new List<T>();
        }
        protected async Task<T> executeRequestSingle<T>(Uri uri)
        {
            var response = await new HttpClient().SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync
                    <T>(responseStream);
            }
            return default(T);
        }
    }
}