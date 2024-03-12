FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

#puertos a los que se va exponer
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

# Copy everything
COPY . ./
RUN dotnet restore "NuevaSolVS.csproj"

COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "NuevaSolVS.dll"]

