FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src
COPY . . 
WORKDIR /src/FNB.Ecommerce.Services.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o out



FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /src
COPY --from=buil-env /src/FNB.Ecommerce.Services.WebApi/out ./

ENTRYPOINT ["dotnet", "FNB.Ecommerce.Services.WebApi.dll"]