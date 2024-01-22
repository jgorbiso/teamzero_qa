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
	| tz-def-06@g.com | 123      | Password is incorrect  |
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
	| teamzero_06  | tz-def{0}@g.com | P@ssw0rd | P@ssw0rd        | en       | Username not available                          |
	| teamzero_{0} | TZ_def_06@g.com | P@ssw0rd | P@ssw0rd        | fl      | The email address you entered is already in use |