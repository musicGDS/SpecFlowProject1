using RestSharp;
using System;

namespace SpecFlowProject1
{
    class APISharpHandler
    {

        readonly IRestClient _client;

        public APISharpHandler(string url)
        {
            _client = new RestClient(url);
            Console.WriteLine("Rest client url: " + url);
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            
            var response = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var apiException = new Exception(message, response.ErrorException);
                throw apiException;
            }
            return response.Data;
        }

        public Animal GetAnimal(string title)
        {
            var request = new RestRequest("entries?title={Title}");
            request.AddParameter("Title", title, ParameterType.UrlSegment);
            return Execute<Animal>(request);
        }
    }
}
