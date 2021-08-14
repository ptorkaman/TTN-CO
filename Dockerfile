FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . /app
RUN ls -la
RUN dotnet restore

# Copy everything else and build
RUN dotnet publish -c Release -o /publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:3.1
WORKDIR /app
COPY --from=build /publish .
RUN ls -la
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:5000
ENV TZ=Asia/Tehran


ENTRYPOINT ["dotnet", "/app/ACMS.JourneyLog.dll"]


