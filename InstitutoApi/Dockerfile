#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
#EXPOSE 5000
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["InstitutoApi/InstitutoApi.csproj", "InstitutoApi/"]
RUN dotnet restore "InstitutoApi/InstitutoApi.csproj"
COPY . .
WORKDIR "/src/InstitutoApi"
RUN dotnet build "InstitutoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InstitutoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstitutoApi.dll"]