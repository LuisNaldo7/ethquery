# EthQuery-Indexer

## Run

In ./ethquery-indexer copy .env.example to .env and set variables.

```
dotnet run -p ethquery-indexer
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