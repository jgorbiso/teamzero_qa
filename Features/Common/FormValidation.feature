Feature: Form Validation

@login
Scenario Outline: Login Page - Form validation
	Given User is the login page
	When User enter '<email>' value in Login Page 'email' text field
	And User enter '<password>' value in Login Page 'password' text field
	And User clicks the login button
	Then Login Form validation alert '<message>' should appear
Examples:
	| email           | password | message                |
	| tz-def-01@mailinator.com | 123      | Password is incorrect  |
	| tz-def@g.com    | 123      | Account does not exist |

@register
Scenario Outline: Register Page - Form validation
	Given User is the register page
	When User enter '<username>' value in Register Page 'username' text field
	And User enter '<email>' value in Register Page 'email' text field
	And User enter '<password>' value in Register Page 'password' text field
	And User enter '<confirmPassword>' value in Register Page 'confirmPassword' text field
	And User selects a '<language>' option in language droplist
	And User clicks the register button
	Then Register Form validation alert '<message>' should appear
Examples:
	| username     | email           | password | confirmPassword | language | message                                         |
	| teamzero_06  | tz-def{0}@mailinator.com | P@ssw0rd | P@ssw0rd        | en       | Username not available                          |
	| teamzero_{0} | tz-def-01@mailinator.com | P@ssw0rd | P@ssw0rd        | fil       | The email address you entered is already in use |