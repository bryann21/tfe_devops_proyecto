#!/bin/bash
apt update -y
apt install -y docker.io
systemctl enable docker
systemctl start docker

MANAGER_IP="${manager_ip}"

# Obtener token del manager
JOIN_TOKEN=$(ssh -o StrictHostKeyChecking=no ubuntu@$MANAGER_IP "docker swarm join-token worker -q")

# Unirse al Swarm
docker swarm join --token $JOIN_TOKEN $MANAGER_IP:2377
