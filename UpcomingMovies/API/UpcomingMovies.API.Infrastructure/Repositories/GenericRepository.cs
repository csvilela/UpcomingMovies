using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UpcomingMovies.API.Infrastructure.Repositories
{
    public class BaseRepository
    {
        public async Task<string> GetAsync(string uri)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseMessage = await httpClient.GetAsync(uri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    
                    return await responseMessage.Content.ReadAsStringAsync();
                }

                throw new HttpRequestException();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
