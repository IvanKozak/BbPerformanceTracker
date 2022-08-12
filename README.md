[![build and test](https://github.com/IvanKozak/BbPerformanceTracker/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/IvanKozak/BbPerformanceTracker/actions/workflows/build-and-test.yml)

# Basketball Performance Tracker
Web app that helps with tracking your performance in 3x3 basketball matches and training sessions.

## Description

Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.

## Roadmap

- [x] Create MS sql server database project with stored procedures
- [x] Create class library that implements data access using Dapper
- Create MinimalAPI project with:
    - [ ] Authentication and authorization
    - [x] User CRUD endpoints
    - [x] Shooting drill CRUD endpoints
    - [x] 3x3 match CRUD endpoints
    - [ ] Data validation

- Create Blazor Server project that implements:
    - [x] Authentication and authorization using Azure AD B2C
    - [x] Page for submitting shooting drill form
    - [x] Page for viewing user's own profile
    - [x] Page for submitting 3x3 match form
    - [ ] Good looking home page

- [ ]  Add some CSS to make Blazor pages a bit prettier. 

- Improve code coverage with test by adding:
    - [ ] Unit tests for API endpoints
    - [ ] Unit tests for Blazor components
    - [ ] Integration tests for API + Database using WAF

## Getting started

In order to run API or BlazorServer application locally, you need to follow this steps:

1. Clone this repository
2. Open solution with Visual Studio and publish project found at *BbPerformanceTracker/BbPerformanceTrackerDb* to MS SQL database
3. Update *appsettings.json* at *BbPerformanceTracker/API* and *BbPerformanceTracker/BlazorApp*:
    - add connection string object and point to database you published by adding it's connection string under *"Default"*
    - Setup your AD B2C such as it points to user workflows
4. Build and run API or BlazorApp project
