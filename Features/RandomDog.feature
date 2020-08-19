Feature: API response
	In order to check if API works fine	

@mytag
Scenario: Get API GET response entering title
	Given the title string "RandomDog"
	And Api string Uri "https://api.publicapis.org/"
	When request GET API giving title
	Then the Description should be "Random pictures of dogs"