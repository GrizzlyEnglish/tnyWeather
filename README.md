# tnyWeather

The tiniest weather app you have ever seen. Enter in your city name, zip code, or GPS coordinates in order to see how the weather is in your area! 

Built in Blazor WASM/dotnet web API and nUnit for testing

# How to run

- Install dotnet 6 SDK
- Add API key to Server/Properties/launchSettings.json or .vscode/launch.json for debugging
- Build the application `dotnet build`
- Run the application via `dotnet run --project .\Server\tnyWeather.Server.csproj`
- If you have VSCode installed you can use F5 to run debugger; or you can install Visual Studio to get the full suite of controls

# Docker support

In order to run from docker you have to run from the top level and specify the dockerfile before running

- Install docker desktop
- Start at top level of repo /tny-weather
- `docker build -f .\Server\Dockerfile -t tny-weather . --build-arg API_KEY={INSERT_KEY}`
- `docker run -p 5000:80 -p 5001:443 -it tny-weather`