# TranslatorApp

> This app makes translations using 'FunTranslation' APIs, adding new languages and list old translations.


## Processes required to run the project;

### 1. Way

In MSSQL, you can open a new query console from the master and create the script execution database in the script.sql file. In the TranslatorApp.API project, fix the connection string in 'appsettings.json' and run the project.

### 2. Way

Create a database named 'TranslatorAppDb' in MSSQL.
Fix the connection string in 'appsettings.json' in TranslatorApp.API project.
Open the 'Package Manager Console' via Visual Studio (on the TranslatorApp.Data project) and run the commands below, respectively (migration);

```
add-migration Initial
update-database
```
