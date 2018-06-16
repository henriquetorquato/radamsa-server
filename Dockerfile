FROM centos:latest

RUN rpm -Uvh https://packages.microsoft.com/config/rhel/7/packages-microsoft-prod.rpm
RUN yum install gcc make git wget dotnet-sdk-2.1 -y

RUN git clone https://gitlab.com/akihe/radamsa.git
RUN cd radamsa && make && make install

COPY ./src/*.sln ./
COPY ./src/RadamsaServer/RadamsaServer.csproj RadamsaServer/
RUN dotnet restore
COPY . .
WORKDIR /src/RadamsaServer
RUN dotnet build -c Release -o /app

RUN dotnet publish -c Release -o /app

WORKDIR /app

EXPOSE 5000

ENTRYPOINT ["dotnet", "RadamsaServer.dll"]