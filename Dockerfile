FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/CalcTest.Api/CalcTest.Api.csproj", "src/CalcTest.Api/"]
COPY ["src/CalcTest.DI/CalcTest.DI.csproj", "src/CalcTest.DI/"]
COPY ["src/CalcTest.Services/CalcTest.Service.csproj", "src/CalcTest.Services/"]
COPY ["src/CalcTest.Domain/CalcTest.Domain.csproj", "src/CalcTest.Domain/"]
RUN dotnet restore "src/CalcTest.Api/CalcTest.Api.csproj"
COPY . .
WORKDIR "/src/src/CalcTest.Api"
RUN dotnet build "CalcTest.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CalcTest.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CalcTest.Api.dll"]