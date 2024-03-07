#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/MovieStream.WebAPI/MovieStream.WebAPI.csproj", "Presentation/MovieStream.WebAPI/"]
COPY ["Core/MovieStream.Application/MovieStream.Application.csproj", "Core/MovieStream.Application/"]
COPY ["Core/MovieStream.Domain/MovieStream.Domain.csproj", "Core/MovieStream.Domain/"]
COPY ["Infrastructure/MovieStream.Infrastructure/MovieStream.Infrastructure.csproj", "Infrastructure/MovieStream.Infrastructure/"]
COPY ["Infrastructure/MovieStream.Persistence/MovieStream.Persistence.csproj", "Infrastructure/MovieStream.Persistence/"]
RUN dotnet restore "./Presentation/MovieStream.WebAPI/./MovieStream.WebAPI.csproj"
COPY . .
WORKDIR "/src/Presentation/MovieStream.WebAPI"
RUN dotnet build "./MovieStream.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MovieStream.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet","ef","database","update"]
ENTRYPOINT ["dotnet", "MovieStream.WebAPI.dll"]