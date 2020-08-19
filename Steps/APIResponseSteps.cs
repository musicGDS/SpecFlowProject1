using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class APIResponseSteps
    {
        private APIHandler apiHandler = new APIHandler();
        private Animal _animal = new Animal();
        private string actualResult;


        [Given(@"the title string ""(.*)""")]
        public void GivenTheTitleString(string animal)
        {
            apiHandler.title = animal;
        }
        
        [Given(@"Api string Uri ""(.*)""")]
        public void GivenApiStringUri(string url)
        {
            apiHandler.url = url;
        }

        [When(@"request GET API giving title")]
        public void WhenRequestGETAPIGivingTitle()
        {
            apiHandler.InitializeClient();
            var animalDescription = apiHandler.AnimalDescription();
            actualResult = animalDescription.ToString();
            Console.WriteLine("Description: " + animalDescription);
        }   

        [Then(@"the Description should be ""(.*)""")]
        public void ThenTheDescriptionShouldBe(string actualResult)
        {
            Assert.That("Random pictures of dogs" == actualResult);
        }
    }
}
