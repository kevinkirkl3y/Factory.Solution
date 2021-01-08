# 

#### 

#### by _**Kevin Kirkley**_

## Description
   



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
1. Download the [repository]() onto your computer by clicking the 'clone or download button'.
2. Open within your text editor and navigate to the `RecordCollection` folder and run `dotnet restore` in your console.

### Open with Bash/GitBash:
1. Clone this repository onto your computer: 
```

```
2. Navigate into the '' directory and open in VSCode or preferred text editor using 'code .' in your terminal.
3. Open within your text editor and navigate to the `` folder and run `dotnet restore` in your console.

### AppSettings
* This project requires an AppSettings file. Create your `appsettings.json` file in the main RecordCollection file following the format below. Use your unique password that you created duing MySQLWorkbench installation:

```  
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=;uid=root;pwd=<YourPassword>;"
  }
} 
```
* Update the Server, Port and User Id as needed.
### Setup of MySQL Database 

* Navigate to `` and type `dotnet ef migrations add <MigrationName>` into the terminal. 
* Then, type `dotnet ef database update` into the terminal to create your database tables.

### DB SQL Schema Snippet

* Paste this Schema Create Statement directly into MySQLWorkbench to create this database and its tables. 
```

```


## Known Bugs
* No known bugs at this time. 1/7/2021


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