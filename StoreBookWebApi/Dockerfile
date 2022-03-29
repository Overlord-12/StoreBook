#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StoreBookWebApi/StoreBookWebApi.csproj", "StoreBookWebApi/"]
COPY ["ServiceFactory/ServiceFactory.csproj", "ServiceFactory/"]
COPY ["ProcessManager/ProcessManager.csproj", "ProcessManager/"]
COPY ["BuisnessObjects/BusinessObjects.csproj", "BuisnessObjects/"]
COPY ["DataManagers/DataManagers.csproj", "DataManagers/"]
COPY ["AuthCommon/AuthCommon.csproj", "AuthCommon/"]
RUN dotnet restore "StoreBookWebApi/StoreBookWebApi.csproj"
COPY . .
WORKDIR "/src/StoreBookWebApi"
RUN dotnet build "StoreBookWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreBookWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreBookWebApi.dll"]