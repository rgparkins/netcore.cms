FROM microsoft/dotnet:2.2-sdk
WORKDIR /app

# copy csproj and restore as distinct layers
COPY . ./app

RUN dotnet restore 
#
## copy everything else and build app
#COPY aspnetapp/. ./aspnetapp/
#WORKDIR /app/aspnetapp
#RUN dotnet publish -c Release -o out
#
#
#FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
#WORKDIR /app
#COPY --from=build /app/aspnetapp/out ./
#ENTRYPOINT ["dotnet", "aspnetapp.dll"]