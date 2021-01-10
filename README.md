# Dr. Sillystringz's Factory

#### Epicodus C# Many-To-Many Relationship Database Practice 1.8.2021

#### by _**Kevin Kirkley**_

## Description
Dr. Sillystingz factory has a lot of moving parts. This program was created in order to keep up with the regular maintenance needed by machinery. The program tracks the staff of engineers, machinery and the licenses required to be certified to work on the various pieces of equipment. Machinery details include the neccesary repair licensing and engineers are able to note which licenses they hold, as they should only repair machinery they are certified to work on. 
   



## User Stories
* As the factory manager, I need to be able to see a list of all engineers, and I need to be able to see a list of all machines.
* As the factory manager, I need to be able to select a engineer, see their details, and see a list of all machines that engineer is licensed to repair. I also need to be able to select a machine, see its details, and see a list of all engineers licensed to repair it.
* As the factory manager, I need to add new engineers to our system when they are hired. I also need to add new machines to our system when they are installed.
* As the factory manager, I should be able to add new machines even if no engineers are employed. I should also be able to add new engineers even if no machines are installed
* As the factory manager, I need to be able to add or remove machines that a specific engineer is licensed to repair. I also need to be able to modify this relationship from the other side, and add or remove engineers from a specific machine.
* I should be able to navigate to a splash page that lists all engineers and machines. Users should be able to click on an individual engineer or machine to see all the engineers/machines that belong to it.


## Setup/Installation Requirements

### Software Requirements
1. Internet Browser
2. A code editor such as VSCode in order to view or edit codebase. 
3. netcore2.2
4. MySQL
5. MySQLWorkbench.

### Open by downloading:
1. Download the [repository](https://github.com/kevinkirkl3y/Factory.Solution.git) onto your computer by clicking the 'clone or download button'.
2. Open within your text editor and navigate to the `Factory.Solution/Factory` folder and run `dotnet restore` in your console.

### Open with Bash/GitBash:
1. Clone this repository onto your computer: 
```
git clone https://github.com/kevinkirkl3y/Factory.Solution.git
```
2. Navigate into the `Factory.Solution` directory and open in VSCode or preferred text editor using `code .` in your terminal.
3. Open within your text editor and navigate to the `Factory.Solution/Factory` folder and run `dotnet restore` in your console.

### AppSettings
* This project requires an AppSettings file. Create your `appsettings.json` file in the main RecordCollection file following the format below. Use your unique password that you created duing MySQLWorkbench installation:

```  
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=<firstName_lastName_Factory>;uid=root;pwd=<YourPassword>;"
  }
} 
```
* Update the Server, Port and User Id as needed.
### Setup of MySQL Database 

* Navigate to `Factory.Solution/Factory` and type `dotnet ef migrations add <MigrationName>` into the terminal. 
* Then, type `dotnet ef database update` into the terminal to create your database tables.

### DB SQL Schema Snippet

* Paste this Schema Create Statement directly into MySQLWorkbench to create this database and its tables. 
```
CREATE DATABASE  IF NOT EXISTS `kevin_kirkley_factory` 
USE `kevin_kirkley_factory`;

 SET NAMES utf8 ;


DROP TABLE IF EXISTS `__EFMigrationsHistory`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


DROP TABLE IF EXISTS `Engineers`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `Engineers` (
  `EngineerId` int(11) NOT NULL AUTO_INCREMENT,
  `EngineerName` longtext,
  `EngineerContact` longtext,
  `HireDate` datetime(6) NOT NULL,
  PRIMARY KEY (`EngineerId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `LicenseEngineer`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `LicenseEngineer` (
  `LicenseEngineerId` int(11) NOT NULL AUTO_INCREMENT,
  `LicenseId` int(11) NOT NULL,
  `EngineerId` int(11) NOT NULL,
  PRIMARY KEY (`LicenseEngineerId`),
  KEY `IX_LicenseEngineer_EngineerId` (`EngineerId`),
  KEY `IX_LicenseEngineer_LicenseId` (`LicenseId`),
  CONSTRAINT `FK_LicenseEngineer_Engineers_EngineerId` FOREIGN KEY (`EngineerId`) REFERENCES `engineers` (`EngineerId`) ON DELETE CASCADE,
  CONSTRAINT `FK_LicenseEngineer_Licenses_LicenseId` FOREIGN KEY (`LicenseId`) REFERENCES `licenses` (`LicenseId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


DROP TABLE IF EXISTS `Licenses`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `Licenses` (
  `LicenseId` int(11) NOT NULL AUTO_INCREMENT,
  `LicenseType` longtext,
  `IssueDate` datetime(6) NOT NULL,
  PRIMARY KEY (`LicenseId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


DROP TABLE IF EXISTS `MachineLicense`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `MachineLicense` (
  `MachineLicenseId` int(11) NOT NULL AUTO_INCREMENT,
  `MachineId` int(11) NOT NULL,
  `LicenseId` int(11) NOT NULL,
  PRIMARY KEY (`MachineLicenseId`),
  KEY `IX_MachineLicense_LicenseId` (`LicenseId`),
  KEY `IX_MachineLicense_MachineId` (`MachineId`),
  CONSTRAINT `FK_MachineLicense_Licenses_LicenseId` FOREIGN KEY (`LicenseId`) REFERENCES `licenses` (`LicenseId`) ON DELETE CASCADE,
  CONSTRAINT `FK_MachineLicense_Machines_MachineId` FOREIGN KEY (`MachineId`) REFERENCES `machines` (`MachineId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


DROP TABLE IF EXISTS `Machines`;

 SET character_set_client = utf8mb4 ;
CREATE TABLE `Machines` (
  `MachineId` int(11) NOT NULL AUTO_INCREMENT,
  `MachineName` longtext,
  `SerialNumber` longtext,
  `InstallDate` datetime(6) NOT NULL,
  PRIMARY KEY (`MachineId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


```


## Known Bugs
* When adding a repair license to either Engineer or Machine, users are sent to a "NullReferenceException" Page stating that there is an issue with `@if (@Model.Count == 0) within the Index.cshtml view of their respective Views. While sent to this error page, the connection between License and either Engineer or Machine is created. -- In an attempt to fix this I changed the format of adding object to the list within the Index section of their respective Controller. I feel it's important to note that this works in every case except when License is added to the object. 


## Support and contact detail

_Contact Kevin Kirkley at [kevinmkirkley@gmail.com](mailto:kevinmkirkley@gmail.com) with and questions, concerns or additions._


## Technologies Used 

* _C#_
* _MVC_
* _VSCode_
* _netcore2.2_
* _MySQL_
* _MySQLWorkbench_


### License

Copyright (c) 2020 **_Kevin Kirkley_**
This software is licensed under the MIT license.

Copyright 2020 Kevin Kirkley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.