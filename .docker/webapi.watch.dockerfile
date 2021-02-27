FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

WORKDIR /app

ENTRYPOINT ["/bin/bash", "-c", "dotnet restore && dotnet watch --project WebApi run"]