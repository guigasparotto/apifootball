using System.Collections.Generic;
using System.Linq;
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
        [BeforeScenario]
        public void SetUp()
        {
            _leagueTableEndpoint = new LeagueTableEndpoint();
        }

        [Given(@"the user requests information from (.*) part of league (.*)")]
        public void GivenITheUserRequeststInformationFromTeamPartOfLeague(string teamName, int leagueId)
        {
           this._teams.Add(this._leagueTableEndpoint.GetTeamByName(teamName, leagueId));
        }

        [When(@"the teams are compared by goals in home games")]
        public void WhenTheTeamsAreComparedByGoalsInHomeGames()
        {
            this._highestScorer = this._teams.Find(x => 
                x?.Home.GoalsFor == this._teams.Max(s => s?.Home.GoalsFor));
        }

        [When(@"the teams are compared by current form")]
        public void WhenTheTeamsAreComparedByCurrentForm()
        {
            this._highestForm = _leagueTableEndpoint.GetBestCurrentForm(this._teams);
        }

        [Then(@"the team (.*), which scored the most, is returned")]
        public void ThenTheTeamArsenalWhichScoredTheMostIsReturned(string highestScorer)
        {
            Assert.AreEqual(highestScorer, this._highestScorer.TeamName, "Incorrect team returned");
        }

        [Then(@"the team (.*), with the best current form, is returned")]
        public void ThenTheTeamWithTheBestCurrentFormIsReturned(string highestForm)
        {
            Assert.AreEqual(highestForm, this._highestForm.TeamName, "Incorrect team returned");
        }

        [AfterScenario]
        public void TearDown()
        {
            _teams.Clear();
        }

        private Standing? _highestScorer;
        private Standing? _highestForm;
        private List<Standing?> _teams = new List<Standing?>();
        private LeagueTableEndpoint _leagueTableEndpoint;
    }
}