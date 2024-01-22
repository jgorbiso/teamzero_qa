Feature: Login

Successfully login using an account

@login
Scenario: Login successfully using a verified account
	Given User is the login page
	When User enter 'tz-def-06@g.com' value in Login Page 'email' text field
	And User enter 'P@ssw0rd' value in Login Page 'password' text field
	And User clicks the login button
	Then User is succesfully logged in