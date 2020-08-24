using RestSharp;
using System;
using System.Collections.Generic;

namespace SpecFlowProject1
{
    class APISharpHandler
    {

        readonly IRestClient _client;

        public APISharpHandler(string url)
        {
            _client = new RestClient(url);
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

        public List<Animal> GetAnimal(string title)
        {
            var request = new RestRequest("entries?title={title}", Method.GET);
            request.RootElement = "entries";

            request.AddParameter("title", title, ParameterType.QueryString);
            var response = _client.Execute(request);

            //return response.Data;

            return Execute<Animal>(request);
        }
    }
}
