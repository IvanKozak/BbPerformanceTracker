[![build and test](https://github.com/IvanKozak/BbPerformanceTracker/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/IvanKozak/BbPerformanceTracker/actions/workflows/build-and-test.yml)

# Basketball Performance Tracker
Web app that helps with tracking your performance in 3x3 basketball matches and training sessions.

## Description

### Blazor Server App

In an web application, user can click on  *Login* button on main page in order to sign in or sign up. Authentication process is enabled by Azure Active Directory B2C.

<img width="458" alt="signin" src="https://user-images.githubusercontent.com/32243530/184495718-e34d0d27-b71a-4803-9bc9-189edf691f41.png">

When user is logged in, he can submit shooting drill form or 3x3 match form by navigating to respective page.

<img width="548" alt="sdform" src="https://user-images.githubusercontent.com/32243530/184496098-a36a1eea-4a06-4933-b235-895906606632.png">

<img width="557" alt="totmatchform" src="https://user-images.githubusercontent.com/32243530/184496101-d748f396-739b-4279-bbd9-0047f2f06c20.png">

Data is stored in MS SQL database and is accessed via repositories in class library with use of Dapper. 

Also user can access its own profile page.

<img width="923" alt="profile" src="https://user-images.githubusercontent.com/32243530/184496240-eec61604-97eb-47b9-880f-adda21efad38.png">

Users can see profiles of other users by following /profile/**user_id**.

### API

API is now allowing for CRUD access to user, shooting drill and 3x3 match entries.

<img width="208" alt="apiuserendpoints" src="https://user-images.githubusercontent.com/32243530/184497041-651680ab-c7a1-444c-affe-9bee4a065e1f.png">

<img width="274" alt="apisdendpoints" src="https://user-images.githubusercontent.com/32243530/184497046-399c1b22-549f-40b1-a350-bd3e7767937d.png">

<img width="278" alt="apitotmatchendpoints" src="https://user-images.githubusercontent.com/32243530/184497048-8504fc11-3c8f-459c-b395-41f76f201700.png">


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
