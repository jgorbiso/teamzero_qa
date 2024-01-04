Feature: Login

Successfully login using a valid username and password

@login
Scenario Outline: Login using an invalid account
	Given User is the login page
	When User enter a valid email '<email>'
	And User enter a valid password '<password>'
	And User clicks the login button
	Then An error alert message should appear
	Examples: 
	| email           | password |
	| tz-def-01@g.com | P@ssw0rd |
	| jgorbiso@gmail.com | 123456 |


Scenario: Login successfully using a verified account
	Given User is the login page
	When User enter a valid email 'tz-def-06@g.com'
	And User enter a valid password 'P@ssw0rd'
	And User clicks the login button
	Then User is succesfully logged in