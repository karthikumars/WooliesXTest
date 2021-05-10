# WooliesXTest
Test project for woolies x tech challenge

**Project Structure**

Project strcture is as follows:

<img src="images/Image 1.png" />

Shopping.Models      - Domain models layer that contains all model definitions <br/>
Shopping.Respository - This layer mainly deals with data mostly from external api (WooliesX) <br/>
Shoppiong.Service    - Business logic layer that contains all business logic for the given exercises <br/>
Shopping.Api         - Main api layer contains  list of controllers and  web infrastructure<br/>
UnitTests            - Separate unit test projects are created separately for each layer <br/>

**Infrastructure**

Implemented the following infrastructures:-

Logging: Used structure logging using Serilog component and Application Insights sink<br/>
ExceptionHandling: Used middleware for global exception handling, and serilog with application insights for logging the exceptions<br/>
HealthCheck: Health check controller will return whether shopping api is alive or not<br/>
Documentation : Used swagger for documentation<br/>

**Design patterns**

Used following design patterns:

Repository pattern - For accessing data from wooliex dev challenge. This provides abstraction between from business and data store. Any changes to data store will not affect business layer <br/>
Factory pattern - Used factory pattern for deciding the sorting strategy. ProductSorter is factory class which decides which sorting strategy object to be created based on sortoption passed in api request. This factory makes loosely couples business logic service and sorting strategies for any future changes <br/>
Strategy pattern - Used strategy pattern for implementing different sorting strategy. This will ensure any changes to one sorting method will not affect others and also provides way to easily additional sorting options <br/>

**Design principles**

Followed SOLID design principles whereever applicable.

**Unit Tests**

Use Xunit unit test framework and Moq mocking framework for creating unit tests. Have created one unit test for testing simple response, but more unit tests can be created.

**Hosting**

Hosted application to azure app service. The urls are below:

Base Url : https://shoppingapi20210506101400.azurewebsites.net/shopping
Exercise1(including method) : https://shoppingapi20210506101400.azurewebsites.net/shopping/user
Exercise2: https://shoppingapi20210506101400.azurewebsites.net/shopping/sort
Exercise3: https://shoppingapi20210506101400.azurewebsites.net/shopping/trolleyTotal
HealthCheck: https://shoppingapi20210506101400.azurewebsites.net/health
