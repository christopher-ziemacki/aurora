FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim

ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app

ENTRYPOINT ["/bin/bash", "-c", "dotnet restore && dotnet watch --project Worker run"]
