# Introduction 
LahorApp is a web application developed using .NET Core, Angular and SQL Server database, which was developed by my colleague and I. 
The purpose of this app is to improve business of a dry cleanings company. 
The application consists of functionalities which can be very beneficial for a dry cleanings company, such as creating available services to be visible for the clients, creating orders, creating purchase requests and so on. 
Apart from CRUD operations, this application also has other functionalities, such as two-factor authentication, role-based authorization/authentication, generating reports, sending notifications to users etc. 
Also it is worth mentioning that we've used Repository pattern to isolate business logic from controllers to Repositories and Services.
This application is not finished yet, there are also some functionalities left to be implemented. 

The deployed version is available at the following link:
https://lahorwebapp.p2100.app.fit.ba/
In order to have full permissions, use the following credentials to log in:
Username: test1234
Password: test1234

To run the application on your local machine, do the following:
1.	Rebuild Backend solution
2.	Run migrations to update the database using 'update-database' command.
3.	Run 'Npm install' in angular project to install all of the dependencies.
4.	Run backend project.
5.  Run angular project via 'ng serve' command.



