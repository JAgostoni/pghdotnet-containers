docker network create netug
docker build . -t netug-portal-api:latest
docker run -d -p 5003:80 --name netug-portal-api --net netug netug-portal-api:latest

---

docker tag netug-portal-api:latest kubesreg.azurecr.io/netug-portal-api:latest
docker push kubesreg.azurecr.io/netug-portal-api:latest
