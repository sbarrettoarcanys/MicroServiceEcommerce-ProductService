#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

#temporary use root user to create image directory
USER root

# Ensure the directory exists and has the correct permissions
RUN mkdir -p /app/wwwroot/images/products && \
    chown -R app:app /app/wwwroot/images

USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Set the environment to Production
ENV ASPNETCORE_ENVIRONMENT=Production

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ECommerce.ProductService/ECommerce.ProductService.csproj", "ECommerce.ProductService/"]
COPY ["ECommerce.ProductService.BusinessLogic/ECommerce.ProductService.BusinessLogic.csproj", "ECommerce.ProductService.BusinessLogic/"]
COPY ["ECommerce.ProductService.DataAccess/ECommerce.ProductService.DataAccess.csproj", "ECommerce.ProductService.DataAccess/"]
COPY ["ECommerce.ProductService.Model/ECommerce.ProductService.Models.csproj", "ECommerce.ProductService.Model/"]
COPY ["ECommerce.ProductService.Utility/ECommerce.ProductService.Utility.csproj", "ECommerce.ProductService.Utility/"]
RUN dotnet restore "./ECommerce.ProductService/ECommerce.ProductService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./ECommerce.ProductService/ECommerce.ProductService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ECommerce.ProductService/ECommerce.ProductService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.ProductService.dll"]