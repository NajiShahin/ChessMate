using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Xamarin.Essentials;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    public class WebApiClient
    {

        private static HttpClientHandler ClientHandler()
        {
            var httpClientHandler = new HttpClientHandler();
#if DEBUG
            //allow connecting to untrusted certificates when running a DEBUG assembly
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
#endif
            return httpClientHandler;
        }

        private static JsonMediaTypeFormatter GetJsonFormatter()
        {
            var formatter = new JsonMediaTypeFormatter();
            //prevent self-referencing loops when saving Json (Bucket -> BucketItem -> Bucket -> ...)
            formatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return formatter;
        }

        public async static Task<T> GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient(ClientHandler()))
            {
                string token = "";
                try
                {
                    token = await SecureStorage.GetAsync("oauth_token");
                }
                catch (Exception ex)
                {

                }

                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                string response = await httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<T>(response, GetJsonFormatter().SerializerSettings);
            }
        }

        public static async Task<TOut> PutCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Put);
        }

        public static async Task<TOut> PostCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Post);
        }

        public static async Task<TOut> DeleteCallApi<TOut>(string uri)
        {
            return await CallApi<TOut, object>(uri, null, HttpMethod.Delete);
        }

        private static async Task<TOut> CallApi<TOut, TIn>(string uri, TIn entity, HttpMethod httpMethod)
        {
            TOut result = default;

            using (HttpClient httpClient = new HttpClient(ClientHandler()))
            {
                string token = "";
                try
                {
                    token = await SecureStorage.GetAsync("oauth_token");
                }
                catch (Exception ex)
                {

                }

                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);


                HttpResponseMessage response;
                if (httpMethod == HttpMethod.Post)
                {
                    response = await httpClient.PostAsync(uri, entity, GetJsonFormatter());
                }
                else if (httpMethod == HttpMethod.Put)
                {
                    response = await httpClient.PutAsync(uri, entity, GetJsonFormatter());
                }
                else
                {
                    response = await httpClient.DeleteAsync(uri);
                }
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TOut>(await response.Content.ReadAsStringAsync());
            }
            return result;
        }
    }
}
