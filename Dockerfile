######################################################
# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine
WORKDIR /app
COPY /app ./

EXPOSE 5000

ENV \
    # ASP.NET Core version
    ASPNET_VERSION=6.0.3 \
    # Set the default console formatter to JSON
    Logging__Console__FormatterName=Json \
               # Enable detection of running in a container
    DOTNET_RUNNING_IN_CONTAINER=true \
    # Set the invariant mode since icu-libs isn't included (see https://github.com/dotnet/announcements/issues/20)
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true \
               LC_ALL=en_US.UTF-8 \
               LANG=en_US.UTF-8
               RUN apk add --no-cache icu-libs

# Install ASP.NET Core
RUN wget -O aspnetcore.tar.gz https://dotnetcli.azureedge.net/dotnet/aspnetcore/Runtime/$ASPNET_VERSION/aspnetcore-runtime-$ASPNET_VERSION-linux-musl-x64.tar.gz \
    && aspnetcore_sha512='8fb985bf79039cb1848604f08976ad82ff9582b0379cc7047f5bc95fa9e2a50f88b608efdb1b39d626b5e2a4615e38bee720a83f2d263f4dfb6716e65c74fa73' \
    && echo "$aspnetcore_sha512  aspnetcore.tar.gz" | sha512sum -c - \
    && tar -oxzf aspnetcore.tar.gz -C /usr/share/dotnet ./shared/Microsoft.AspNetCore.App \
    && rm aspnetcore.tar.gz

ENTRYPOINT ["dotnet", "./CC.Scheduling.dll"]
