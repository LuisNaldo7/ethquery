# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

## Set working dir
WORKDIR /ethquery/ethquery-indexer/

## copy app source
COPY ./ethquery-indexer/ /ethquery/ethquery-indexer/

## Build app
RUN dotnet restore &&\
    dotnet build --configuration Release --no-restore &&\
    dotnet test --no-restore --verbosity normal



# Run stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS run

## Declare env vars
ENV PROVIDER=http://localhost:8545

## Set working dir
WORKDIR /ethquery/ethquery-indexer/

## Operate as non-privileged user
RUN useradd net
RUN chown -R net:net /ethquery/ethquery-indexer/
USER net

## Copy app
COPY --from=build /ethquery/ethquery-indexer/bin/Release/net6.0/ ./

## Execute app
CMD ["./ethquery-indexer"]
