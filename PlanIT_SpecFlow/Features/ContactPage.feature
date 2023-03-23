Feature: ContactPage

In order to test the Contact Page
As a Tester
I want to validate different operations of Contact page

@positivetest @automate
Scenario Outline: If all the mandatory fields are given 
	Given Nevigate to Contact Page from Home Page
	When I enter the mendatory fields like <Forename>, <Email>, <Message>
	And I click on the Submit button
	Then Proper submission message should be display for <Forename>

	Examples: 
	| Forename	| Email						| Message						|
	| Richa		| vyas.richa@gmail.com		| I want to know...				|
	| @123		| abc.123@yahoo.com			| Can you please...				|
	| Ge0rge	| Ge0rge.abd@yahoo.co.nz	| I need to know...				|
	| John		| John.abc@hotmail.com		| May I know the parcel status? |
	| Emma		| Emma.abc@outlook.com		| What is the procedure...		|

@negativetest @automate
Scenario: If all the mandatory fields are empty 
	Given Nevigate to Contact Page from Home Page
	When I keep all the mendatory fields empty
	And I click on the Submit button
	Then Error message should display

@test1 @automate
Scenario Outline: Validate the error message is gone
	Given Nevigate to Contact Page from Home Page
	When I keep all the mendatory fields empty
	And I click on the Submit button
	And Error message should display
	When I enter the mendatory fields like <Forename>, <Email>, <Message>
	And I click on the Submit button
	Then Proper submission message should be display for <Forename>
	Examples: 
	| Forename | Email | Message |
	| April | april.abc@gmail.com | I want to know... |
