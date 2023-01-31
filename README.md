# BGD_Backend

> ## How to make the application work:
> #
> *First is recommended to install Visual Studio or Rider as in IDE*
> - You should clone this repo into some folder in your computer
> - Install the psql with pgAdmin (optional) to make the local application database
> - Open a terminal in your root folder and then go to the folder *BGD_Backend.WebApi*
> - Run the command: 
>   > dotnet tool install --global dotnet-ef
> 
>   to guarantee you have the needed tools to start your magration
> - Run the command:
>   > dotnet ef database update
>
>   to migrate your database
> - Run the command:
>   > dotnet build -restore
>
>   to make a clean build and install some lost package
> - Run the command:
>   > dotnet run
>
>   to run the application (You can run with your IDE if you have installed one)
>
> - Access this link in your browser to see the program running: 
> https://localhost:7209/swagger/index.html