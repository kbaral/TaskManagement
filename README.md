# TaskManagement


This project is created in .NET 6.0 using entity framework core and authored by Kshitiz Baral

## Database setup

Database is created through code first approach of entity framework, so no scripts were written in SQL directly, I have deployed the database to azure as well

We can point to local as well, and in the project folder we need to run the command: `dotnet ef database update`, I already have seeded a row (just one) through migration so it is ready
with data as well.

### Code Setup 

We can run the code after downloading the code and run Swagger UI as well, but we need to change the connection string and run the above command: `dotnet ef database update`

## Azure deployment
This api is available at: https://taskmanagement20220523151850.azurewebsites.net/api/tasks
Other endpoints are available for clients like postman

Sample body of POST request

{
  "name": "string",
  "description": "string",
  "dueDate": "2022-05-23T10:30:29.308Z",
  "startDate": "2022-05-23T10:30:29.308Z",
  "endDate": "2022-05-23T10:30:29.308Z",
  "priority": 0,
  "status": 0
}

