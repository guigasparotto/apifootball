using System;
using System.Collections.Generic;
using System.Linq;
using ApiFootballTests.Models.LeagueTable;
using ApiFootballTests.Objects;
using NUnit.Framework;

namespace ApiFootballTests.Tests
{
    [TestFixture]
    public class LeagueTableTests
    {
        [SetUp]
        public void Setup()
        {
            _leagueTableEndpoint = new LeagueTableEndpoint();
        }

        [Test]
        public void Test1()
        {
            var teams = new List<Standing?>
            {
                _leagueTableEndpoint.GetTeamByName("Arsenal", 2),
                _leagueTableEndpoint.GetTeamByName("Marseille", 4),
                _leagueTableEndpoint.GetTeamByName("Gremio", 6)
            };

            var bestScorer = GetHighestScorer(teams);

            Console.WriteLine(bestScorer?.TeamName);
        }

        private static Standing? GetHighestScorer(List<Standing?> teams)
        {
            return teams.Find(x => 
                x?.Home.GoalsFor == teams.Max(s => s?.Home.GoalsFor));
        }
        
        private LeagueTableEndpoint _leagueTableEndpoint;
    }
}