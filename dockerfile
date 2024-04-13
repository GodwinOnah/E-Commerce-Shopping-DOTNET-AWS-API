FROM mcr.microsoft.com/dotnet/aspnet:7.0
COPY . /App
WORKDIR /App
ENTRYPOINT ["dotnet","BagShop-API.dll"]