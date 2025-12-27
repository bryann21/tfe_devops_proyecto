pipeline {
    agent any

    environment {
        MANAGER_IP = "98.90.35.107"
        DOCKERHUB_USER = "bryann444"
    }

    stages {

        stage('Checkout') {
            steps {
                git branch: 'main',
                    url: 'https://github.com/bryann21/tfe_devops_proyecto.git'
            }
        }

        stage('Build & Push Images (Remote Manager)') {
            steps {
                withCredentials([
                    sshUserPrivateKey(
                        credentialsId: 'manager-ssh',
                        keyFileVariable: 'SSH_KEY'
                    ),
                    usernamePassword(
                        credentialsId: 'dockerhub-creds',
                        usernameVariable: 'DOCKER_USER',
                        passwordVariable: 'DOCKER_PASS'
                    )
                ]) {
                    sh '''
                    chmod 600 $SSH_KEY

                    ssh -o StrictHostKeyChecking=no -i $SSH_KEY ubuntu@$MANAGER_IP << 'EOF'
                        set -e
                        cd /opt/tfe/tfe_devops_proyecto

                        echo "$DOCKER_PASS" | docker login -u "$DOCKER_USER" --password-stdin

                        docker build -t bryann444/tfe_backend:latest backend
                        docker build -t bryann444/tfe_frontend:latest frontend

                        docker push bryann444/tfe_backend:latest
                        docker push bryann444/tfe_frontend:latest
                    EOF
                    '''
                }
            }
        }

        stage('Deploy Stack (Swarm)') {
            steps {
                withCredentials([
                    sshUserPrivateKey(
                        credentialsId: 'manager-ssh',
                        keyFileVariable: 'SSH_KEY'
                    )
                ]) {
                    sh '''
                    chmod 600 $SSH_KEY

                    ssh -o StrictHostKeyChecking=no -i $SSH_KEY ubuntu@$MANAGER_IP << 'EOF'
                        cd /opt/tfe/tfe_devops_proyecto
                        docker stack deploy -c stack_tfe.yml tfe-app
                    EOF
                    '''
                }
            }
        }
    }

    post {
        success {
            echo ' CI/CD ejecutado correctamente'
        }
        failure {
            echo ' Error en el pipeline'
        }
    }
}
