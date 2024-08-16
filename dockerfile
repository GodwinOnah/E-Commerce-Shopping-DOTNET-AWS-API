FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

#Create this directory in docker container
WORKDIR /BlessingAPI 

# Copy everything from where I am into where I am in docker
COPY . ./ 

# Restore .csproj in files copied to docker 
RUN dotnet restore 

RUN dotnet build -c release -o /BlessingAPI/build 

FROM build As publish
# Publish the project into a publish folder
RUN dotnet publish -c release -o /BlessingAPI/publish 

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app 
EXPOSE 5000
COPY --from=publish /BlessingAPI/publish  ./
ENTRYPOINT ["dotnet", "API.dll"]

