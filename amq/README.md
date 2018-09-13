### Create a new network (if not already done)
`docker network create netug`

### Pull down the Active MQ Image and run a local instance
`docker pull rmohr/activemq`

`docker run -d -p 61616:61616 -p 8161:8161 --name netug-activemq --network netug rmohr/activemq`

### Test it by launching the local admin portal
[http://localhost:8161](http://localhost:8161)
Default username and password are: admin/admin

### Deploy to Kubernetes
`kubectl apply -f deployment.yaml'
