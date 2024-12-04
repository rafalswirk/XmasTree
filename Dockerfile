ARG ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
RUN echo ${ASPNETCORE_ENVIRONMENT}
WORKDIR /App

COPY . ./
RUN echo "Set work dir"
WORKDIR /App/src/Server/XmasTreeServiceWebApi

RUN echo "Build project"
RUN dotnet restore
RUN dotnet publish  --runtime linux-arm64 --self-contained -o out

FROM mcr.microsoft.com/dotnet/runtime:8.0
RUN apt-get update && \
    apt-get install -y python3 python3-pip python3-gpiozero && \
    rm -rf /var/lib/apt/lists/*


ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
RUN echo ${ASPNETCORE_ENVIRONMENT}
WORKDIR /App/XmasTreeServiceWebApi

RUN echo "Copy binaries from build-env"
COPY --from=build-env /App/src/Server/XmasTreeServiceWebApi/out .
ENTRYPOINT ["dotnet", "XmasTreeServiceWebApi.dll", "--urls=http://0.0.0.0:5000/"]
#CMD [./XmasTreeServiceWebApi]