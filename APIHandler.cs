using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1
{
    class APIHandler
    {
        public string title;
        public string url;
        public string description;
        static HttpClient client; 

        public void InitializeClient()
        {
            client = new HttpClient();
            //client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //try
            //{
            //    Animal animal = new Animal();
               
            //    // Get the animal
            //    animal = await GetAnimalAsync("https://api.publicapis.org/entries?title=RandomDog");
            //    ShowAnimal(animal);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }

        public static async Task<Animal> GetAnimalAsync(string path)
        {
            Animal animal = null;
            using (HttpResponseMessage response = await client.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {
                    animal = await response.Content.ReadAsAsync<Animal>();
                    return animal;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static void ShowAnimal(Animal animal)
        {
            Console.WriteLine("API " + animal.API);
            Console.WriteLine("Description " + animal.Description);
        }

        public async Task<string> AnimalDescription()
        {
            Animal an = await GetAnimalAsync("https://api.publicapis.org/entries?title=RandomDog");
            string animalDescription = an.Description;

            return animalDescription;
        }
    }
}

    
