# Weather-Client-Tool
Custom Weather Client Tool  - Command Line tool develop using DotnetCoreApp 3.1
It will take user input as City and gives the weather related information e.g. Temperature , Windspeed etc.

# Run Weather-Client-Tool in Local Sytem
> Clone this project in local system
> Go to project repo i.e. `Weather-Client-Tool\WeatherTool.ConsoleApp`
> In address bar type `cmd` and press enter
> Run below command one by one
    > dotnet pack
    > dotnet new tool-manifest
    > dotnet tool install --add-source ./nupkg WeatherTool.ConsoleAPP
    > dotnet tool list
    > dotnet tool run weathertool kolkata  
![Kolkata_Tempareture](https://github.com/priyabrata-samanta/Weather-Client-Tool/assets/70884906/47b9d23a-bc6f-46a0-8263-17eaac0d560b)
