docker network create netug
docker build . -t netug-products-receiver:latest
docker run -d --name netug-products-receiver --net netug netug-products-receiver:latest

---

docker tag netug-products-receiver:latest kubesreg.azurecr.io/netug-products-receiver:latest
docker push kubesreg.azurecr.io/netug-products-receiver:latest