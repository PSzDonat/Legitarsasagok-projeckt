#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Legitarsasag REST API/Legitarsasag REST API.csproj", "Legitarsasag REST API/"]
RUN dotnet restore "Legitarsasag REST API/Legitarsasag REST API.csproj"
COPY . .
WORKDIR "/src/Legitarsasag REST API"
RUN dotnet build "Legitarsasag REST API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Legitarsasag REST API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Legitarsasag REST API.dll"]