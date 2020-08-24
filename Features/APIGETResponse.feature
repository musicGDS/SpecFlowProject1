Feature: API response
	In order to check if API works fine	

@mytag
Scenario: Get API GET response entering title
	Given the title string "RandomDog"
	And Api string Uri "https://api.publicapis.org"
	When request GET API giving title
	Then the Description should be "Random pictures of dogs"

@Smoke
Scenario: Get API GET response entering description
	Given the description string "Daily cat facts"
	And Api string Uri "https://api.publicapis.org"
	When request GET API giving description
	Then the title should be "Cat Facts"
