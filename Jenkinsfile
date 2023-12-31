pipeline {

    agent any 

    stages {
        stage('Checkout Codebase'){
            steps{
                checkout scm: [$class: 'GitSCM', branches: [[name: '*/main']], userRemoteConfigs: [[credentialsId: 'PUBLIC_KEY', url: 'https://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@github.com/Sean2416/MicroServices']]] 
            }
        }

        stage('Build') {
            steps {
                echo 'Building Codebase'
            }
        }

        stage('Test'){
            steps {
                echo 'Running Tests on changes'
            }
        }
        
        stage('Deploy'){
            steps{
                echo 'Done!:tada:'
            }
        }
    }

    post {

        always {
            echo 'Sending Slack message'
            sh "go run main.go ${BUILD_URL} ${currentBuild.currentResult} ${BUILD_NUMBER} ${JOB_NAME} "
        }
    }
}