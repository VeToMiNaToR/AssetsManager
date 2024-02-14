ARG ASPNETCORE_ENVIRONMENT=Production

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 44386
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_URLS=http://+:44386

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["Services/Services.CoreApi/Services.CoreApi.csproj", "Services/Services.CoreApi/"]
RUN dotnet restore "Services/Services.CoreApi/Services.CoreApi.csproj"
COPY . .
WORKDIR "/src/Services/Services.CoreApi"
RUN dotnet build "Services.CoreApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.CoreApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssetsManager.Services.CoreApi.dll"]