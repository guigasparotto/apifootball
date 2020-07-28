using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFootballTests.Models.LeagueTable;
using ApiFootballTests.Objects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ApiFootballTests.Tests.StepDefinitions
{
    [Binding]
    [Scope(Tag = "LeagueTable")]
    public class LeagueTableEndpointSteps
    {
        private Standing? _highestScorer;
        private Standing? _highestForm;
        private readonly List<Standing?> _teams = new List<Standing?>();
        private LeagueTableEndpoint? _leagueTableEndpoint;
        
        [BeforeScenario]
        public void SetUp()
        {
            _leagueTableEndpoint = new LeagueTableEndpoint();
        }

        [Given(@"the user requests information from (.*) part of league (.*)")]
        public async Task GivenITheUserRequestsInformationFromTeamPartOfLeague(string teamName, int leagueId)
        {
            if (_leagueTableEndpoint != null) _teams.Add(await _leagueTableEndpoint?.GetTeamByName(teamName, leagueId));
        }

        [When(@"the teams are compared by goals in home games")]
        public void WhenTheTeamsAreComparedByGoalsInHomeGames()
        {
            _highestScorer = _teams.Find(x => 
                x?.Home.GoalsFor == _teams.Max(s => s?.Home.GoalsFor));
        }

        [When(@"the teams are compared by current form")]
        public async Task WhenTheTeamsAreComparedByCurrentForm()
        {
            _highestForm = await _leagueTableEndpoint?.GetBestCurrentForm(_teams);
        }

        [Then(@"the team (.*), which scored the most, is returned")]
        public void ThenTheTeamArsenalWhichScoredTheMostIsReturned(string highestScorer)
        {
            Assert.AreEqual(highestScorer, _highestScorer?.TeamName, "Incorrect team returned");
        }

        [Then(@"the team (.*), with the best current form, is returned")]
        public void ThenTheTeamWithTheBestCurrentFormIsReturned(string highestForm)
        {
            Assert.AreEqual(highestForm, _highestForm?.TeamName, "Incorrect team returned");
        }

        [AfterScenario]
        public void TearDown()
        {
            _teams.Clear();
        }
    }
}