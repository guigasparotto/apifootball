@Trophies
Feature: Trophies Endpoint Returns Correct Data

Scenario Outline: Search by choach name returns correct information
	Given the user retrieves the id of coach <coach>
	 When the user requests information about the coach trophies
	 Then the information about the coach contains <trophies> trophies
    
    Examples:
      | coach    | trophies |
      | E. Howe  | 2        |
      | J. Klopp | 22       |