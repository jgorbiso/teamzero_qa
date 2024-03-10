Feature: Login Field Validation

@login
Scenario Outline: Login Page - Email field Validation
	Given User is the login page
	When User enter '<email>' value in Login Page 'email' text field
	And User clicks the login button
	Then Field validation '<message>' should appear for Login Page 'email' field
Examples:
	| email | message           |
	|       | Email is required |
	| a@g   | Invalid email     |

@login
Scenario Outline: Login Page - Password field Validation
	Given User is the login page
	When User enter '<email>' value in Login Page 'email' text field
	And User enter '<password>' value in Login Page 'password' text field
	And User clicks the login button
	Then Field validation '<message>' should appear for Login Page 'password' field
Examples:
	| email | password | message              |
	|       |          | Password is required |