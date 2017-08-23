namespace OpenWebCaller
{
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class Represents the Respond Result
    /// </summary>
    public class HttpRespondResult
    {
        /// <summary>
        /// The Server returned Content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// The HttpRespond Code "Ok" , "Not Found" , "Unauthorized" , etc.
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// Indicate if the request has an issue to be completed as expected 
        /// </summary>
        public bool IsSuccess { get; set; }
    }
    /// <summary>
    /// Encapsulates All HTTP Requests 
    /// </summary>
    public static class WebCaller
    {

        /// <summary>
        /// Performs GET Request To The Remote Server
        /// </summary>
        /// <param name="Url"> Url of the remote server, Make sure to format the Url in case of sending a value along with Url </param>
        /// <returns>The Respond of the remote server in format of Json</returns>           
        public static async Task<HttpRespondResult> GetAsync(string Url)
        {
            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage httpResponseMessage = await Client.GetAsync(Url);
                return new HttpRespondResult
                {
                    Content = await httpResponseMessage.Content.ReadAsStringAsync(),
                    StatusCode = httpResponseMessage.StatusCode.ToString(),
                    IsSuccess = httpResponseMessage.IsSuccessStatusCode
                };
            }
        }
        /// <summary>
        /// Performs POST Request To The Remote Server
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Url">Url of the remote server</param>
        /// <param name="Content">The Data you want to send to the server, it will be formatted automatically into Json</param>
        /// <returns>The Respond of the remote server in format of Json, OK, Not Found, Created, etc.</returns>
        public static async Task<HttpRespondResult> PostAsync<T>(string Url, T Content)
        {
            using (HttpClient Client = new HttpClient())
            {
                using (ByteArrayContent ByteContent = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Content))))
                {
                    ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage httpResponseMessage = await Client.PostAsync(Url, ByteContent);
                    return new HttpRespondResult
                    {
                        Content = await httpResponseMessage.Content.ReadAsStringAsync(),
                        StatusCode = httpResponseMessage.StatusCode.ToString(),
                        IsSuccess = httpResponseMessage.IsSuccessStatusCode
                    };
                }
            }
        }
        /// <summary>
        /// Performs PUT Request To The Remote Server
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Url">Url of the remote server</param>
        /// <param name="Content">The Data you want to update to the server, it will be formatted automatically into Json, Make sure to format the Url in case of sending a value along with Url</param>
        /// <returns>The Respond of the remote server in format of Json, OK, Not Found, Created, etc.</returns>
        public static async Task<HttpRespondResult> PutAsync<T>(string Url, T Content)
        {
            using (HttpClient Client = new HttpClient())
            {
                using (ByteArrayContent ByteContent = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Content))))
                {
                    ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage httpResponseMessage = await Client.PutAsync(Url, ByteContent);
                    return new HttpRespondResult
                    {
                        Content = await httpResponseMessage.Content.ReadAsStringAsync(),
                        StatusCode = httpResponseMessage.StatusCode.ToString(),
                        IsSuccess = httpResponseMessage.IsSuccessStatusCode
                    };
                }
            }
        }
        /// <summary>
        /// Performs DELETE Request To The Remote Server
        /// </summary>
        /// <param name="Url"> Url of the remote server, Make sure to format the Url in case of sending a value along with Url </param>
        /// <returns>The Respond of the remote server in format of Json, OK, Not Found, Created, etc.</returns>
        public static async Task<HttpRespondResult> DeleteAsync(string Url)
        {
            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage httpResponseMessage = await Client.DeleteAsync(Url);
                return new HttpRespondResult
                {
                    Content = await httpResponseMessage.Content.ReadAsStringAsync(),
                    StatusCode = httpResponseMessage.StatusCode.ToString(),
                    IsSuccess = httpResponseMessage.IsSuccessStatusCode
                };
            }
        }
    }
}
