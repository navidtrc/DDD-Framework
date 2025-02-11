# DDD-Framework

This repository contains a set of libraries designed to facilitate the development of Domain-Driven Design (DDD) projects. The libraries cover essential DDD patterns, domain entities, and utilities to simplify the implementation of common functionalities.

## Project Structure

### 1. **Utilities**
This library includes a set of utility methods and extensions to streamline common development tasks.

- **DateTime Methods**: Handy utilities for working with dates and times.
- **Extensions**:
  - `Assert`: Assertion utilities to simplify validation.
  - `EnumerableExtensions`: Extension methods for working with collections.
  - `EnumExtensions`: Helpers for working with enumerations.
  - `GuidExtensions`: Extensions for handling `GUID` operations.
  - `ModelBuilderExtensions`: Extends EF Core `ModelBuilder` for easier configuration.
  - `QueryableExtensions`: Enhances LINQ query capabilities.
  - `StringExtensions`: Common string manipulation methods.
  - `StringValidatorExtensions`: Utilities for validating string inputs.
  - `ResourceExtension`: Methods for handling resource-based operations.

### 2. **Framework.Domain**
This library encapsulates core domain patterns commonly used in DDD.

- **AggregateRoot**: Base class for aggregate roots.
- **BaseEntity**: Base class for domain entities.
- **IAggregateRoot**: Interface for aggregate roots.
- **IAuditableEntity**: Interface for entities that require audit fields.
- **IDomainEvent**: Interface for domain events.
- **DomainException**: Base class for domain-specific exceptions.
- **BaseValueObject**: Base class for value objects.
- **BusinessId**: Represents a unique identifier in business contexts.

### 3. **Framework.Domain.Toolkits**
This library provides a set of value objects that can be used to model common domain concepts.

- **ValueObjects**:
  - `DateOfBirth`: Value object for representing birth dates.
  - `Email`: Value object for email addresses.
  - `IpAddress`: Value object for IP addresses.
  - `NationalId`: Value object for national identification numbers.
  - `LegalNationalCode`: Value object for legal codes.
  - `OtpCode`: Value object for one-time passcodes.
  - `Percentage`: Value object for percentages.
  - `PhoneNumber`: Value object for phone numbers.
  - `Price`: Value object for monetary values.
  - `Quantity`: Value object for quantities.
  - `Url`: Value object for URLs.

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/navidtrc/DDD-Framework.git
