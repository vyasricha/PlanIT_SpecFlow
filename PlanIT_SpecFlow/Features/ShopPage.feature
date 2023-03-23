Feature: Shopping Page

In order to test the Shopping Page
As a Tester
I want to validate different operations of Shopping page


@positivetest @automate
Scenario: Add few items into Cart
	Given Nevigate to shopping Page from Home Page
	When I add some Items into cart with diffrent Quantity
	And I nevigate to Cart Page
	Then Verify that Price, subTotal and Total are correct


