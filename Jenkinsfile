pipeline {
    agent any

    environment {
        DOCKER_REGISTRY = "my-registry"
        DOCKER_IMAGE_NAME = 'msemployee'
    }
    
    stages {

        stage('Docker Build') {
            steps {
                script{
                    app = docker.build("${DOCKER_REGISTRY}/${DOCKER_IMAGE_NAME}:${BUILD_NUMBER}")
                }    
            }    
        }

        stage('SonarQube analysis') {
            steps {
                script{
                    env.PATH = "$PATH:/root/.dotnet/tools"

                    withSonarQubeEnv('sonarcloud') {
                        sh ''' dotnet sonarscanner begin /o:"wzapps"   /k:"msemployee" /d:sonar.cs.vscoveragexml.reportsPaths=Test/coverage.xml '''
                        sh ''' dotnet build --no-incremental '''
                        sh ''' dotnet-coverage collect 'dotnet test' -f xml  -o 'Test/coverage.xml' '''
                        sh ''' dotnet sonarscanner end '''
                    }        
                }
            }    
            
        }

        stage("Quality gate") {
            steps {
                timeout(time: 1, unit: 'HOURS') {
                    waitForQualityGate abortPipeline: true
                }
            }
        }

        stage('Docker Push') {
            steps {
                script{
                    app.push();
                }    
                
            }            
        }

        stage('Kube deploy') {
            steps {
                sh '''
                    kubectl apply -f k8s/dev/deployment.yml
                   '''    
            }            
        }
        
    }
}
