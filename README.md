# CreditCardValidator

The **CreditCardValidator** project provides an API for validating credit card numbers. The service checks if a credit card number is valid, returns a formatted version, and handles errors related to invalid card numbers.

This repository contains the implementation of the credit card validation logic, along with unit tests to ensure the correctness of the functionality.

## Features

- **Card Validation**: Validates credit card numbers using a Luhn algorithm or custom logic.
- **Formatted Card Number**: Returns the formatted card number (e.g., "4539 1488 0343 6467").
- **Error Handling**: Returns appropriate error messages for invalid card numbers or input errors (e.g., empty or non-digit numbers).

## Table of Contents

- [Installation](#installation)
- [Target Framework](#target-framework)
- [Usage](#usage)
- [Running Tests](#running-tests)

## Target Framework
- **.NET 8**: The application targets **.NET 8** for cross-platform development and performance improvements.

## Installation

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/reymarksolsona/CreditCardValidator.git

2. Navigate to the project folder:

   ```bash
   cd CreditCardValidator

3. Install the required dependencies using NuGet or dotnet:

   ```bash
   dotnet restore
   
  ## Usage
  
  To run the application, you need to launch the API which is hosted in an ASP.NET Core application.
  
  ### Build and run the application:
  
  ```bash
  dotnet build
  dotnet run
  ```

  The API will be available at https://localhost:7053.
  
  **To test credit card validation, make a POST request to the /Validate endpoint like:**
  
  ```bash
  https://localhost:7053/api/CreditCard/Validate/{cardNumber}
  ```

  **You will receive a response indicating whether the card is valid or not.**


  **Example Response**
  
  For a valid card number:
  ```bash
  {
      "data": "Card number is valid.",
      "errors": [],
      "hasError": false,
      "statusCode": 200
  }
  ```

  For an invalid card number:
  ```bash
  {
      "data": [],
      "errors": [
          ""Card number is not valid."
      ],
      "hasError": true,
      "statusCode": 400
  }
  ```

  ## Running Tests

  This project includes unit tests to verify the functionality of the `CreditCardController`.
  
  ### To run the tests, follow these steps:
  
  1. Navigate to the `CreditCardValidator.Tests` project folder:
  
  ```bash
  cd CreditCardValidator.Tests
  ```

  2. Run the tests using dotnet:
  
  ```bash
  dotnet test
  ```
  
  The test results will show whether all tests passed successfully.
  
  ### Example Test Cases
  
  - **Validate_ShouldReturnOk_WhenCardNumberIsValid**: Validates if a correctly formatted card number returns a successful response.
  - **Validate_ShouldReturnBadRequest_WhenCardNumberIsInvalid**: Validates if an invalid card number returns a `BadRequest` response with an error message.
  - **Validate_ShouldReturnBadRequest_WhenCardNumberIsEmpty**: Ensures that empty card numbers trigger an error message.
  - **Validate_ShouldReturnBadRequest_WhenCardNumberContainsNonDigits**: Verifies that card numbers with non-digit characters are rejected.