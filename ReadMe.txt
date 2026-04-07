To run and test my Fitness Tracker system, the following steps are necessary:
===================================================================================
1. To set up the project, you need to download MySQL Server, MySQL Workbench, 
   and MySQL Connector for .NET. 

2. After installing the MySQL Server and MySQL Workbench, install the mysqldump file 
   to your local MySQL Server database.

 - In my assignment folder, I have included the "Database.sql" SQL file.

 - Please import this SQL file into the MySQL Workbench.
   (Please refer to "How to import self-contained SQL file" in the section below)

3.Add references "MySql.Data" extension to the project file.

 - Right-click the project in Solution Explorer → Manage NuGet Packages.

 - Go to Browse, search for MySql.Data and select, and then click install.

______________________________________________________________________________________

"How to import self-contained SQL file" into the MySQL Workbench
================================================================

- Open the MySQL Workbench.
- In the "Server" tab, click on "Data Import".
- Select "Import from Self-Contained File" and locate the "Database.sql" SQL file.
- Click "New" of Default Target Schema in order to create a new schema.
- And then, choose your created new schema as Default Target Schema.
- Please go to the "Import Progress" tab, and then click "Start Import".
- Then, please refresh SCEMAS under Navigator.

__________________________________________________________________________________________

****Important****

- After importing the "Database.sql" SQL file, please change to your own MySQL database 
  data source, port, username, and password ‌as necessary in the "DatabaseOperations.cs" 
  class of my project.

- string connectionString = "Server=localhost;Database=fitness_db;
  Username=root;Password=root";

- Default MySQL Port is 3306.

- When your MySQL server uses a non-default port (not 3306), you must add the Port 
  parameter to your connection string.

- string connectionString = "Server=localhost;Port=yourMySQLPort;
  Database=yourCreatedNewSchemaName;Username=root;Password=yourMySQLPassword;";
____________________________________________________________________________________


===============Run the Project from Visual studio================

The following is testing data for my system.

User
+++++++

Username      -	user1
Password      -	Pass12345678

___________________________________________________________________________________




