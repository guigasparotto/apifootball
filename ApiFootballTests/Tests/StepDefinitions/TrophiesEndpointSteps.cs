using ApiFootballTests.Models.Coaches;
using ApiFootballTests.Models.Trophies;
using ApiFootballTests.Objects;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace ApiFootballTests.Tests.StepDefinitions
{
    [Binding]
    [Scope(Tag = "Trophies")]
    class TrophiesEndpointSteps
    {
        [BeforeScenario]
        public void SetUp()
        {
            _trophiesEndpoint = new TrophiesEndpoint();
            _coachsEndpoint = new CoachsEndpoint();
        }

        [Given(@"the user retrieves the id of coach (.*)")]
        public void GivenTheUserRetrievesTheIdOfCoach(string coachName)
        {
            this._expectedCoach = this._coachsEndpoint
                .GetCoachByName(coachName).Api.Coachs.First();

            Assert.AreEqual(this._expectedCoach.Name, coachName, "Incorrect coach retrieved");
        }

        [When(@"the user requests information about the coach trophies")]
        public void WhenTheUserRequestsInformationAboutTheCoachTrophies()
        {
           var id = this._expectedCoach.Id;

           this._trophies =  this._trophiesEndpoint.GetTrophiesByCoachId(id);
        }

        [Then(@"the information about the coach contains (.*) trophies")]
        public void ThenTheInformationAboutTheCoachContainsTrophies(int trophies)
        {
            var expectedQty = this._trophies.Api.Results;

            Assert.AreEqual(expectedQty, trophies, "Quantities don't match");

            this.PrintCoachInfo(this._trophies);
        }

        private void PrintCoachInfo(Trophies trophies)
        {
            var trophiesList = trophies.Api.Trophies;

            Console.WriteLine("");
            Console.WriteLine("Coach {0} trophies:\n", this._expectedCoach.Name);

            foreach (var trophy in trophiesList)
            {
                Console.WriteLine(
                    $"League: {trophy.League} \n" +
                    $"Country: {trophy.Country} \n" +
                    $"Season: {trophy.Season} \n" +
                    $"Place: {trophy.Place} \n");
            }
        }

        private Coach _expectedCoach;
        private Trophies _trophies;
        private TrophiesEndpoint _trophiesEndpoint;
        private CoachsEndpoint _coachsEndpoint;
    }
}
