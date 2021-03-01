Feature: SiteNavigation
	Site Navigation

Background: 
Given I am logged in

Scenario: Main page navigation
	Then I navigate to Popular Model then confirm model page and back to main page successfully
	Then I navigate to Overall Rating then confirm overall page and back to main page succesfully
	