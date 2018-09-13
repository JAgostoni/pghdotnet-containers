## New Products Receiver
ActiveMQ client to pop new products off the topic and drop them into Redis.

### Create a new network (if not already done)
`docker network create netug`

### Build the Docker image and TAG it
`docker build . -t netug-products-receiver:latest`

### Launch a Docker container, forward local port 5002 to the container
`docker run -d --name netug-products-receiver --net netug netug-products-receiver:latest`

### Tag it and Push to your remote registry
`docker tag netug-products-receiver:latest kubesreg.azurecr.io/netug-products-receiver:latest`

`docker push kubesreg.azurecr.io/netug-products-receiver:latest`

### Deploy to Kubernetes
`kubectl apply -f deployment.yaml`

[[<< PREVIOUS: Publisher API](../publisher-api)] ..... [[NEXT: Portal API >>](../portal-api)]
