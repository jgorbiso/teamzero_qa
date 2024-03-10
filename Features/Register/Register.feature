Feature: Register

Successfully register a user

@tag1
Scenario: Verify that a user can successfully register with valid information
	Given User is the register page
	When User enter 'teamzero_{0}' value in Register Page 'username' text field
	And User enter 'tz-def-{0}@mailinator.com' value in Register Page 'email' text field
	And User enter 'Passw0rd' value in Register Page 'password' text field
	And User enter 'Passw0rd' value in Register Page 'confirmPassword' text field
	And User selects a 'fil' option in language droplist
	And User clicks the register button
	Then User successully registers an account with message 'Registration Success'
	And User is redirected to Login Page 'https://teamzeroweb.azurewebsites.net/login'
