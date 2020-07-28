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
        private Coachs _expectedCoach;
        private Trophies? _trophies;
        private TrophiesEndpoint? _trophiesEndpoint;
        private CoachsEndpoint? _coachsEndpoint;
        
        [BeforeScenario]
        public void SetUp()
        {
            _trophiesEndpoint = new TrophiesEndpoint();
            _coachsEndpoint = new CoachsEndpoint();
            _expectedCoach = new Coachs();
        }

        [Given(@"the user retrieves the id of coach (.*)")]
        public async Task GivenTheUserRetrievesTheIdOfCoach(string coachName)
        {
            _expectedCoach =  await _coachsEndpoint?.GetCoachByName(coachName)!;

            Assert.AreEqual(_expectedCoach.Api.Coachs.First().Name, coachName, "Incorrect coach retrieved");
        }

        [When(@"the user requests information about the coach trophies")]
        public async Task WhenTheUserRequestsInformationAboutTheCoachTrophies()
        {
            if (_expectedCoach != null)
            {
                var id = _expectedCoach.Api.Coachs.First().Id;
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

            if (_trophies != null) PrintCoachInfo(_trophies);
        }

        private void PrintCoachInfo(Trophies trophies)
        {
            var trophiesList = trophies.Api.Trophies;

            Console.WriteLine("");
            Console.WriteLine("Coach {0} trophies:\n", _expectedCoach?.Api.Coachs.First().Name);

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
