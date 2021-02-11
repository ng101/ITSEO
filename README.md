# InfoTrack
# MMT
## TO RUN


## TECH
* .NET Core 3.1
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

![projects_dependencies](InfoTrack/docs/clean_architecture.jpg)
