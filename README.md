# BuggyCarsRating
Automation for website: Buggy Cars Rating
link: https://buggy.justtestit.org/

HOW TO --

Environment used:
	Microsoft Visual Studio Community 2019
	Version 16.8.4 

To run the tests:

Clone a repository based on the GitHub link: https://github.com/darknumen/BuggyCarsRating.git
	1. Build the project
	2. I am using SpecFlow+Runner on this project (used this to have tests run in parallel for faster run time of the whole suite):
		a. Run all the tests on the Test Explorer pane of VS2019
		b. On the Output Pane -->  "show Output from: Tests" (select Tests from the dropdown)
		c. You will see something like this --
			Please sign-up for your free SpecFlow account or sign-in with your already existing account here:
			https://account.specflow.org/clientactivation/welcome/Runner/5B96CC06961A43DA91F9C5451EDCB799CFFA72727BCE6786C6607017C35C93D6E5B3EC9C/NotActivatedYet
		d. Follow the link and register to activate
		e. Run the tests again and it should work


FYI:
- automation settings are placed in the App.config file
- Test Result Report is generated on the TestResult folder on the same level as the SeleniumSpecflow.sln
