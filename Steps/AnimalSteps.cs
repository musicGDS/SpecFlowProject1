using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class AnimalSteps
    {
        private APISharpHandler apiHandler;
        private AnimalHandler animalHandler = new AnimalHandler();

        private string _actualResult;
        private string _title;
        private string _url;

        [Given(@"the title string ""(.*)""")]
        public void GivenTheTitleString(string animal)
        {
            _title = animal;
        }
        
        [Given(@"Api string Uri ""(.*)""")]
        public void GivenApiStringUri(string url)
        {
            _url = url;
            _url = "https://api.publicapis.org";
        }

        [When(@"request GET API giving title")]
        public void WhenRequestGETAPIGivingTitle()
        {
            apiHandler = new APISharpHandler(_url);
            _actualResult = animalHandler.GetDescription(apiHandler.GetAnimal(_title));
            Console.WriteLine(_actualResult);

        }   

        [Then(@"the Description should be ""(.*)""")]
        public void ThenTheDescriptionShouldBe(string expectedResult)
        {
            Assert.That(expectedResult, Contains.Substring(_actualResult));
        }
    }
}
