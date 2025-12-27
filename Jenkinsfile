pipeline {
    agent any

    environment {
        MANAGER_IP = "98.90.35.107"
        APP_DIR = "/opt/tfe"
    }

    stages {

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

                    ssh -o StrictHostKeyChecking=no -i $SSH_KEY ubuntu@$MANAGER_IP "
                        set -e
                        cd $APP_DIR

                        echo '$DOCKER_PASS' | docker login -u '$DOCKER_USER' --password-stdin

                        docker build -t bryann444/tfe_backend:latest backend
                        docker build -t bryann444/tfe_frontend:latest frontend

                        docker push bryann444/tfe_backend:latest
                        docker push bryann444/tfe_frontend:latest
                    "
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

                    ssh -o StrictHostKeyChecking=no -i $SSH_KEY ubuntu@$MANAGER_IP "
                        cd $APP_DIR
                        docker stack deploy -c stack_tfe.yml tfe-app
                    "
                    '''
                }
            }
        }
    }
}