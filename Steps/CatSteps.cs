using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class APIResponseSteps
    {
        private APISharpHandler apiHandler;
        private AnimalHandler animalHandler = new AnimalHandler();
        private string _description;
        private string _actualResult;

        [Given(@"the description string ""(.*)""")]
        public void GivenTheDescriptionString(string description)
        {
            var a = ConfigReader.GetValue("url");
            _description = description;
        }
        
        [When(@"request GET API giving description")]
        public void WhenRequestGETAPIGivingDescription()
        {
            apiHandler = new APISharpHandler();
            _actualResult = animalHandler.GetTitle(apiHandler.GetAnimalBy("description", _description).First());
        }
        
        [Then(@"the title should be ""(.*)""")]
        public void ThenTheTitleShouldBe(string expectedResult)
        {
            Assert.That(expectedResult, Contains.Substring(_actualResult));
        }
    }
}
