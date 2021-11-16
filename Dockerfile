FROM mcr.microsoft.com/dotnet/sdk:6.0

ENV PROVIDER=http://localhost:8545

# copy source files
COPY ./ethquery-indexer/ /ethquery/ethquery-indexer/

# set working dir
WORKDIR /ethquery/ethquery-indexer/

# build app for arm
RUN dotnet restore &&\
    dotnet build --configuration Release --no-restore &&\
    dotnet test --no-restore --verbosity normal

CMD ["./bin/Release/net6.0/ethquery-indexer"]
