using System;
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
    public class LeagueTableSteps
    {
        [BeforeScenario]
        public void SetUp()
        {
            _leagueTableEndpoint = new LeagueTableEndpoint();
        }

        [Given("I request information from (.*) part of league (.*)")]
        public void GivenIRequestInformationFromTeamPartOfLeague(string teamName, int leagueId)
        {
           this._teams.Add(this._leagueTableEndpoint.GetTeamByName(teamName, leagueId));
           
           Assert.AreEqual(teamName, this._teams.Last()?.TeamName, "Incorrect team added");
        }

        [When(@"the teams are compared by goals in home games")]
        public void WhenTheTeamsAreComparedByGoalsInHomeGames()
        {
            this._highestScorer = this._teams.Find(x => 
                x?.Home.GoalsFor == this._teams.Max(s => s?.Home.GoalsFor));
        }

        [Then(@"the team with the highest score is returned")]
        public void ThenTheTeamWithTheHighestScoreIsReturned()
        {
            Console.WriteLine(this._highestScorer);
        }

        private Standing? _highestScorer;
        private List<Standing?> _teams = new List<Standing?>();
        private LeagueTableEndpoint _leagueTableEndpoint;
    }
}