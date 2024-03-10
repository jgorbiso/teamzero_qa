Feature: Register Field Validation

@register
Scenario Outline: Register Page - Email Field Validation
	Given User is the register page
	When User enter '<email>' value in Register Page 'email' text field
	And User clicks the register button
	Then field validation '<message>' should appear for Register Page 'email' field
Examples:
	| email | message       |
	|       | Invalid email address |
	| a@g   | Invalid email address |
	| a.com | Invalid email address |

@register
Scenario Outline: Register Page - Username Field Validation
	Given User is the register page
	When User enter '<username>' value in Register Page 'username' text field
	And User clicks the register button
Examples:
	| email            | message                                                                              |
	|                  | Name can't be blank                                                                  |
	| team             | Username must be 6-15 characters long, alphanumeric and may contain underscores only |
	| teamzero!        | Username must be 6-15 characters long, alphanumeric and may contain underscores only |
	| team_zero_tz_001 | Username must be 6-15 characters long, alphanumeric and may contain underscores only |
	| team zero 001    | Username must be 6-15 characters long, alphanumeric and may contain underscores only |

@register
Scenario Outline: Register Page - Password Field validation
	Given User is the register page
	When User enter '<username>' value in Register Page 'username' text field
	And User enter '<email>' value in Register Page 'email' text field
	And User enter '<password>' value in Register Page 'password' text field
	And User clicks the register button
Examples:
	| username         | email           | password         | message                                               |
	|                  |                 |                  | Password can't be blank                               |
	|                  |                 | team             | Password should be 8-16 characters                    |
	| teamzero_test    | TZ_def_00@g.com | TZ_def_00@g.com  | Password should not be the same as your email address |
	| teamzero_test_01 |                 | teamzero_TEST_01 | Password should not be the same as your username      |
	|                  |                 | 12345678         | Password must contain at least one character          |
	|                  |                 | qwertyui         | Password must contain at least one number             |
	|                  |                 | P@SSW0RD         | Password must contain at least one lowercase          |
	|                  |                 | p@ssw0rd         | Password must contain at least one uppercase          |

@register
Scenario Outline: Register Page - Confirm Password Field validation
	Given User is the register page
	When User enter '<password>' value in Register Page 'password' text field
	And User enter '<confirmPassword>' value in Register Page 'confirmPassword' text field
	And User clicks the register button
Examples:
	| password | confirmPassword | message                 |
	|          |                 | Password can't be blank |
	| P@ssw0rd | password        | Passwords must match    |