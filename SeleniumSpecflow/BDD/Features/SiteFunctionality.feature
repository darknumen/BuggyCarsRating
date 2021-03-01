Feature: SiteFunctionality
	Simple calculator for adding two numbers

Background:
	Given I am a registered new user and logged in

Scenario: Profile Update
	When I update my profile and password
	Then I login using new password and verify profile change was saved

Scenario: Votes are counted
	When I navigate to the most popular model
	And I made a comment to vote
	Then check that vote was counted and comment could not be made anymore
