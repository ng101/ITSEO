# InfoTrack
## TO RUN
Open the InfoTrack sln, build and run. 
Should be running on IIS Express - http://localhost:62077/

Navigate to folder repos\InfoTrack\InfoTrack.UI
Open cmd. Enter command 'npm install'. Enter command 'npm start'.

Ensure baseUrl in InfoTrackClient.js client is http://localhost:62077 if error connecting to API.

Search data is already prepopulated but you are able to change search provider between bing/google.

## TECH
* .NET Core 3.1
* Node 6.17.1
* MediatR
* XUnit
* Moq


## ARCHITECTURE
CQRS with onion architecture

### Domain 
This project contains all entities relating to the domain.

### Application 
This project contains the business logic. 

### Infrastructure 
This project contains the implementation of web services and parser logic.

### API 
Contains controllers and middleware setup.

### Dependencies 
The project is based on onion architecture - Inner layers of the below diagram should not reference outer layers.

![projects_dependencies](docs/clean_architecture.jpg)


### TODO
- Saving search rankings would have been implemented by a new command within the Application layer to save the results in a DB. A new query can then be created in this layer to get these figures and analyse accordingly. 
- Health checks: Search Apis
- Integration Tests.
- Logging
- Move urls to config.
- Sanatize Urls inputted by User

