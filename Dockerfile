FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductInventoryManager.Api/ProductInventoryManager.Api.csproj", "ProductInventoryManager.Api/"]
COPY ["ProductInventoryManager.Application/ProductInventoryManager.Application.csproj", "ProductInventoryManager.Application/"]
COPY ["ProductInventoryManager.Domain/ProductInventoryManager.Domain.csproj", "ProductInventoryManager.Domain/"]
COPY ["ProductInventoryManager.Persistence/ProductInventoryManager.Persistence.csproj", "ProductInventoryManager.Persistence/"]
COPY ["ProductInventoryManager.Identity/ProductInventoryManager.Identity.csproj", "ProductInventoryManager.Identity/"]
RUN dotnet restore "ProductInventoryManager.Api/ProductInventoryManager.Api.csproj"
COPY . .
WORKDIR "/src/ProductInventoryManager.Api"
RUN dotnet build "ProductInventoryManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductInventoryManager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductInventoryManager.Api.dll"]