using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XMLToAnyViewParser.Models;
using XMLToAnyViewParser.Models.ViewModels;

namespace XMLToAnyViewParser.DesktopClient.Helpers
{
    public class RestClient
    {
        private HttpClient client;

        public RestClient()
        {
            this.client = new HttpClient();
            //client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<GetViewResponse> GetMethodAsync(string url)
        {
            if (!string.IsNullOrWhiteSpace(GlobalData.Token))
            {
                client.DefaultRequestHeaders.Add("Authorization", GlobalData.Token);

            }

            var response = await client.GetAsync(UrlBuilder.GetUrl(url)).ConfigureAwait(false);

            //return response;

            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();

                var items = JsonConvert.DeserializeObject<GetViewResponse>(content);

                return items;
            }

            return null;

        }

        public async Task<FormSubmitResponseJson> PostMethodAsync(object data, string url)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(GlobalData.Token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", GlobalData.Token);

                }

                var json = JsonConvert.SerializeObject(data);

                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(UrlBuilder.GetUrl(url), requestContent).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<FormSubmitResponseJson>(responseContent);
                }

                return new FormSubmitResponseJson { Data = false, Status = ResponseStatus.BadDataSent };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<FormSubmitResponseJson> PutMethodAsync(object data, string url)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(GlobalData.Token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", GlobalData.Token);

                }

                var json = JsonConvert.SerializeObject(data);

                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(UrlBuilder.GetUrl(url), requestContent).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<FormSubmitResponseJson>(responseContent);
                }

                return new FormSubmitResponseJson { Data = false, Status = ResponseStatus.BadDataSent };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public async Task<bool> DeleteMethodAsync<T>(T data, string url) where T : class
        //{
        //    var json = JsonConvert.SerializeObject(data);

        //    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = await client.DeleteAsync(UrlBuilder.GetUrl(url));

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseContent = await response.Content.ReadAsStringAsync();

        //        return JsonConvert.DeserializeObject<bool>(responseContent);
        //    }

        //    return false;
    }
}


