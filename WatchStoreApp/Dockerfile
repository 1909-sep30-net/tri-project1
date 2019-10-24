FROM mcr.microsoft.com/dotnet/core/sdk:3.0 As build

WORKDIR /app

COPY *.sln ./
COPY WatchStoreApp.Business/*.csproj WatchStoreApp.Business/
COPY WatchStoreApp.Data/*.csproj WatchStoreApp.Data/
COPY WatchStoreApp.Tests/*.csproj WatchStoreApp.Tests/
COPY WatchStoreApp/*.csproj WatchStoreApp/

RUN dotnet restore

COPY . ./

RUN dotnet publish WatchStoreApp - c Release -o publish --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS http://+:80

CMD ["dotnet", "WatchStoreApp.dll"]

