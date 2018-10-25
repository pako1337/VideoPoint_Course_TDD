Feature: Basket
	In order to support my business
	I want to have functional basket
	so customers can buy my products

@mytag
Scenario: Add course to basket
	Given empty basket
	When I add course to basket
	Then there should be 1 item in basket
