#!/bin/bash
set -e

yum update -y
yum install -y docker

systemctl enable docker
systemctl start docker

docker pull bryann444/tfe_backend:latest

docker stop backend || true
docker rm backend || true

docker run -d \
  --name backend \
  -p 80:80 \
  -e ASPNETCORE_ENVIRONMENT=Production \
  -e ConnectionStrings__DefaultConnection="Server=18.191.138.244,1433;Database=Daños_Dia;User Id=tfe;Password=Bryannsilva21*;TrustServerCertificate=True;Encrypt=False;" \
  bryann444/tfe_backend:latest

