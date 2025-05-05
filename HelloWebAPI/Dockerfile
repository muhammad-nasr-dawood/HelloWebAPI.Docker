# Use the official ASP.NET runtime image (smallest possible)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base  
WORKDIR /app  
# Expose port 80 so containers can be reached
EXPOSE 80  

# Use the full SDK image to build/publish the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build  
WORKDIR /src  

# Copy just the project file and restore first (layer caching)
COPY ["HelloWebAPI.csproj", "./"]  
RUN dotnet restore  

# Copy the rest of the sources and publish to /app/publish
COPY . .  
RUN dotnet publish --configuration Release --output /app/publish  

# Final stage: use the smaller runtime image
FROM base AS final  
WORKDIR /app  
# Copy published output from the build stage
COPY --from=build /app/publish .  
# Launch the API
ENTRYPOINT ["dotnet", "HelloWebAPI.dll"]  
