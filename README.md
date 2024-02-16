# basics.dotnet
> [!NOTE]
> In this project .Net 8 used.

## Introduction
- [X] [Summary](https://github.com/furkan-ozkan/basics.dotnet/tree/main?tab=readme-ov-file#summary)
- [X] [Need To Install](https://github.com/furkan-ozkan/basics.dotnet/tree/main?tab=readme-ov-file#need-to-install)
- [X] [Preparetion](https://github.com/furkan-ozkan/basics.dotnet/tree/main?tab=readme-ov-file#preparetion)
- [X] [Creating Project](https://github.com/furkan-ozkan/basics.dotnet/tree/main?tab=readme-ov-file#creating-project)
- [X] [First Look](https://github.com/furkan-ozkan/basics.dotnet/tree/main?tab=readme-ov-file#first-look)
- [X] [Create Models & Context](https://github.com/furkan-ozkan/basics.dotnet/tree/main?tab=readme-ov-file#create-models--context)
  - [X] [Models](https://github.com/furkan-ozkan/basics.dotnet/tree/main?tab=readme-ov-file#models)
  - [X] [Context](https://github.com/furkan-ozkan/basics.dotnet/tree/main?tab=readme-ov-file#context)
- [X] [Database Connection](https://github.com/furkan-ozkan/basics.dotnet/tree/main#database-connection)
- [X] [Migrations](https://github.com/furkan-ozkan/basics.dotnet/tree/main#migration)
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

## Database Connection
First of all we need to create a database, i created it named as ```dotnetbasicsdb```.
Now we will update our appsettings.json file, we need to add a db connection string in here. <br />
[You can find your connection string in here.](https://www.connectionstrings.com/) <br />
After you find it we need to add our connection string in appsettings.<br />
```
  "ConnectionStrings": {
    "DefaultConnection": "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=dotnetbasicsdb;"
  }
```
<br />

![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/appsettings.png)<br />

I named it as ```DefaultConnection``` but its not important you can named it whatever you want. <br />
Now lets use this connection string, for using it we will work on ```program.cs```. <br />
```
builder.Services.AddDbContext<ApplicationDBContext>( options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);
```
we need to add this in ```program.cs``` for using our connetion string in our ```ApplicationDBContext.cs```.

## Migration
Next step is creating migrations. Open terminal and type ```dotnet ef migrations add init```. <br />
If everything is works correctly we will see our "Migrations" folder in project like this.<br /><br />
![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/migrationsfolder.png)<br />
Now we need to use this migration scripts to create our tables in database. Open terminal and write.<br />
```dotnet ef database update``` <br />
Now lets check our database and if we saw our tables that means everything going right.<br /><br />
![](https://github.com/furkan-ozkan/basics.dotnet/blob/main/ReadmeImages/pgadmintables.png)<br />

## Data Transfer Objects (Dtos)
* Create a folder named as ```Dtos```
* Create subfolders named as your models.
* We will create 3 Dto file for each model. <br />
  ```UserRequestDto.cs```<br />
  ```CreateUserRequestDto.cs```<br />
  ```UpdateUserRequestDto.cs```<br />
  ![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/dtos.png)
  <br />
> [!NOTE]
> Inside of Dto files is optional so you can create however you want. <br />

In this project i create them like this. <br />
  ![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/userdtos.png)
<br />

## Mappers
* Create a folder named as ```Mappers```
* Basicly we need mappers for transform between models and Dtos. <br />
![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/mappers.png)
<br />

> [!CAUTION]
> This image has syntax error in update func. You should use ```;```.
<br />

## Controller
### Creating Controller
* First of all create a folder named as ```Controllers```
> [!IMPORTANT]
> Do this steps for all of your controllers.
* In this folder create controllers for your models like ```UserController.cs```
* Open ```program.cs``` and add this to thing in it to activate our controllers.
  * ```builder.Services.AddControllers();```
  * ```app.MapControllers();```
* Now lets get ready to our controllers. Open your controllers.
  * Create readonly variable for your DB context.
  * Create a constructor, as parameters ask DB context.
  * In constructor set your parameter in your readonly variable.
  * After that create a route for your controller, write this on your class.
    * ```[Route("api/anime")]```
    * ```[ApiController]``` <br />
    ![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/controllerconstructor.png)

<br />


### HTTP Requests
Now we will write our http request functions. Lets get in our controller.
#### [HTTPGet]
##### GetAll
* First of all we need an attribute. ```[HttpGet]```
* After our attribute we will create function with ```IActionResult``` return.
* Name the function like ```GetAll```
* In this func. we need a var and this var will get all list with ```ToList()``` fuc.
* But we should use mapper to convert data to dto. Put ```.Select(x => x.ToUserRequestDto())``` end of the ToList func.
* Last of all we need a ```Ok()``` return with our variable. <br />
![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/getall.png)
<br />

##### GetById
* For a single get return we need some update to ```GetAll``` function.
* Lets update our ```HttpGet``` like this. ```[HttpGet("{id}")]```
* Lets add a id parameter to our function. ```GetById([FromRoute] int id)```
* We will use ```Find``` func. not ```ToList``` in here and we need to send id in ```Find(id)``` func.
* Lets check is it null? if it is null we will return ```NotFound()```
* if its not we will use same ```Ok(user.ToUserRequestDto())``` func. <br />
  ![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/getbyid.png)
<br />

#### [HTTPPost]
##### Create
* Create a function with ```HttpPost``` attribute and ```[FromBody]``` parameters.
* As a parameter ask ```CreateUserRequestDto``` or how did you named it.
* Return type is ```IActionResult```.
* Use ```ToUserFromCreateDTO();``` and create a user.
* with context add it in to list and save.
* Finally find it and return. <br />
  ![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/httppost.png)
<br />

#### [HTTPPut]
##### Update
* So similar. Use ```HttpPut``` and add ```[Route("{id}")]``` as an extra attribute.
* Parameters will be ```[FromRoute] int id``` and ```[FromBody] UpdateUserRequestDto userDto```
* in func. use ```Find``` and find user at that id.
* Use update mapper, save changes and retur. <br />
  ![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/httpput.png)
<br />

#### [HTTPDelete]
##### Delete
* attributes ```[HttpDelete]``` ,```[HttpRoute]```
* Find user from route and remove it users list under context <br />
  ![](https://raw.githubusercontent.com/furkan-ozkan/basics.dotnet/main/ReadmeImages/httpdelete.png)
<br />
