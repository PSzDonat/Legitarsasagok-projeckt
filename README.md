# Legitarsasagok-projeckt

### Run/Build

Wpf:

0) Requires `Mssql`
1) Navigate to root of the project.
2) Open `Legitarsasagok-REST-API` in Visual Studio
4) Open `Package Manager` by going to `Tools>NuGet Package Manager>Pacage Manager Console`
5) Run `Add-Migration Initial_Creation`
6) Press Run Button

Mssql:

1) Navigate to root of the project.
2) Run `docker-compose up -d`
3) Open `Legitarsasagok-REST-API` in Visual Studio
4) Open `Package Manager` by going to `Tools>NuGet Package Manager>Pacage Manager Console`
5) Run `Add-Migration Initial_Creation`
6) Run `Update-Database`

Rest Api:

0) Requires `Mssql`
1) Navigate to root of the project.
2) Open `Legitarsasagok-REST-API` in Visual Studio
3) Run it in `IIS Express` | :warning: Do not run it in `Docker`!

Vue:

0) Requires `Rest Api`
1) Navigate to `Legitarsasagok-Vue` folder.
2) Run `npm i`
3) Run `npm run dev`

## Készítők:

Gáspár Róbert

Szarvas Márton

Palánki-Szűcs Donát
