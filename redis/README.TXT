docker pull redis
docker network create netug
docker run -d -p 6379:6379 --name netug-redis --network netug redis
