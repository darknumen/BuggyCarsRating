Feature: Authentication
	In order to access the application
	As a user
	I want to be able to log in


Scenario: Log in with valid credentials
	Given a user with valid credentials	
	When the user logs in to the application
	Then the user should be succesfully logged in

Scenario: Log in with invalid credentials
	Given a user with invalid credentials	
	When the user logs in to the application
	Then the user should be not be able to login successfully

Scenario: Log off
	Given I am logged in
	When I click the log off link
	Then I should be logged off
