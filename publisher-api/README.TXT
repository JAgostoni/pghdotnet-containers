docker network create netug
docker build . -t netug-publish-api:latest
docker run -d -p 5002:80 --name netug-pub-api --net netug netug-publish-api:latest

---

docker tag netug-publish-api:latest kubesreg.azurecr.io/netug-publish-api:latest
docker push kubesreg.azurecr.io/netug-publish-api:latest
