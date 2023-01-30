Feature:1CRMCloud

Automation tests for the portal https://demo.1CRMCloud.com/

@smoke
Scenario: Creating a new contact
Given I log in to the 1CRMCould as a admin registered user
    And I navigated to "Contacts" under "Sales & Marketing"
When I enter new contact details
    And I save the contact details
Then I recieved contact created confirmation
    And I verify the contact details