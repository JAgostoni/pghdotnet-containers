### Create a new network (if not already done)
`docker network create netug`

### Pull down the Active MQ Image and run a local instance
`docker pull redis`

`docker run -d -p 6379:6379 --name netug-redis --network netug redis`

### Test it by EXEC'ing into the container and running the CLI
`docker exec -it netug-redis redis-cli`

### Deploy to Kubernetes
`kubectl apply -f deployment.yaml`

[<< PREVIOUS: AMQ](../amq) ..... [NEXT: Publisher API >>](../publisher-api)
