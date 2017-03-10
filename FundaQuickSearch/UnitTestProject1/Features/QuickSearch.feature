Feature: TestFundaSearch
	In this feature we will test the search functionality of funda website
	
Scenario: Test koop functionality without entering any search properties
	Given I am at the home page of funda website
	And quick search component is fully loaded
	When I press zoek
	Then I should be redirected to search reults page
	And I should see houses from whole netherlands

Scenario: Test koop functionality with entering city as search properties
	Given I am at the home page of funda website
	And quick search component is fully loaded
	When I enter 'amsterdam' as city in search field	
	And I press zoek
	Then I should be redirected to search reults page
	And I should see houses from 'amsterdam' in search results page

Scenario: Test koop functionality with entering postcode as search properties
	Given I am at the home page of funda website
	And quick search component is fully loaded
	When I enter 1187 as postcode in search field	
	And I press zoek
	Then I should be redirected to search reults page
	And I should see houses from 1187 postcode in search results page

Scenario: Test koop functionality with entering address as search properties
	Given I am at the home page of funda website
	And quick search component is fully loaded
	When I enter 'Dunantstraat 1099, Zoetermeer' as address in search field	
	And I press zoek
	Then I should be redirected to search reults page
	And I should see houses from 'Dunantstraat 1099, Zoetermeer' address in search results page

Scenario: Test koop functionality with entering price range as search properties
	Given I am at the home page of funda website
	And quick search component is fully loaded
	When I select '€ 50.000' as minimum and '€ 100.000' as maximum price	
	And I press zoek
	Then I should be redirected to search reults page
	And I should see houses in the range of '€ 50.000' and '€ 100.000' price

Scenario: Test koop functionality with entering area,distance,miniumprice,maximumprice range as search properties
	Given I am at the home page of funda website
	And quick search component is fully loaded
	When I enter 'den haag' as city in search field
	And I select '+ 1 km' of distance range
	And I select '€ 200.000' as minimum and '€ 400.000' as maximum price	
	And I press zoek
	Then I should be redirected to search reults page
	And I should see houses in the range of city'den-haag' within '+1km' of distance range and '200000' to '400000' price range
	

Scenario: Test last searched functionality 
	Given I have searched houses for city 'amsterdam'
	And I am on the search results page
	When I press funda logo on top left corner to go to home page
	Then I see a link with last search for 'amsterdam'
	When I click the link
	Then I am redirected back to search results for 'amsterdam'

Scenario: Test huur functionality 
	Given I am at the home page of funda website
	And quick search component is fully loaded
	And I click 'huur' tab
	When I enter 'rotterdam' as city in search field
	And I press zoek
	Then I should be redirected to search reults page for Huur
	And I should see houses for Huur in 'rotterdam'

Scenario: Test Nieuwbow functionality 
	Given I am at the home page of funda website
	And quick search component is fully loaded
	And I click 'nieuwbow' tab
	When I enter 'amsterdam' as city in search field
	And I press zoek
	Then I should be redirected to search reults page for Niewbouw
	And I should see Niewbouw projects in 'amsterdam'

Scenario: Test Recreatie functionality 
	Given I am at the home page of funda website
	And quick search component is fully loaded
	And I click 'recreatie' tab
	Then I am redirected to 'recreatie' search page

Scenario: Test Europa functionality 
	Given I am at the home page of funda website
	And quick search component is fully loaded
	And I click 'europe' tab
	Then I am redirected to 'europe' search page
	












