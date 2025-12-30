pipeline {
    agent any

    environment {
        DOCKERHUB_USER = "bryann444"
        MANAGER_IP = "98.90.35.107"
        STACK_PATH = "/opt/tfe/stack_tfe.yml"
    }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build Backend') {
            steps {
                dir('backend') {
                    sh 'docker build -t $DOCKERHUB_USER/tfe_backend:latest .'
                }
            }
        }

        stage('Build Frontend') {
            steps {
                dir('frontend') {
                    sh 'docker build -t $DOCKERHUB_USER/tfe_frontend:latest .'
                }
            }
        }

        stage('Login DockerHub') {
            steps {
                withCredentials([
                    usernamePassword(
                        credentialsId: 'dockerhub-creds',
                        usernameVariable: 'DOCKER_USER',
                        passwordVariable: 'DOCKER_PASS'
                    )
                ]) {
                    sh 'echo $DOCKER_PASS | docker login -u $DOCKER_USER --password-stdin'
                }
            }
        }

        stage('Push Images') {
            steps {
                sh '''
                  docker push $DOCKERHUB_USER/tfe_backend:latest
                  docker push $DOCKERHUB_USER/tfe_frontend:latest
                '''
            }
        }

        stage('Deploy Swarm') {
            steps {
                withCredentials([
                    sshUserPrivateKey(
                        credentialsId: 'manager-ssh',
                        keyFileVariable: 'SSH_KEY'
                    )
                ]) {
                    sh '''
                    chmod 600 $SSH_KEY
                    ssh -o StrictHostKeyChecking=no -i $SSH_KEY ubuntu@$MANAGER_IP \
                      "docker stack deploy -c $STACK_PATH tfe-app"
                    '''
                }
            }
        }
    }

    post {
        success {
            echo '✅ CI/CD completado correctamente'
        }
        failure {
            echo '❌ Fallo en el pipeline'
        }
    }
}