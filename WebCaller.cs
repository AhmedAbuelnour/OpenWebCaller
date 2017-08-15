namespace OpenWebCaller
{
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

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
        public static async Task<string> GetAsync(string Url)
        {
            using (HttpClient Client = new HttpClient())
            {
                return await (await Client.GetAsync(Url)).Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Performs POST Request To The Remote Server
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Url">Url of the remote server</param>
        /// <param name="Content">The Data you want to send to the server, it will be formatted automatically into Json</param>
        /// <returns>The Respond of the remote server in format of Json, OK, Not Found, Created, etc.</returns>
        public static async Task<string> PostAsync<T>(string Url, T Content)
        {
            using (HttpClient Client = new HttpClient())
            {
                using (ByteArrayContent ByteContent = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Content))))
                {
                    ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return (await Client.PostAsync(Url, ByteContent)).ReasonPhrase;
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
        public static async Task<string> PutAsync<T>(string Url, T Content)
        {
            using (HttpClient Client = new HttpClient())
            {
                using (ByteArrayContent ByteContent = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Content))))
                {
                    ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return (await Client.PutAsync(Url, ByteContent)).ReasonPhrase;
                }
            }
        }
        /// <summary>
        /// Performs DELETE Request To The Remote Server
        /// </summary>
        /// <param name="Url"> Url of the remote server, Make sure to format the Url in case of sending a value along with Url </param>
        /// <returns>The Respond of the remote server in format of Json, OK, Not Found, Created, etc.</returns>
        public static async Task<string> DeleteAsync(string Url)
        {
            using (HttpClient Client = new HttpClient())
            {
                return (await Client.DeleteAsync(Url)).ReasonPhrase;
            }
        }
    }
}
