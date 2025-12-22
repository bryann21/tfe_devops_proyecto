pipeline {
    agent any

    environment {
        DOCKERHUB_USER = "bryann444"
        BACKEND_IMAGE  = "tfe_backend"
        FRONTEND_IMAGE = "tfe_frontend"
    }

    stages {

        stage('Checkout') {
            steps {
                git branch: 'main',
                    url: 'https://github.com/bryann21/tfe_devops_proyecto.git'
            }
        }

        stage('Build Backend') {
            steps {
                dir('backend') {
                    sh 'docker build -t $DOCKERHUB_USER/$BACKEND_IMAGE:latest .'
                }
            }
        }

        stage('Build Frontend') {
            steps {
                dir('frontend') {
                    sh 'docker build -t $DOCKERHUB_USER/$FRONTEND_IMAGE:latest .'
                }
            }
        }

        stage('Login Docker Hub') {
            steps {
                withCredentials([usernamePassword(
                    credentialsId: 'dockerhub-creds',
                    usernameVariable: 'DOCKER_USER',
                    passwordVariable: 'DOCKER_PASS'
                )]) {
                    sh 'echo $DOCKER_PASS | docker login -u $DOCKER_USER --password-stdin'
                }
            }
        }

        stage('Push Images') {
            steps {
                sh 'docker push $DOCKERHUB_USER/$BACKEND_IMAGE:latest'
                sh 'docker push $DOCKERHUB_USER/$FRONTEND_IMAGE:latest'
            }
        }
    }

    post {
        success {
            echo 'Pipeline ejecutado correctamente'
        }
        failure {
            echo ' Error en el pipeline'
        }
    }
}
