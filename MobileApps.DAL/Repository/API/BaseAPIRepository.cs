using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;

namespace MobileApps.DAL.Repository.API
{
    public class BaseAPIRepository
    {
        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        protected async Task<T> GetAsync<T>(string url)
            where T : new()
        {
            HttpClient httpClient = CreateHttpClient();
            T result;
            url = url + "";
            try
            {
                var response = await httpClient.GetStringAsync(url);
                result = await Task.Run(() => JsonConvert.DeserializeObject<T>(response));
            }
            catch (Exception e)
            {
                result = new T();
            }

            return result;
        }

        public async Task<bool> Post<T>(T entity, string baseAddress, string actionUrl) where T : new()
        {
            using (HttpClient httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri(baseAddress);
                StringContent httpContent = new StringContent("{\"Lead\":" + JsonConvert.SerializeObject(entity) + "}", Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = null;

                string jsonContent = httpContent.ReadAsStringAsync().Result;

                try
                {
                    responseMessage = await httpclient.PostAsync(actionUrl, httpContent);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("CRM Lead POST Failed: " + ex.Message);
                    if (responseMessage == null)
                        responseMessage = new HttpResponseMessage();
                    responseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    responseMessage.ReasonPhrase = string.Format("RestHttpClient.SendRequest Failed");
                }

                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    if (responseContent.Contains("True"))
                    {
                        Debug.WriteLine(entity + " Has been successfully Posted");
                        return true;
                    }
                }
                 
                return false;
            }
        }

        //public async Task<bool> Post<T>(T entity, string baseAddress, string actionUrl) where T : new()
        //{
        //    try
        //    {
        //        HttpClient client = CreateHttpClient();
        //        client.BaseAddress = new Uri(baseAddress);
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        //        var response = await client.PostAsync(actionUrl, content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string data = await response.Content.ReadAsStringAsync();
        //            //T entityResult = JsonConvert.DeserializeObject<T>(data);
        //            if (data.Equals("true", StringComparison.OrdinalIgnoreCase))
        //            {
        //                return true;
        //            }
        //        }

        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }

        //}
    }
}
