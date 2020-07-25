@LeagueTable
Feature: League Table Returns Correct Data
  
  Scenario Outline: Comparing teams from different leagues by goals in home games returns the highest score team
    Given I request information from <teamA> part of league <leagueA> 
      And I request information from <teamB> part of league <leagueB>
      And I request information from <teamC> part of league <leagueC>
     When the teams are compared by goals in home games
     Then the team with the highest score is returned
    
    Examples:
      | teamA   | leagueA | teamB     | leagueB | teamC   | leagueC |
      | Arsenal | 2       | Marseille | 4       | Gremio  | 6       |  
    