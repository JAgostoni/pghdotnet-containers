## Portal API
.NET Core WebAPI for finding products and getting product details

### Create a new network (if not already done)
`docker network create netug`

### Build the Docker image and TAG it
`docker build . -t netug-portal-api:latest`

### Launch a Docker container, forward local port 5002 to the container
`docker run -d -p 5003:80 --name netug-portal-api --net netug netug-portal-api:latest`

### Test it by running a GET on the find route (I use Postman)
[http://localhost:5003/api/product/find/pants](http://localhost:5003/api/product/find/pants)

### Tag it and Push to your remote registry
`docker tag netug-portal-api:latest kubesreg.azurecr.io/netug-portal-api:latest`

`docker push kubesreg.azurecr.io/netug-portal-api:latest`

### Deploy to Kubernetes
`kubectl apply -f deployment.yaml`
