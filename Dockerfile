FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 5001
COPY . /app
WORKDIR /app
RUN ln -sf /usr/share/zoneinfo/America/Caracas /etc/localtime
ENTRYPOINT ["dotnet", "caching_project.dll"]