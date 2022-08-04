Feature: GithubUserDetails

Get all details of a specific user

@github
@users
Scenario Outline: Get user details
	Given I have path /'<path>'
	And I have username '<userName>'
	When I trgigger API endpoint for given user '<userName>'
	Then I get full details including '<type>' and '<createDate>'

Examples: 
| path  | userName     | type | createDate           |
| users | teymurovfuad | user | 2019-10-05T12:55:51Z |
