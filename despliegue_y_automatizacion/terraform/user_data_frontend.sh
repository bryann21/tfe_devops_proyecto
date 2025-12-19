#!/bin/bash
set -e

yum update -y
yum install -y docker

systemctl enable docker
systemctl start docker

docker pull bryann444/tfe_frontend:latest

docker stop frontend || true
docker rm frontend || true

docker run -d \
  --name frontend \
  -p 80:80 \
  bryann444/tfe_frontend:latest

