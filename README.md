[![build and test](https://github.com/IvanKozak/BbPerformanceTracker/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/IvanKozak/BbPerformanceTracker/actions/workflows/build-and-test.yml)

# Basketball Performance Tracker
Web app that helps with tracking your performance in 3x3 basketball matches and training sessions.

## Description

### API

API is allowing for CRUD access to user, shooting drill and 3x3 match entries.

For authentication API uses OIDC protocol and for a successful call requires JWT access token from Azure Active Directory B2C with the right scope.
The Web API authorizes the caller (user) using the ASP.NET JWT Bearer Authorization middleware.

Data is stored in a MS SQL database. Data access is implemented with ADO.NET leveraging stored procedures and Dapper. 

### Blazor Server App

In an web application, user can click on  *Login* button on main page in order to sign in or sign up. Authentication process is enabled by Azure Active Directory B2C.

<img width="458" alt="signin" src="https://user-images.githubusercontent.com/32243530/184495718-e34d0d27-b71a-4803-9bc9-189edf691f41.png">

When user is logged in, he can submit shooting drill form or 3x3 match form by navigating to respective page.

<img width="548" alt="sdform" src="https://user-images.githubusercontent.com/32243530/184496098-a36a1eea-4a06-4933-b235-895906606632.png">

<img width="557" alt="totmatchform" src="https://user-images.githubusercontent.com/32243530/184496101-d748f396-739b-4279-bbd9-0047f2f06c20.png">

Data is accessed via respective API endpoints. Per each call, app requests an access token from B2C and provides it downstream for authentication and authorization.

Also user can access its own profile page.

<img width="923" alt="profile" src="https://user-images.githubusercontent.com/32243530/184496240-eec61604-97eb-47b9-880f-adda21efad38.png">

Admins can see profiles of other users by following /profiles/**user_id**.

## Roadmap

- [x] Create MS sql server database project with stored procedures
- [x] Create class library that implements data access using Dapper
- Create MinimalAPI project with:
    - [x] Authentication and authorization
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
- [ ] Create a CI/CD pipeline for publishing projects to Azure.
## Getting started

In order to run API and BlazorServer applications locally, you need to follow this steps:

### Clone this repository

From your shell or command line:

```Shell
git clone https://github.com/IvanKozak/BbPerformanceTracker.git
```

or download and extract the repository .zip file.

### Publish database project
Open solution with Visual Studio and publish project found at `BbPerformanceTracker\BbPerformanceTrackerDb` to MS SQL database

### Choose the Azure AD tenant where you want to create your applications

As a first step you'll need to:

1. Sign in to the [Azure portal](https://portal.azure.com).
1. If your account is present in more than one Azure AD B2C tenant, select your profile at the top right corner in the menu on top of the page, and then **switch directory** to change your portal session to the desired Azure AD B2C tenant.

### Create User Flows and Custom Policies

Please refer to: [Tutorial: Create user flows in Azure Active Directory B2C](https://docs.microsoft.com/azure/active-directory-b2c/tutorial-create-user-flows)

As user attributes select `"Display Name"`, `"Given Name"`, `"Surname"` and `"Email Address"`.
As application claims select all user attributes and additionaly `"User is new"`, `"User's Object ID"`, `"Job Title"`.

### Register the API app

1. Navigate to the [Azure portal](https://portal.azure.com) and select the **Azure AD B2C** service.
1. Select the **App Registrations** blade on the left, then select **New registration**.
1. In the **Register an application page** that appears, enter your application's registration information:
   - In the **Name** section, enter a meaningful application name that will be displayed to users of the app, for example `BBallTrackerAPI`.
   - Under **Supported account types**, select **Accounts in any identity provider or organizational directory (for authenticating users with user flows)**.
1. Select **Register** to create the application.
1. In the app's registration screen, find and note the **Application (client) ID**. You use this value in your app's configuration file(s) later in your code.
1. Select **Save** to save your changes.
1. In the app's registration screen, select the **Expose an API** blade to the left to open the page where you can declare the parameters to expose this app as an API for which client applications can obtain [access tokens](https://docs.microsoft.com/azure/active-directory/develop/access-tokens) for.
The first thing that we need to do is to declare the unique [resource](https://docs.microsoft.com/azure/active-directory/develop/v2-oauth2-auth-code-flow) URI that the clients will be using to obtain access tokens for this Api. To declare an resource URI, follow the following steps:
   - Select `Set` next to the **Application ID URI** to generate a URI that is unique for this app.
   - For this sample, accept the proposed Application ID URI (`https://{tenantName}.onmicrosoft.com/{clientId}`) by selecting **Save**.
1. All APIs have to publish a minimum of one [scope](https://docs.microsoft.com/azure/active-directory/develop/v2-oauth2-auth-code-flow#request-an-authorization-code) for the client's to obtain an access token successfully. To publish a scope, follow the following steps:
   - Select **Add a scope** button open the **Add a scope** screen and Enter the values as indicated below:
        - For **Scope name**, use `access_as_user`.
        - For **Admin consent display name** type `Access TodoListService-aspnetcore-webapi`.
        - For **Admin consent description** type `Allows the app to access TodoListService-aspnetcore-webapi as the signed-in user.`
        - Keep **State** as **Enabled**.
        - Select the **Add scope** button on the bottom to save this scope.

#### Configure the API app  to use your app registration

> In the steps below, "ClientID" is the same as "Application ID" or "AppId".

1. Open the `API\appsettings.json` file.
1. Find the key `Instance` and replace the value with your tenant name. For example, `https://fabrikam.b2clogin.com`
1. Find the key `Domain` and replace the existing value with your Azure AD tenant name.
1. Find the key `ClientId` and replace the existing value with the application ID (clientId) of the application copied from the Azure portal.
1. Find the key `SignUpSignInPolicyId` and replace with the name of the `Sign up and sign in` policy you created.

### Register the client app (BlazorApp)

1. Navigate to the [Azure portal](https://portal.azure.com) and select the **Azure AD B2C** service.
1. Select the **App Registrations** blade on the left, then select **New registration**.
1. In the **Register an application page** that appears, enter your application's registration information:
   - In the **Name** section, enter a meaningful application name that will be displayed to users of the app, for example `BBallBlazor`.
   - Under **Supported account types**, select **Accounts in any identity provider or organizational directory (for authenticating users with user flows)**.
   - In the **Redirect URI (optional)** section, select **Web** in the combo-box and enter the following redirect URI: `https://localhost:7233/`.
     > Note that there are more than one redirect URIs. You'll need to add more from the **Authentication** tab later after the app has been created successfully.
1. Select **Register** to create the application.
1. In the app's registration screen, find and note the **Application (client) ID**. You use this value in your app's configuration file(s) later in your code.
1. In the app's registration screen, select **Authentication** in the menu.
   - If you don't have a platform added, select **Add a platform** and select the **Web** option.
   - In the **Redirect URIs** section, enter the following redirect URIs.
      - `https://localhost:7233/signin-oidc`
   - In the **Front-channel logout URL** section, set it to `https://localhost:7233/signout-oidc`.
   - In **Implicit grant** section,  select the check boxes for **Access tokens** and **ID tokens**.
1. Select **Save** to save your changes.
1. In the app's registration screen, select the **Certificates & secrets** blade in the left to open the page where we can generate secrets and upload certificates.
1. In the **Client secrets** section, select **New client secret**:
   - Type a key description (for instance `app secret`),
   - Select one of the available key durations (**In 1 year**, **In 2 years**, or **Never Expires**) as per your security posture.
   - The generated key value will be displayed when you select the **Add** button. Copy the generated value for use in the steps later.
   - You'll need this key later in your code's configuration files. This key value will not be displayed again, and is not retrievable by any other means, so make sure to note it from the Azure portal before navigating to any other screen or blade.
1. In the app's registration screen, select the **API permissions** blade in the left to open the page where we add access to the APIs that your application needs.
   - Select the **Add a permission** button and then,
   - Ensure that the **My APIs** tab is selected.
   - In the list of APIs, select the API `BBallTrackerAPI`.
   - In the **Delegated permissions** section, select the **Access 'BBallTrackerAPI'** in the list. Use the search box if necessary.
   - Select the **Add permissions** button at the bottom.
   - Select Grant admin consent for (your tenant name).

#### Configure the client app (BlazorApp) to use your app registration

Open the project in your IDE (like Visual Studio or Visual Studio Code) to configure the code.

> In the steps below, "ClientID" is the same as "Application ID" or "AppId".

1. Open the `BlazorApp\appsettings.json` file.
1. Find the key `Instance` and replace the value with your tenant name. For example, `https://fabrikam.b2clogin.com`
1. Find the key `Domain` and replace the existing value with your Azure AD tenant name.
1. Find the key `ClientId` and replace the existing value with the application ID (clientId) of the application copied from the Azure portal.
1. Find the key `SignUpSignInPolicyId` and replace with the name of the `Sign up and sign in` policy you created.
1. Find the key `EditProfilePolicyId` and replace with the name of the `Profile editing` policy you created.
1. Find the key `ClientSecret` and replace the existing value with the key you saved during the creation of the app, in the Azure portal.
1. Find the key `Scope` under `UserRecords` and replace the existing value with the API Scope. For example, `https://{tenantName}.onmicrosoft.com/{service_clientId}/access_as_user`.

### Point API to database

Update `appsettings.json` at `BbPerformanceTracker/API`:
   - add connection string object and point to database you published by adding it's connection string under `"Default"`
   
### Build and run API and BlazorApp

Configure IDE to run multiple project with API starting first.


