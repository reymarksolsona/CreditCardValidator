# CreditCardValidator

The **CreditCardValidator** project provides an API for validating credit card numbers. The service checks if a credit card number is valid, returns a formatted version, and handles errors related to invalid card numbers.

This repository contains the implementation of the credit card validation logic, along with unit tests to ensure the correctness of the functionality.

## Features

- **Card Validation**: Validates credit card numbers using a Luhn algorithm or custom logic.
- **Formatted Card Number**: Returns the formatted card number (e.g., "4539 1488 0343 6467").
- **Error Handling**: Returns appropriate error messages for invalid card numbers or input errors (e.g., empty or non-digit numbers).