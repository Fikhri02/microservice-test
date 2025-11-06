Feature: Order total calculation
  In order to know the cost of an order
  As a customer
  I want to see the total price based on quantity and unit price

  Scenario: Calculate total correctly
    Given I have an order service
    When I calculate total for quantity 2 and price 50
    Then the result should be 100