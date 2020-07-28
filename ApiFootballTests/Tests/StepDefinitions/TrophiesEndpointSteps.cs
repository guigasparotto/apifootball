using ApiFootballTests.Models.Coaches;
using ApiFootballTests.Models.Trophies;
using ApiFootballTests.Objects;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ApiFootballTests.Tests.StepDefinitions
{
    [Binding]
    [Scope(Tag = "Trophies")]
    class TrophiesEndpointSteps
    {
        private Coach? _expectedCoach;
        private Trophies? _trophies;
        private TrophiesEndpoint? _trophiesEndpoint;
        private CoachsEndpoint? _coachsEndpoint;
        
        [BeforeScenario]
        public void SetUp()
        {
            _trophiesEndpoint = new TrophiesEndpoint();
            _coachsEndpoint = new CoachsEndpoint();
        }

        [Given(@"the user retrieves the id of coach (.*)")]
        public void GivenTheUserRetrievesTheIdOfCoach(string coachName)
        {
            _expectedCoach = this._coachsEndpoint?.GetCoachByName(coachName).Api.Coachs.First();

            Assert.AreEqual(this._expectedCoach?.Name, coachName, "Incorrect coach retrieved");
        }

        [When(@"the user requests information about the coach trophies")]
        public async Task WhenTheUserRequestsInformationAboutTheCoachTrophies()
        {
            if (_expectedCoach != null)
            {
                var id = _expectedCoach.Id;
                _trophies = await _trophiesEndpoint?.GetTrophiesByCoachId(id)!;
            }
        }

        [Then(@"the information about the coach contains (.*) trophies")]
        public void ThenTheInformationAboutTheCoachContainsTrophies(int trophies)
        {
            if (_trophies != null)
            {
                var expectedQty = _trophies.Api.Results;

                Assert.AreEqual(expectedQty, trophies, "Quantities don't match");
            }

            PrintCoachInfo(_trophies);
        }

        private void PrintCoachInfo(Trophies trophies)
        {
            var trophiesList = trophies.Api.Trophies;

            Console.WriteLine("");
            Console.WriteLine("Coach {0} trophies:\n", _expectedCoach?.Name);

            foreach (var trophy in trophiesList)
            {
                Console.WriteLine(
                    $"League: {trophy.League} \n" +
                    $"Country: {trophy.Country} \n" +
                    $"Season: {trophy.Season} \n" +
                    $"Place: {trophy.Place} \n");
            }
        }

      
    }
}
