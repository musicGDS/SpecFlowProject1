Feature: API response
	In order to check if API works fine	

@mytag
Scenario: Get response by entering title
	Given the title string "RandomDog"
	When request GET API giving title
	Then the Description should be "Random pictures of dogs"

@Smoke
Scenario: Get response by entering description
	Given the description string "Daily cat facts"
	When request GET API giving description
	Then the title should be "Cat Facts"
