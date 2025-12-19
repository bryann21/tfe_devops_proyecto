#!/bin/bash
apt update -y
apt install -y docker.io
systemctl start docker
systemctl enable docker

# Inicializar Docker Swarm en el nodo manager
MANAGER_IP=$(curl -s http://169.254.169.254/latest/meta-data/local-ipv4)
docker swarm init --advertise-addr $MANAGER_IP

mkdir -p /opt/tfe
cd /opt/tfe

########################################################
# Crear archivo stack_tfe.yml
########################################################
cat << 'EOF' > stack_tfe.yml
version: "3.8"

services:
  backend:
    image: bryann444/tfe_backend:latest
    deploy:
      replicas: 2
      restart_policy:
        condition: on-failure
    ports:
      - "5000:80"
    networks:
      - tfe_backend

  balanceador:
    image: nginx:alpine
    ports:
      - "80:80"
    volumes:
      - /opt/tfe/nginx.conf:/etc/nginx/nginx.conf:ro
    deploy:
      replicas: 1
    networks:
      - tfe_backend
      - tfe_balanceador

  frontend:
    image: bryann444/tfe_frontend:latest
    deploy:
      replicas: 2
    ports:
      - "3000:80"
    networks:
      - tfe_balanceador

networks:
  tfe_backend:
    driver: overlay
  tfe_balanceador:
    driver: overlay
EOF

########################################################
# Crear archivo nginx.conf
########################################################
cat << 'EOF' > nginx.conf
events {}

http {
    upstream backend_cluster {
        server backend:5000;
        server backend:5000;
        server backend:5000;
    }

    server {
        listen 80;

        location / {
            proxy_pass http://backend_cluster;
        }
    }
}
EOF

########################################################
# Deploy del stack en Docker Swarm
########################################################
docker stack deploy -c stack_tfe.yml tfe-app

