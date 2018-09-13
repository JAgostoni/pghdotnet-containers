### Create a new network (if not already done)
`docker network create netug`

### Build the Docker image and TAG it
`docker build . -t netug-publish-api:latest`

### Launch a Docker container, forward local port 5002 to the container
`docker run -d -p 5002:80 --name netug-pub-api --net netug netug-publish-api:latest`

### Test it by posting a sample to the API (I use Postman)
[http://localhost:5002/api/products](http://localhost:5002/api/products)

Sample content:

`{
	"Slug": "test-product",
	"Name": "TestProduct",
	"Description": "Test Description"
}`

### Tag it and Push to your remote registry
`docker tag netug-publish-api:latest kubesreg.azurecr.io/netug-publish-api:latest`

`docker push kubesreg.azurecr.io/netug-publish-api:latest`

### Deploy to Kubernetes
`kubectl apply -f deployment.yaml`

