Feature: FeatureProductsApp
	In order to add a new product to my shop
	i want to enter some information to display it

A short summary of the feature

Scenario: Application created new item
	Given I am on the create item screen
		And I enter a name of mango
		And I enter a price of 7
		And I enter a Description of Test description
	When I submit my new item by clicking create
	Then I should see the Item get added to the list.


Scenario: Cannot create new item unless price is enter
	Given I am on the create item screen
		And I enter a name of mango
		And I enter a Description of Test description
	When I submit my new item by clicking create
	Then I should see an error message telling me price is required.
	