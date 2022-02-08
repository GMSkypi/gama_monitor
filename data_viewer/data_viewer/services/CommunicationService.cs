using System;
using System.Collections.Generic;
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

        protected async Task<IEnumerable<T>> executeRequestMultiple<T>(Uri uri,HttpMethod method, Object optionalBody = null )
        {
            Console.WriteLine("start loading");
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, uri);
            if (optionalBody != null)
            {
                var body = JsonSerializer.Serialize(optionalBody, new JsonSerializerOptions {Converters ={ new JsonStringEnumConverter()}});
                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }
            var response = await new HttpClient().SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("response success");
                using var responseStream = await response.Content.ReadAsStreamAsync();
                Console.WriteLine("read stream");
                return await JsonSerializer.DeserializeAsync
                    <IEnumerable<T>>(responseStream,  new JsonSerializerOptions {Converters ={ new JsonStringEnumConverter()},});
            }
            return new List<T>();
        }
        protected async Task<T> executeRequestSingle<T>(Uri uri, HttpMethod method, Object optionalBody = null)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, uri);
            if (optionalBody != null)
            {
                var body = JsonSerializer.Serialize(optionalBody, new JsonSerializerOptions {Converters ={ new JsonStringEnumConverter()}});
                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }
            var response = await new HttpClient().SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync
                    <T>(responseStream,  new JsonSerializerOptions {Converters ={ new JsonStringEnumConverter()},});
            }
            return default(T);
        }

        protected async Task<bool> executeNoresponse(Uri uri, HttpMethod method, Object optionalBody = null)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, uri);
            if (optionalBody != null)
            {
                var body = JsonSerializer.Serialize(optionalBody, new JsonSerializerOptions {Converters ={ new JsonStringEnumConverter()}});
                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }
            var response = await new HttpClient().SendAsync(httpRequestMessage);
            return response.IsSuccessStatusCode;
        }
    }
}