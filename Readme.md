docker build -t myapi .

docker run -d -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development --name employee_api myapi
