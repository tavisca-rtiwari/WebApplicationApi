pipeline {
    agent any
    parameters {
                string(name: 'TEST_CSPROJ_PATH', defaultValue: 'WebApplicationApiTest/WebApplicationApi.test.csproj')
		string(name: 'WEBAPPLICATIONAPI_PATH', defaultValue: 'WebApplicationApi.sln')
		string(name: 'PROJECT_NAME', defaultValue: 'WebApplicationApi')
		string(name: 'DOCKER_USERNAME', defaultValue: '')
		string(name: 'DOCKER_PASSWORD')
		string(name: 'DOCKER_REPO_NAME', defaultValue: '')

        }
    stages {
        stage('Build') {
            steps{
        bat '''
            dotnet restore %WEBAPPLICATIONAPI_PATH% --source https://api.nuget.org/v3/index.json
            dotnet build %WEBAPPLICATIONAPI_PATH% -p:Configuration=release -v:n
            dotnet test %TEST_CSPROJ_PATH%
            dotnet publish %WEBAPPLICATIONAPI_PATH% -c Release
            docker build --tag=%DOCKER_USERNAME%/%DOCKER_REPO_NAME% --build-arg project_name=%PROJECT_NAME%.dll .
        '''}
        }
        stage('Deploy') {
            steps{
            bat '''
             docker login -u %DOCKER_USERNAME% -p %DOCKER_PASSWORD%
	     docker push %DOCKER_USERNAME%/%DOCKER_REPO_NAME%:latest
            '''
            }
        }
    }
}