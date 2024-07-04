How to import database correctly:
-  To restore Db right-click on databases inside your server, then click on Import data-tier application, and follow the wizard.
-  When asked use the .bacpac file to restore database in sqlserver is inside Libreria/Service
Check connection string in appsettings.json and modify the server and the database, then leave as It is if windows authentication is used to login in the sqlserver, or you can check in https://www.connectionstrings.com/ and use the correct string for your database settings 
 
