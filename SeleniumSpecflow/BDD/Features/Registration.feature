Feature: Registration
	to test registration for website

Scenario: Register
	Given that I register on the site using:
	| Login  | First Name | Last Name | Password   | Confirm Password |
	| random | random     | random    | Test01234! | Test01234!       |
	Then verify registration is a success
	Then use created credentials to log in successfully


	