FROM mcr.microsoft.com/dotnet/sdk:10.0 AS builder
WORKDIR /app
COPY WebWarriors.Aquanetix.Platform/*.csproj WebWarriors.Aquanetix.Platform/
RUN dotnet restore ./WebWarriors.Aquanetix.Platform
COPY . .
RUN dotnet publish ./WebWarriors.Aquanetix.Platform -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=builder /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "WebWarriors.Aquanetix.Platform.dll"]
