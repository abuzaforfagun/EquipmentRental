# EquipmentRental

## Technical Implementation
* Essential standalone library is developed in .net Standard.
* Web API is developed in .net core.
* Repository pattern is used to talk with in-memory persistence.
* xUnit is used for unit testing.
* .net core default DI is used for dependency injection.
* Microsoft default logger is used for logging errors and exceptions.
* Automapper is used for mapping profile.
* Angular 7.2 is used as a front end framework.

### Mandatory features needed to add
* Token based authentication.
* Swagger
* Write test cases for Repository project.
* Write test cases for the front end application.

### Good to have features
* Use CQRS in the backend.
* Implement micro-service strategies.
* Use state management in frontend.
* Add docker support.
* Integrate with CI/CD tools.

## Setup environment
**Prerequisite**
Make sure you have installed .NET Core SDK 2.1 and Node.
#### Backend
You can run the backend service in two ways.
1. Open EquipmentRental.sln in visual studio. Clean and rebuild the solution and run the application from the Debug menu.
2. Open a command line on the solution folder. And use the following commands.

```
dotnet restore ./  
``` 

``` 
dotnet build 
```

``` 
dotnet run
```
 
#### Frontend
1. Open command line tool on **Client/EquipmentRental** folder.
2. Execute following command,
```
npm i
``` 

3. Make sure backend service using **44300 port**. Otherwise, change the port number in **envoirnment.ts** file.
4. Execute 
```
ng serve -o
```
