using RestSharp;
using System;
using System.Collections.Generic;

namespace SpecFlowProject1
{
    class APISharpHandler
    {

        readonly IRestClient _client;

        public APISharpHandler()
        {
            _client = new RestClient("https://api.publicapis.org");
        }

        public List<T> Execute<T>(RestRequest request) where T : new()
        {

            var response = _client.Execute<List<T>>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var apiException = new Exception(message, response.ErrorException);
                throw apiException;
            }
            return response.Data;
        }

        public List<Animal> GetAnimalBy(string by, string query)
        {
            var request = new RestRequest("entries?", Method.GET);
            request.RootElement = "entries";

            request.AddParameter(by, query);
            var response = _client.Execute(request);

            return Execute<Animal>(request);
        }
    }
}
