# EthQuery-Indexer

## Prerequisites

- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)

## Run

Copy `./ethquery-indexer/env.example` to `./ethquery-indexer/.env` and adjust variables.

```
cp ./ethquery-indexer/.env.example ./ethquery-indexer/.env
```

Build and run application

```
dotnet run --project ethquery-indexer
```

## Run in Docker

pull image

```
docker pull luisnaldo7/ethquery-indexer
```

or build image

```
docker build -t luisnaldo7/ethquery-indexer:latest .
```

execute image

```
docker run -e PROVIDER="http://localhost:8545" --rm --name ethquery-indexer luisnaldo7/ethquery-indexer:latest
```

run container on boot

```
docker run -d -e PROVIDER="http://localhost:8545" --restart always --name ethquery-indexer luisnaldo7/ethquery-indexer:latest
```

## Swagger Documentation

Once the application is running you can open the [API documentation](http://localhost:5000/swagger).
