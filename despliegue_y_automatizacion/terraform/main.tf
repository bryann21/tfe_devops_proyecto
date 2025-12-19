provider "aws" {
  region = "us-east-1"
}

# === Security Group ===
resource "aws_security_group" "tfe_sg" {
  name        = "tfe-sg"
  description = "Permite trafico para frontend backend y Docker Swarm"

  ingress {
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }
  ingress {
  description = "SSH access"
  from_port   = 22
  to_port     = 22
  protocol    = "tcp"
  cidr_blocks = ["0.0.0.0/0"]
}
  ingress {
    from_port   = 5000
    to_port     = 5000
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  # Docker Swarm ports
  ingress {
    from_port   = 2377
    to_port     = 2377
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    from_port   = 7946
    to_port     = 7946
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    from_port   = 7946
    to_port     = 7946
    protocol    = "udp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    from_port   = 4789
    to_port     = 4789
    protocol    = "udp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  # salida
  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

# === Manager Node ===
resource "aws_instance" "manager" {
  ami           = var.ami_id
  instance_type = "t3.micro"
  key_name      = var.key_name
  security_groups = [aws_security_group.tfe_sg.name]

  user_data = file("user_data_administrador.sh")

  tags = {
    Name = "tfe-manager"
  }
}

# === Worker Node ===
resource "aws_instance" "worker" {
  ami           = var.ami_id
  instance_type = "t3.micro"
  key_name      = var.key_name
  security_groups = [aws_security_group.tfe_sg.name]

  user_data = templatefile("backup_user_data.sh", {
    manager_ip = aws_instance.manager.private_ip
  })

  tags = {
    Name = "tfe-worker"
  }
}




