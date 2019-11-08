# Use for my desktop machine on debian without iss
# Constants.PROD = false dans StephaneHomePage/Program.cs
cd /home/stephane/Code/DotNet/StephaneHomePage/StephaneHomePage/
echo '{ "password": "saturne2005" }' > password.json
cd ..
docker stop wwwsecure
docker rm wwwsecure
docker build -t homepage .
#docker run -it --name wwwsecure -p 80:80 -p 443:443 -e ASPNETCORE_URLS="https://+443;http://+80" -e ASPNETCORE_HTTPS_PORT=443 -e ASPNETCORE_Kestrel__Certificates__Default__Password=123456 -e ASPNETCORE_Kestrel__Certificates__Default__Path=/app/dev_cert.pfx -v /app:/https/ -d homepage --restart always
docker run -it --name wwwsecure -p 80:80 -p 443:443 -e ASPNETCORE_URLS="http://+80" -e ASPNETCORE_ENVIRONMENT="Development" -v /app:/https/ -d homepage --restart always
#docker run -it --name wwwsecure -p 80:80 -e ASPNETCORE_URLS="http;//+80" -d homepage --restart always

