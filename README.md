#### A small exercise WindowsForm application made for a school project.
#### The idea of it is an app that the employees of a fitness center can use to run basic operations, such as registering new members, seeing if their memberships are valid and such.
#### The backend has been written with EFCore and for the database I've used a locally hosted MariaDB instance. As for the frontend, it has been written with WindowsForm.
# 
Notes: 
- The project can be compiled and ran only on Windows as WinForm requires native libraries.
- When using the application a local instance of MariaDB is required.
- Also in DataLayer/FitnessDbContext.cs the ip address for the DB needs to be set accordingly.
