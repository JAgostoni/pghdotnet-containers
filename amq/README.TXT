docker pull rmohr/activemq
docker network create netug
docker run -d -p 61616:61616 -p 8161:8161 --name netug-activemq --network netug rmohr/activemq 
http://localhost:8161
admin:admin