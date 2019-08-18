pipeline {
    agent any
    parameters {
                string(name: 'TEST_CSPROJ_PATH', defaultValue: 'WebApplicationApiTest/WebApplicationApi.test.csproj')
		string(name: 'WEBAPPLICATIONAPI_PATH', defaultValue: 'WebApplicationApi.sln')
		string(name: 'PROJECT_NAME', defaultValue: 'WebApplicationApi')
		string(name: 'PORT_NO', defaultValue: '3000')

        }
    stages {
        stage('Build') {
            steps{
        bat '''
            dotnet restore %WEBAPPLICATIONAPI_PATH% --source https://api.nuget.org/v3/index.json
            dotnet build %WEBAPPLICATIONAPI_PATH% -p:Configuration=release -v:n
            dotnet test %TEST_CSPROJ_PATH%
            dotnet publish %WEBAPPLICATIONAPI_PATH% -c Release
            docker build --tag=testpipe --build-arg project_name=%PROJECT_NAME%.dll .
        '''}
        }
        stage('Deploy') {
            steps{
            bat '''
            docker run -p %PORT_NO%:80 testpipe  
            '''
            }
        }
    }
}