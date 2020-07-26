@LeagueTable
Feature: League Table Endpoint Returns Correct Data
  
  Scenario Outline: Comparing teams by goals in home games returns the highest scorer
    Given the user requests information from <teamA> part of league <leagueA> 
      And the user requests information from <teamB> part of league <leagueB>
      And the user requests information from <teamC> part of league <leagueC>
     When the teams are compared by goals in home games
     Then the team <teamA>, which scored the most, is returned
    
    Examples:
      | teamA   | leagueA | teamB     | leagueB | teamC   | leagueC | 
      | Arsenal | 2       | Marseille | 4       | Gremio  | 6       |

  
  Scenario Outline: Comparing teams by form returns the highest performer
    Given the user requests information from <teamA> part of league <leagueA> 
      And the user requests information from <teamB> part of league <leagueB>
      And the user requests information from <teamC> part of league <leagueC>
     When the teams are compared by current form
     Then the team <teamB>, with the best current form, is returned
    
    Examples:
      | teamA   | leagueA | teamB  | leagueB | teamC         | leagueC | 
      | Arsenal | 2       | Lyon   | 4       | Bristol City  | 3       |