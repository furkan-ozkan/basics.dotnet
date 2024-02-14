# basics.dotnet
> [!NOTE]
> In this project .Net 8 used.

## Introduction
- [X] [Summary](https://github.com/furkan-ozkan/basics.dotnet/tree/main?tab=readme-ov-file#summary)
- [X] Need To Install
- [X] Preparetion
- [X] Creating Project
- [X] First Look
- [X] Create Models & Context
  - [X] Models
  - [X] Context
## Summary
This project is developed for learning .Net and backend with Entity Framework. Used "Code First" approch here.<br />
Project basicly creating a Postgresql database and tables, after that using basic CRUD (Get, Post, Put, Delete) operations.<br />
It is developed with Visual Studio Code.

![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/crud.png)

## Need To Install
* C#
* C# Dev Kit
* .Net Extension Pack
* .Net Install Tool
* Nuget Gallery
* C# Extension by JosKreativ

## Preparetion
Search ``` >NuGet ``` in VSCode and open NuGet Gallery. <br />
In this gallery searh for your sql database like this and install it. <br />
![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/nuget.png) <br />
after that search and install 
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Tools

  
## Creating Project
1.  Open VSCode in a folder.
2.  Open Terminal
3.  Write
    * ```dotnet new webapi -o api``` to create project.
    * ```-o api``` for creating a sub folder named as api
4.  Run and test project
    * ```dotnet watch run```

## First Look
When you create your project it comes with a sample. lets clear it. <br /> <br />
![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/programcs.png) <br /><br />

## Create Models & Context
1.   Now lets create a folder named as ```Models```.<br />
     In this project we will use 2 model. Under 'Models' folder lets create ```Anime.cs``` and ```User.cs```.<br /><br />
2.   Now lets create a folder named as ```Data```.<br />
     Under 'Data' folder we need to create an another cs file. I named it like ```ApplicationDBContext.cs```
### Models
* For models we not need any spesific things, we will create our models just like a database table.<br />
Only important thing is we need an id for primary key.
### Context
* First of all we need to extends ```DbContext``` in our ApplicationDBContext.cs like this.<br />
![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/extends.png)<br />
* Now lets create our constructor and as a parameter we will ask ```DbContextOptions``` in our constructor and after that lets send this context option to our constructor base.<br />
![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/constructor.png)<br />
* Last of all we need to create our DbSets. With Entity Framework we will use this DbSets like our database tables.<br />
![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/dbsets.png)<br />
* Finally it looks like this.<br />
![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/applicationdbcontext.png)<br />
