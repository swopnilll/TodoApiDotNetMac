docker build -t myapi .

docker run -d -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development --name employee_api myapi

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrongPassword123!' -p 1433:1433 --name sql_server_demo --platform linux/amd64 -v sql_server_volume:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest
