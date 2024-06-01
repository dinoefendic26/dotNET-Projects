# Project for .NET C# development

Using Visual Studio Code, make sure you have the official C# extension downloaded

Write in terminal to see if .NET is downloaded: 
? `dotnet --version`

Command to make new console application:
> `dotnet new console -o name`

To run the application:
> `dotnet run`

To debug the code:
1. first use `ctrl` + `shift` + `P` to open command palette
2. then type in .NET and select `.NET:Generate Assets for Build and Debug` and it will generate a .vscode folder
3. in that folder you will have the `launch.json` file which is for configuration
4. now you can add breakpoints to your code and go to the Run and Debug (`ctrl` + `shift` + `D`) and run code in Debug mode

To compile your code you type:
> `dotnet build`
and your build should be in bin folder as `name.dll`
