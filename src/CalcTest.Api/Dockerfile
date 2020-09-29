FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/CalcTest.Api/CalcTest.Api.csproj", "src/CalcTest.Api/"]
RUN dotnet restore "src/CalcTest.Api/CalcTest.Api.csproj"
COPY . .
WORKDIR "/src/src/CalcTest.Api"
RUN dotnet build "CalcTest.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalcTest.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalcTest.Api.dll"]
